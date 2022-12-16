using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Web.Script.Serialization;
using System.Net;
using System.Web;
using System.Configuration;
using Serilog;
using Newtonsoft.Json;

namespace nBasysNews
{
    class Program
    {
        public class News
        {
            public string billItemContent { get; set; }
            public short? billItemIndex { get; set; }
            public string billItemGuid { get; set; }
            public string billItemActualID { get; set; }
            public string billItemTitle { get; set; }
        }
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose() // 設定最低顯示層級 預設: Information
                .WriteTo.Console() // 輸出至指令視窗
                .WriteTo.File("log-.log", // 輸出至檔案
                    rollingInterval: RollingInterval.Day, // 每天一個檔案
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u5}] {Message:lj}{NewLine}{Exception}"
                ) // 輸出到檔案 如:log-20221130.log
                .CreateLogger();

            // app.config
            string destDir = Properties.Settings.Default.destDir; // Gateway產出的output.txt的父層位置
            string tempDir = Properties.Settings.Default.tempDir; // output.txt的複製暫存路徑
            string targetFile = Properties.Settings.Default.targetFile; // output.txt的位置

            try
            {
                if (args[2] == Properties.Settings.Default.password.ToString()) // 登入密碼 Properties.Settings.Default.password.ToString()
                {
                    //先建立目標資料夾dir
                    string targetDir = Properties.Settings.Default.destDir;
                    if (Directory.Exists(targetDir))
                    {
                        Log.Information("資料夾已存在");
                    }
                    else
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    string targetTempFile = Path.Combine(tempDir, ("tBOutput.txt")); // 在路徑底下產生 tempOutput.txt
                    Directory.CreateDirectory(tempDir);

                    //Console.ReadLine(); //中斷點1 建立
                    
                    // 複製output再寫入 
                    File.Copy(targetFile, targetTempFile, true);
                    Log.Information("建立tempFolder");

                    // 寫入
                    var json = File.ReadAllText(targetTempFile); // 讀取複製出來的tempOutput.txt
                    string nJson = json.Replace("\\n", "n");
                    var content = JsonConvert.DeserializeObject<dynamic>(nJson);

                    int index = Convert.ToInt32(args[1]); // args[1]為輸入的則數
                    int indexLeng = content.Count; // 該節次最大則數
                    int indexRange = 5; // 輸入的則數前後5則

                    //Console.ReadLine(); //中斷點2 寫入 

                    if (index > 0 && index <= indexLeng) // 輸入的值為1~indexLeng
                    {
                        if (indexLeng > 10) // 該節次前後都足夠5則，indexLeng最少11則
                        {
                            // 輸入則數 前面不足5則 
                            // eg.輸入5，前面只有1-4共4則，列出範圍為1 2 3 "4" 5 6 7 8 9(列出9則)
                            if (index < indexRange)
                            {
                                for (int i = 0; i < index + indexRange; i++)
                                {
                                    string indexFile = Path.Combine(destDir, ((i + 1) + ".txt")); // 在路徑底下為產生檔案 [index].txt
                                    using (StreamWriter writer = new StreamWriter(indexFile)) // 寫進create的 [index].txt
                                    {
                                        writer.WriteLine("【{0}】{1}", content[i].billItemActualID, content[i].billItemTitle);
                                        writer.WriteLine(content[i].billItemContent);
                                    }
                                }
                            }
                            // 輸入則數 後面不足5則 
                            // eg.全文共10則，輸入6，後面只有8-11共4則，列出範圍為1 2 3 4 5 "6" 7 8 9 10(列出10則)
                            else if ((indexLeng - index) < indexRange)
                            {
                                for (int i = (index - indexRange) - 1; i < indexLeng; i++)
                                {
                                    string indexFile = Path.Combine(destDir, ((i + 1) + ".txt"));
                                    using (StreamWriter writer = new StreamWriter(indexFile))
                                    {
                                        writer.WriteLine("【{0}】{1}", content[i].billItemActualID, content[i].billItemTitle);
                                        writer.WriteLine(content[i].billItemContent);
                                    }
                                }
                            }
                            // 該節次前後有足夠5則
                            // eg.全文共11則，輸入6，列出範圍為1 2 3 4 5 "6" 7 8 9 10 11(列出11則)
                            else
                            {
                                for (int i = (index - indexRange) - 1; i < index + indexRange; i++)
                                {
                                    string indexFile = Path.Combine(destDir, ((i + 1) + ".txt"));
                                    using (StreamWriter writer = new StreamWriter(indexFile))
                                    {
                                        writer.WriteLine("【{0}】{1}", content[i].billItemActualID, content[i].billItemTitle);
                                        writer.WriteLine(content[i].billItemContent);
                                    }
                                }
                            }
                        }
                        else // 該節次小於11則
                        {
                            for (int i = 0; i < indexLeng; i++)
                            {
                                string indexFile = Path.Combine(destDir, ((i + 1) + ".txt"));
                                using (StreamWriter writer = new StreamWriter(indexFile))
                                {
                                    writer.WriteLine("【{0}】{1}", content[i].billItemActualID, content[i].billItemTitle);
                                    writer.WriteLine(content[i].billItemContent);
                                }
                            }
                        }

                        // 刪除temp檔路徑
                        Directory.Delete(tempDir, true); 
                        Log.Information("刪除tempFolder");

                        //Console.ReadLine(); //中斷點3 刪除 
                    }
                    else
                    {
                        Directory.Delete(tempDir, true);
                        Log.Information("則數錯誤!");
                    }
                }
                else
                {
                    Log.Information("密碼錯誤!");
                }    
                Log.Information("完成執行nBasysNews.exe");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {    
                // 將最後剩餘的 Log 寫入到 Sinks 去
                Log.CloseAndFlush();
            }
            Environment.Exit(0);
        }
    }
}
