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

namespace nSlugList
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
                //.WriteTo.Console() // 輸出至指令視窗
                .WriteTo.File(Properties.Settings.Default.logDir + "log-.log", // 輸出至檔案
                    rollingInterval: RollingInterval.Day, // 每天一個檔案
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u5}] {Message:lj}{NewLine}{Exception}"
                ) // 輸出到檔案 如:log-20221130.log
                .CreateLogger();

            // app.config
            string destDir = Properties.Settings.Default.destDir; // Gateway產出的output.txt的父層路徑
            string tempDir = Properties.Settings.Default.tempDir; // output.txt的複製暫存路徑
            string targetFile = Properties.Settings.Default.targetFile; // output.txt的位置
            string slugListFile = Properties.Settings.Default.slugFIle; // 匯出檔名

            try
            {
                if (args[1] == Properties.Settings.Default.password.ToString()) // 登入密碼 Properties.Settings.Default.password.ToString()
                {
                    // 建立
                    string fileName = Path.GetFileName(slugListFile);
                    string targetDirFile = Path.Combine(destDir, (fileName + ".txt")); // 在路徑底下產生 nSlug.txt
                    
                    // 先建立目標資料夾dir
                    string targetDir = Properties.Settings.Default.destDir; 
                    if (Directory.Exists(targetDir))
                    {
                        Log.Information("資料夾已存在");
                    }
                    else
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    // 複製output再寫入 
                    string targetTempFile = Path.Combine(tempDir, ("tSOutput.txt")); // 在路徑底下產生 tempOutput.txt
                    Directory.CreateDirectory(tempDir);
                    Log.Information("建立tempFolder");

                    //Console.ReadLine(); //中斷點1 建立

                    File.Copy(targetFile, targetTempFile, true);

                    var json = File.ReadAllText(targetTempFile); // 讀取複製出來的tempOutput.txt
                    var content = JsonConvert.DeserializeObject<dynamic>(json);

                    using (StreamWriter writer = new StreamWriter(targetDirFile)) // 寫進新建的Slug.txt中
                    {
                        foreach (var ctd in content)
                        {
                            //Console.WriteLine(ctd.billItemTitle);
                            writer.WriteLine("【"+ctd.billItemActualID+ "】" + ctd.billItemTitle);
                        }
                    }
                    Log.Information("寫入nSlug.txt");

                    //Console.ReadLine(); //中斷點2 寫入
                }
                else
                {
                    //Console.WriteLine("密碼錯誤!");
                    Log.Information("密碼錯誤!");
                }
                Directory.Delete(tempDir, true);

                //Console.ReadLine(); //中斷點3 刪除

                Log.Information("刪除tempFolder");
                Log.Information("完成執行nSlugList.exe");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks
                Log.CloseAndFlush();
                Environment.Exit(0);
            }
        }

    }
}
