using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Serilog;
using System.Threading;

namespace Gateway
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // 防止程式多開
            bool isAppRunning = false;
            Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isAppRunning);
            if (!isAppRunning)
            {
                MessageBox.Show("程式已開啟! 請勿再次啟動");
                Environment.Exit(1);
            }

            // LOG 程式執行狀況
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
                Log.Information("程式執行正常");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                MessageBox.Show(ex.Message);
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks
                Log.CloseAndFlush();
            }
        }
        
    }
}
