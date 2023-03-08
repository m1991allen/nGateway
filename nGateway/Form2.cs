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
using nGateway.Models;
using Newtonsoft.Json;
using Serilog;

namespace nGateway
{
    public partial class ConfigForm : Form
    {
        public ConfigForm(string deviceName)
        {
            InitializeComponent();
            this._deviceName.Text = deviceName;
            this._api1.Text = Properties.Settings.Default.postBillList;
            this._api2.Text = Properties.Settings.Default.postBillitemList;
        }

        public string setDeviceName()
        {
            string value = "要回傳的值";
            return value;
        }
        public void save_btn_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Properties.Settings.Default.deviceName = _deviceName.Text.Trim();
            Properties.Settings.Default.postBillList = _api1.Text.Trim();
            Properties.Settings.Default.postBillitemList = _api2.Text.Trim();

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            if ( Properties.Settings.Default.deviceName != "" && Properties.Settings.Default.postBillList != "" && Properties.Settings.Default.postBillitemList != "")
            {
                var mainform = new mainForm();
                mainform._deviceName.Text = Properties.Settings.Default.deviceName;
                //MessageBox.Show(mainform._deviceName.Text);
                MessageBox.Show("設定已儲存！");
                this.Hide();
            }
        }

        private void _deviceName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_deviceName.Text))
            {
                MessageBox.Show("不能為空!");
                _deviceName.Text = Properties.Settings.Default.deviceName;
            }
        }

        private void _api1_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_api1.Text))
            {
                MessageBox.Show("不能為空!");
                _api1.Text = Properties.Settings.Default.postBillList;
            }
        }

        private void _api2_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_api2.Text))
            {
                MessageBox.Show("不能為空!");
                _api2.Text = Properties.Settings.Default.postBillitemList;
            }
        }
    }
}
