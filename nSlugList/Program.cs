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
                .WriteTo.Console() // 輸出至指令視窗
                .WriteTo.File("log-.log", // 輸出至檔案
                    rollingInterval: RollingInterval.Day, // 每天一個檔案
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u5}] {Message:lj}{NewLine}{Exception}"
                ) // 輸出到檔案 如:log-20221130.log
                .CreateLogger();

            try
            {
                if (args[1] == "1") // 登入密碼 Properties.Settings.Default.password.ToString()
                {
                    string destDir = Properties.Settings.Default.destinationDir; // Gateway產出的output.txt的父層位置
                    string targetFileDir = Properties.Settings.Default.targetFileDir; // output.txt的位置

                    string fileName = Path.GetFileName("nSlug");
                    string targetDir = Path.Combine(destDir, (fileName + ".txt")); // 在路徑底下為產生檔案 nSlug.txt

                    // 寫入
                    var json = File.ReadAllText(targetFileDir);
                    var content = JsonConvert.DeserializeObject<dynamic>(json);
                    var news = new News();

                    using (StreamWriter writer = new StreamWriter(targetDir)) // 寫進create的 nSlug.txt
                    {
                        foreach (var ctd in content)
                        {
                            Console.WriteLine(ctd.billItemTitle);
                            writer.WriteLine(ctd.billItemTitle);
                        }
                    }
                    Log.Information("執行nSlugList Application");
                }
                else
                {
                    Console.WriteLine("密碼錯誤!");
                    Log.Information("密碼錯誤!");
                }
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks 去！
                Log.CloseAndFlush();
                Environment.Exit(1);
            }
        }

    }
}
