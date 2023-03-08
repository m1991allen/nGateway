namespace nGateway
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._deviceName = new System.Windows.Forms.TextBox();
            this._api1 = new System.Windows.Forms.TextBox();
            this._api2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(127, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "棚位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "接口API 1";
            // 
            // _deviceName
            // 
            this._deviceName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._deviceName.Location = new System.Drawing.Point(181, 48);
            this._deviceName.Name = "_deviceName";
            this._deviceName.Size = new System.Drawing.Size(100, 29);
            this._deviceName.TabIndex = 2;
            this._deviceName.Validated += new System.EventHandler(this._deviceName_Validated);
            // 
            // _api1
            // 
            this._api1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._api1.Location = new System.Drawing.Point(18, 126);
            this._api1.Name = "_api1";
            this._api1.Size = new System.Drawing.Size(435, 29);
            this._api1.TabIndex = 3;
            this._api1.Validated += new System.EventHandler(this._api1_Validated);
            // 
            // _api2
            // 
            this._api2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._api2.Location = new System.Drawing.Point(18, 197);
            this._api2.Name = "_api2";
            this._api2.Size = new System.Drawing.Size(435, 29);
            this._api2.TabIndex = 5;
            this._api2.Validated += new System.EventHandler(this._api2_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(13, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "接口API 2";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(359, 260);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(94, 38);
            this.save_btn.TabIndex = 6;
            this.save_btn.Text = "儲存";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 310);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this._api2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._api1);
            this.Controls.Add(this._deviceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _deviceName;
        private System.Windows.Forms.TextBox _api1;
        private System.Windows.Forms.TextBox _api2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save_btn;
    }
}