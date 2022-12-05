// 引用ini必要
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Gateway
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.postQueue_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.status_lab = new System.Windows.Forms.Label();
            this._status = new System.Windows.Forms.Label();
            this.count_lab = new System.Windows.Forms.Label();
            this.lab1 = new System.Windows.Forms.Label();
            this._countdownSec = new System.Windows.Forms.Label();
            this._count = new System.Windows.Forms.TextBox();
            this.lab2 = new System.Windows.Forms.Label();
            this.path_lab = new System.Windows.Forms.Label();
            this._destinationDir = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_QueueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.deviceName_lab = new System.Windows.Forms.Label();
            this._deviceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker.Location = new System.Drawing.Point(12, 26);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(165, 29);
            this.dateTimePicker.TabIndex = 15;
            // 
            // postQueue_btn
            // 
            this.postQueue_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postQueue_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.postQueue_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.postQueue_btn.Location = new System.Drawing.Point(183, 25);
            this.postQueue_btn.Name = "postQueue_btn";
            this.postQueue_btn.Size = new System.Drawing.Size(151, 30);
            this.postQueue_btn.TabIndex = 1;
            this.postQueue_btn.Text = "取Queue(G)";
            this.postQueue_btn.Click += new System.EventHandler(this.PostQueue_btn_click);
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.start_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.start_btn.Location = new System.Drawing.Point(340, 16);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(118, 48);
            this.start_btn.TabIndex = 2;
            this.start_btn.Text = "啟動(S)";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_click);
            // 
            // status_lab
            // 
            this.status_lab.AutoSize = true;
            this.status_lab.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.status_lab.Location = new System.Drawing.Point(488, 128);
            this.status_lab.Name = "status_lab";
            this.status_lab.Size = new System.Drawing.Size(57, 20);
            this.status_lab.TabIndex = 4;
            this.status_lab.Text = "狀態：";
            // 
            // _status
            // 
            this._status.AutoSize = true;
            this._status.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._status.ForeColor = System.Drawing.Color.Red;
            this._status.Location = new System.Drawing.Point(625, 123);
            this._status.Name = "_status";
            this._status.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._status.Size = new System.Drawing.Size(72, 26);
            this._status.TabIndex = 5;
            this._status.Text = "停止 ■";
            // 
            // count_lab
            // 
            this.count_lab.AutoSize = true;
            this.count_lab.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.count_lab.Location = new System.Drawing.Point(488, 184);
            this.count_lab.Name = "count_lab";
            this.count_lab.Size = new System.Drawing.Size(115, 20);
            this.count_lab.TabIndex = 6;
            this.count_lab.Text = "更新倒數(秒)：";
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab1.Location = new System.Drawing.Point(484, 290);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(61, 30);
            this.lab1.TabIndex = 7;
            this.lab1.Text = "倒數";
            this.lab1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _countdownSec
            // 
            this._countdownSec.AutoSize = true;
            this._countdownSec.Font = new System.Drawing.Font("Segoe UI", 99F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._countdownSec.ForeColor = System.Drawing.SystemColors.Highlight;
            this._countdownSec.Location = new System.Drawing.Point(565, 217);
            this._countdownSec.Name = "_countdownSec";
            this._countdownSec.Size = new System.Drawing.Size(151, 176);
            this._countdownSec.TabIndex = 8;
            this._countdownSec.Text = "5";
            this._countdownSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _count
            // 
            this._count.BackColor = System.Drawing.SystemColors.Control;
            this._count.Cursor = System.Windows.Forms.Cursors.Default;
            this._count.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._count.ForeColor = System.Drawing.SystemColors.ControlText;
            this._count.Location = new System.Drawing.Point(639, 176);
            this._count.Name = "_count";
            this._count.Size = new System.Drawing.Size(53, 35);
            this._count.TabIndex = 12;
            this._count.Text = "5";
            this._count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._count_KeyPress);
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab2.Location = new System.Drawing.Point(744, 290);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(37, 30);
            this.lab2.TabIndex = 9;
            this.lab2.Text = "秒";
            this.lab2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // path_lab
            // 
            this.path_lab.AutoSize = true;
            this.path_lab.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.path_lab.Location = new System.Drawing.Point(486, 373);
            this.path_lab.Name = "path_lab";
            this.path_lab.Size = new System.Drawing.Size(89, 20);
            this.path_lab.TabIndex = 11;
            this.path_lab.Text = "目標路徑：";
            this.path_lab.Visible = false;
            // 
            // _destinationDir
            // 
            this._destinationDir.BackColor = System.Drawing.SystemColors.GrayText;
            this._destinationDir.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._destinationDir.ForeColor = System.Drawing.Color.Silver;
            this._destinationDir.Location = new System.Drawing.Point(490, 396);
            this._destinationDir.Name = "_destinationDir";
            this._destinationDir.ReadOnly = true;
            this._destinationDir.Size = new System.Drawing.Size(284, 29);
            this._destinationDir.TabIndex = 13;
            this._destinationDir.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeight = 30;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Date,
            this.Column_QueueName,
            this.GUID});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.Location = new System.Drawing.Point(12, 74);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(446, 351);
            this.dataGridView.TabIndex = 14;
            this.dataGridView.Tag = "";
            // 
            // Column_Date
            // 
            this.Column_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Date.DataPropertyName = "columnDate";
            dataGridViewCellStyle6.NullValue = "123";
            this.Column_Date.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column_Date.HeaderText = "日期";
            this.Column_Date.MinimumWidth = 20;
            this.Column_Date.Name = "Column_Date";
            this.Column_Date.ReadOnly = true;
            this.Column_Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_Date.Width = 220;
            // 
            // Column_QueueName
            // 
            this.Column_QueueName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_QueueName.DataPropertyName = "columnName";
            this.Column_QueueName.HeaderText = "QueueName";
            this.Column_QueueName.MinimumWidth = 10;
            this.Column_QueueName.Name = "Column_QueueName";
            this.Column_QueueName.ReadOnly = true;
            this.Column_QueueName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GUID
            // 
            this.GUID.DataPropertyName = "billGuid";
            this.GUID.HeaderText = "BillGuid";
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            this.GUID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GUID.Visible = false;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            // 
            // deviceName_lab
            // 
            this.deviceName_lab.AutoSize = true;
            this.deviceName_lab.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deviceName_lab.Location = new System.Drawing.Point(488, 77);
            this.deviceName_lab.Name = "deviceName_lab";
            this.deviceName_lab.Size = new System.Drawing.Size(57, 20);
            this.deviceName_lab.TabIndex = 16;
            this.deviceName_lab.Text = "棚位：";
            // 
            // _deviceName
            // 
            this._deviceName.AutoSize = true;
            this._deviceName.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._deviceName.ForeColor = System.Drawing.SystemColors.Highlight;
            this._deviceName.Location = new System.Drawing.Point(634, 74);
            this._deviceName.Name = "_deviceName";
            this._deviceName.Size = new System.Drawing.Size(67, 26);
            this._deviceName.TabIndex = 17;
            this._deviceName.Text = "SUB2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._deviceName);
            this.Controls.Add(this.deviceName_lab);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this._destinationDir);
            this.Controls.Add(this._count);
            this.Controls.Add(this.path_lab);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this._countdownSec);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.count_lab);
            this.Controls.Add(this._status);
            this.Controls.Add(this.status_lab);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.postQueue_btn);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "Form1";
            this.Text = "Gateway";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button postQueue_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label status_lab;
        private System.Windows.Forms.Label _status;
        private System.Windows.Forms.Label count_lab;
        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label _countdownSec;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.Label path_lab;
        private System.Windows.Forms.TextBox _count;
        private System.Windows.Forms.TextBox _destinationDir;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label deviceName_lab;
        private System.Windows.Forms.Label _deviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_QueueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
    }
}

