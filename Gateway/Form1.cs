using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Web.Script.Serialization;
using System.Net;
using System.Web;
using System.Configuration;

using Gateway.Models;
using Newtonsoft.Json;
using Serilog;

namespace Gateway
{
    public partial class Form1 : Form
    {
        string destinationDir = Properties.Settings.Default.destinationDir;
        string deviceName = Properties.Settings.Default.deviceName;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            _destinationDir.Text = destinationDir;
            _deviceName.Text = deviceName;
            _countdownSec.Text = _count.Text;
        }

        // 控制 啟動/關閉 倒數
        private void Start_btn_click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count == 0)// 先判斷dataGridView是否有資料
                {
                    MessageBox.Show("請先取Queue");
                }
                else
                {
                    _countdownSec.Text = _count.Text;
                    if (_status.Text == "讀秒 ▶")
                    {
                        _status.Text = "停止 ■";
                        _status.ForeColor = Color.Red;
                        start_btn.Text = "啟動(S)";
                        start_btn.BackColor = SystemColors.Highlight;
                        _countdownSec.ForeColor = SystemColors.Highlight;

                        Timer1.Stop();
                        postQueue_btn.Enabled = true;
                        dataGridView.Enabled = true;
                        dateTimePicker.Enabled = true;
                    }
                    else
                    {
                        _status.Text = "讀秒 ▶";
                        _status.ForeColor = SystemColors.Highlight;
                        start_btn.Text = "停止(S)";
                        start_btn.BackColor = Color.Chocolate;

                        dataGridView.Enabled = false;
                        Timer1 = new System.Windows.Forms.Timer();
                        Timer1.Tick += new EventHandler(Timer1_Tick);
                        Timer1.Interval = 1000;
                        Timer1.Start();
                        dataGridView.Enabled = false;
                        postQueue_btn.Enabled = false;
                        dateTimePicker.Enabled = false;

                    }
                }
                Log.Information("點擊 啟動/關閉");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                MessageBox.Show(ex.Message);
                Log.Error("操作錯誤:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks 去！
                Log.CloseAndFlush();
            }

        }
        // 控制 啟動/關閉 倒數 _綁定快捷鍵
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S)
                {
                    start_btn.PerformClick(); // 生成System.Windows.Forms.Control.Click事件
                    e.Handled = true; // 獲取或設置一個值，該值指示是否處理過此事件
                }
                if (e.KeyCode == Keys.G)
                {
                    postQueue_btn.PerformClick(); // 生成System.Windows.Forms.Control.Click事件
                    e.Handled = true; // 獲取或設置一個值，該值指示是否處理過此事件
                }
                Log.Information("快捷鍵S/G");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                MessageBox.Show(ex.Message);
                Log.Error("操作錯誤:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks 去！
                Log.CloseAndFlush();
            }

        }
        // 倒數計時
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int c = int.Parse(_countdownSec.Text);
            if (c > 0)
            {
                c--;
                if (c < 3)
                {
                    _countdownSec.ForeColor = Color.Red;
                }
            }
            else
            {
                //讀完秒後產生txt檔
                c = int.Parse(_count.Text);
                _countdownSec.ForeColor = SystemColors.Highlight;
                PostNews();
            }
            _countdownSec.Text = c.ToString();
        }
        // 倒數欄位防呆
        private void _count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // 呼叫queue
        private void PostQueue_btn_click(object sender, EventArgs e)
        {
            PostQueue();
        }

        // Post Rundown API
        void PostQueue()
        {
            HttpWebRequest httpwebReguest = (HttpWebRequest)HttpWebRequest.Create(Properties.Settings.Default.postQueue);
            httpwebReguest.Method = "POST";
            httpwebReguest.ContentType = "application/json; charset=utf-8";

            try
            {
                RunDownArgs rd = new RunDownArgs();
                rd.columnDate = dateTimePicker.Value.ToString("yyyy-MM-dd"); //yyyy - MM - dd
                rd.deviceName = deviceName;
                using (StreamWriter writer = new StreamWriter(httpwebReguest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(rd);
                    writer.Write(json);
                    writer.Flush();
                }

                using (StreamReader result = new StreamReader(httpwebReguest.GetResponse().GetResponseStream()))
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(result.ReadToEnd());
                    //MessageBox.Show(data.ToString());

                    this.dataGridView.AutoGenerateColumns = false;
                    this.dataGridView.DataSource = data;
                }
                Log.Information("Post Rundown API");
            }

            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                MessageBox.Show(ex.Message);
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks 去！
                Log.CloseAndFlush();
            }
        }
        // Post News API
        void PostNews()
        {
            HttpWebRequest httpwebReguest = (HttpWebRequest)HttpWebRequest.Create(Properties.Settings.Default.postNews);
            httpwebReguest.Method = "POST";
            httpwebReguest.ContentType = "application/json; charset=utf-8";
            try
            {
                NewsArgs news = new NewsArgs();

                // 取得選取的GUID值
                Int32 selectedRowCount =
        dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        // MessageBox.Show(selectedRowCount.ToString());
                        news.billGuid = dataGridView.SelectedRows[i].Cells[2].Value.ToString();
                    }

                }

                // 序列化
                using (var streamWriter = new StreamWriter(httpwebReguest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(news);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                // 反序列化
                using (StreamReader result = new StreamReader(httpwebReguest.GetResponse().GetResponseStream()))
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(result.ReadToEnd());
                    string fileName = Path.GetFileName("output"); // 以GUID命名txt檔
                    string targetDir = Path.Combine(destinationDir, (fileName + ".txt"));
                    File.WriteAllText(targetDir, data.ToString());
                }
                Log.Information("Post News API");
            }
            catch (Exception ex)
            {
                // 紀錄未被捕捉的例外 (Unhandled Exception)
                MessageBox.Show(ex.Message);
                Log.Error("例外狀況:{exception}", ex);
            }
            finally
            {
                // 將最後剩餘的 Log 寫入到 Sinks 去！
                Log.CloseAndFlush();
            }
        }
    }
}
