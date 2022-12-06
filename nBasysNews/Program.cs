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

            try
            {
                //if(args[3] == "1") // 登入密碼 Properties.Settings.Default.password.ToString()
                //{
                string destDir = Properties.Settings.Default.destinationDir; // Gateway產出的output.txt的父層位置
                string targetFileDir = Properties.Settings.Default.targetFileDir; // output.txt的位置
                                                                                  // 寫入
                var json = File.ReadAllText(targetFileDir);
                var content = JsonConvert.DeserializeObject<dynamic>(json);

                int index = Convert.ToInt32(args[1]); // args[1]為輸入的則數
                int indexLeng = content.Count; // 該節次最大則數
                int indexRange = 5; // 輸入的則數前後5則

                var news = new News();

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
                                string targetDir = Path.Combine(destDir, ((i + 1) + ".txt")); // 在路徑底下為產生檔案 [index].txt
                                using (StreamWriter writer = new StreamWriter(targetDir)) // 寫進create的 [index].txt
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
                            //Console.WriteLine(content[index - indexRange].billItemIndex);
                            for (int i = (index - indexRange) - 1; i < indexLeng; i++)
                            {
                                string targetDir = Path.Combine(destDir, ((i + 1) + ".txt"));
                                using (StreamWriter writer = new StreamWriter(targetDir))
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
                                string targetDir = Path.Combine(destDir, ((i + 1) + ".txt"));
                                using (StreamWriter writer = new StreamWriter(targetDir))
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
                            string targetDir = Path.Combine(destDir, ((i + 1) + ".txt"));
                            using (StreamWriter writer = new StreamWriter(targetDir))
                            {
                                writer.WriteLine("【{0}】{1}", content[i].billItemActualID, content[i].billItemTitle);
                                writer.WriteLine(content[i].billItemContent);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("則數錯誤!");
                    Log.Information("則數錯誤!");
                }
                //}
                Log.Information("執行nBasysNews Application");
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
            Environment.Exit(1);
            // 測試測試測試測試測試測試
        }
    }
}
