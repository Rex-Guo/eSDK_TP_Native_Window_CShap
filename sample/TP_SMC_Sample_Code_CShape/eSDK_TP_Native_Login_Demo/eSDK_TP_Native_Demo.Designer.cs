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

﻿namespace TP_Native_Demo
{
    partial class eSDK_TP_Native_Demo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginManagement = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtConsoleLog = new System.Windows.Forms.RichTextBox();
            this.LoginManagement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginManagement
            // 
            this.LoginManagement.Controls.Add(this.textBox2);
            this.LoginManagement.Controls.Add(this.textBox1);
            this.LoginManagement.Controls.Add(this.Logout);
            this.LoginManagement.Controls.Add(this.label2);
            this.LoginManagement.Controls.Add(this.label1);
            this.LoginManagement.Controls.Add(this.Login);
            this.LoginManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginManagement.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginManagement.Location = new System.Drawing.Point(12, 12);
            this.LoginManagement.Name = "LoginManagement";
            this.LoginManagement.Size = new System.Drawing.Size(196, 161);
            this.LoginManagement.TabIndex = 1;
            this.LoginManagement.TabStop = false;
            this.LoginManagement.Text = "Autherfication Management";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Huawei@123";
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "dongjian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "UserName：";
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(102, 99);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(88, 32);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(8, 99);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(88, 32);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtConsoleLog);
            this.groupBox1.Location = new System.Drawing.Point(214, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console_Log";
            // 
            // rtxtConsoleLog
            // 
            this.rtxtConsoleLog.BackColor = System.Drawing.Color.Silver;
            this.rtxtConsoleLog.Location = new System.Drawing.Point(6, 20);
            this.rtxtConsoleLog.Name = "rtxtConsoleLog";
            this.rtxtConsoleLog.Size = new System.Drawing.Size(292, 174);
            this.rtxtConsoleLog.TabIndex = 0;
            this.rtxtConsoleLog.Text = "";
            // 
            // eSDK_TP_Native_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 222);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoginManagement);
            this.Name = "eSDK_TP_Native_Demo";
            this.Text = "Form1";
            this.LoginManagement.ResumeLayout(false);
            this.LoginManagement.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoginManagement;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtxtConsoleLog;
    }
}

