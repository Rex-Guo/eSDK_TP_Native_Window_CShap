/*Copyright 2015 Huawei Technologies Co., Ltd. All rights reserved.
eSDK is licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
		http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

﻿namespace TP_Native_Demo.ParameterForms
{
    partial class SiteForConference
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
            this.OK_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_site_URI = new System.Windows.Forms.TextBox();
            this.tb_site_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_conferenceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_site_Type = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(55, 162);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 30);
            this.OK_Button.TabIndex = 9;
            this.OK_Button.Text = "确认";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "会场类型：";
            // 
            // tb_site_URI
            // 
            this.tb_site_URI.Location = new System.Drawing.Point(71, 60);
            this.tb_site_URI.Name = "tb_site_URI";
            this.tb_site_URI.Size = new System.Drawing.Size(91, 21);
            this.tb_site_URI.TabIndex = 23;
            this.tb_site_URI.Text = "01033001";
            // 
            // tb_site_Name
            // 
            this.tb_site_Name.Location = new System.Drawing.Point(70, 96);
            this.tb_site_Name.Name = "tb_site_Name";
            this.tb_site_Name.Size = new System.Drawing.Size(91, 21);
            this.tb_site_Name.TabIndex = 22;
            this.tb_site_Name.Text = "NewTest1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "会场URI：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "会场名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_site_Type);
            this.groupBox1.Controls.Add(this.tb_conferenceID);
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_site_Name);
            this.groupBox1.Controls.Add(this.tb_site_URI);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 198);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "删除或添加会场";
            // 
            // tb_conferenceID
            // 
            this.tb_conferenceID.Location = new System.Drawing.Point(70, 25);
            this.tb_conferenceID.Name = "tb_conferenceID";
            this.tb_conferenceID.Size = new System.Drawing.Size(91, 21);
            this.tb_conferenceID.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "会议ID:";
            // 
            // tb_site_Type
            // 
            this.tb_site_Type.FormattingEnabled = true;
            this.tb_site_Type.Items.AddRange(new object[] {
            "选值：(0~11)"});
            this.tb_site_Type.Location = new System.Drawing.Point(70, 129);
            this.tb_site_Type.Name = "tb_site_Type";
            this.tb_site_Type.Size = new System.Drawing.Size(92, 20);
            this.tb_site_Type.TabIndex = 29;
            this.tb_site_Type.Text = "1";
            // 
            // SiteForConference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 217);
            this.Controls.Add(this.groupBox1);
            this.Name = "SiteForConference";
            this.Text = "SiteInConference";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_site_URI;
        private System.Windows.Forms.TextBox tb_site_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_conferenceID;
        private System.Windows.Forms.ComboBox tb_site_Type;
    }
}