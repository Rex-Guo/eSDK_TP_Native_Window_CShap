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

﻿namespace 会议中会场操作Demo
{
    partial class Conference_Sites
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
            this.siteGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_QuerySiteList = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_Rate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Duration = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_BeginTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_scheduleConf = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtConsoleLog = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_confId = new System.Windows.Forms.TextBox();
            this.dgw_ConfSitesList = new System.Windows.Forms.DataGridView();
            this.btn_addSiteToConf = new System.Windows.Forms.Button();
            this.btn_delSiteFromConfEx = new System.Windows.Forms.Button();
            this.btn_connectSitesEx = new System.Windows.Forms.Button();
            this.btn_disconnectSitesEx = new System.Windows.Forms.Button();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LoginManagement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_ConfSitesList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginManagement
            // 
            this.LoginManagement.Controls.Add(this.textBox2);
            this.LoginManagement.Controls.Add(this.textBox1);
            this.LoginManagement.Controls.Add(this.label2);
            this.LoginManagement.Controls.Add(this.label1);
            this.LoginManagement.Controls.Add(this.Logout);
            this.LoginManagement.Controls.Add(this.Login);
            this.LoginManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginManagement.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginManagement.Location = new System.Drawing.Point(10, 5);
            this.LoginManagement.Name = "LoginManagement";
            this.LoginManagement.Size = new System.Drawing.Size(201, 141);
            this.LoginManagement.TabIndex = 3;
            this.LoginManagement.TabStop = false;
            this.LoginManagement.Text = "Login Management";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Huawei@123";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "dongjian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "password：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "userName：";
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(110, 97);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(72, 32);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(15, 97);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(74, 32);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.siteGridView);
            this.groupBox1.Controls.Add(this.btn_QuerySiteList);
            this.groupBox1.Location = new System.Drawing.Point(223, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 330);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sites List";
            // 
            // siteGridView
            // 
            this.siteGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.siteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.siteGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.siteGridView.EnableHeadersVisualStyles = false;
            this.siteGridView.Location = new System.Drawing.Point(6, 17);
            this.siteGridView.Name = "siteGridView";
            this.siteGridView.RowHeadersVisible = false;
            this.siteGridView.RowTemplate.Height = 23;
            this.siteGridView.Size = new System.Drawing.Size(533, 260);
            this.siteGridView.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "checked";
            this.Column1.FalseValue = "0";
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "siteURI";
            this.Column2.HeaderText = "Site URI";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "siteName";
            this.Column3.HeaderText = "Site Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "siteType";
            this.Column4.HeaderText = "Site Type";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "siteFrom";
            this.Column5.HeaderText = "Site Source";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "siteRate";
            this.Column6.HeaderText = "Site Rate";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // btn_QuerySiteList
            // 
            this.btn_QuerySiteList.BackColor = System.Drawing.Color.Silver;
            this.btn_QuerySiteList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuerySiteList.Location = new System.Drawing.Point(361, 284);
            this.btn_QuerySiteList.Name = "btn_QuerySiteList";
            this.btn_QuerySiteList.Size = new System.Drawing.Size(176, 40);
            this.btn_QuerySiteList.TabIndex = 9;
            this.btn_QuerySiteList.Text = "querySitesList";
            this.btn_QuerySiteList.UseVisualStyleBackColor = false;
            this.btn_QuerySiteList.Click += new System.EventHandler(this.btn_QuerySiteList_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_Rate);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tb_Duration);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.tb_BeginTime);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tb_Name);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btn_scheduleConf);
            this.groupBox4.Location = new System.Drawing.Point(10, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 188);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "schedule conference";
            // 
            // tb_Rate
            // 
            this.tb_Rate.Location = new System.Drawing.Point(76, 106);
            this.tb_Rate.Name = "tb_Rate";
            this.tb_Rate.Size = new System.Drawing.Size(108, 21);
            this.tb_Rate.TabIndex = 19;
            this.tb_Rate.Text = "1920k";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "name:";
            // 
            // tb_Duration
            // 
            this.tb_Duration.Location = new System.Drawing.Point(76, 79);
            this.tb_Duration.Name = "tb_Duration";
            this.tb_Duration.Size = new System.Drawing.Size(108, 21);
            this.tb_Duration.TabIndex = 18;
            this.tb_Duration.Text = "PT60M";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "begintime:";
            // 
            // tb_BeginTime
            // 
            this.tb_BeginTime.Location = new System.Drawing.Point(76, 51);
            this.tb_BeginTime.Name = "tb_BeginTime";
            this.tb_BeginTime.Size = new System.Drawing.Size(108, 21);
            this.tb_BeginTime.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "rate:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(76, 24);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(108, 21);
            this.tb_Name.TabIndex = 16;
            this.tb_Name.Text = "DemoTest";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "duration:";
            // 
            // btn_scheduleConf
            // 
            this.btn_scheduleConf.BackColor = System.Drawing.Color.Silver;
            this.btn_scheduleConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_scheduleConf.Location = new System.Drawing.Point(11, 141);
            this.btn_scheduleConf.Name = "btn_scheduleConf";
            this.btn_scheduleConf.Size = new System.Drawing.Size(173, 40);
            this.btn_scheduleConf.TabIndex = 0;
            this.btn_scheduleConf.Text = "scheduleConfEx";
            this.btn_scheduleConf.UseVisualStyleBackColor = false;
            this.btn_scheduleConf.Click += new System.EventHandler(this.btn_scheduleConf_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtConsoleLog);
            this.groupBox2.Location = new System.Drawing.Point(8, 536);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(758, 124);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console_Log";
            // 
            // rtxtConsoleLog
            // 
            this.rtxtConsoleLog.BackColor = System.Drawing.Color.Silver;
            this.rtxtConsoleLog.Location = new System.Drawing.Point(6, 14);
            this.rtxtConsoleLog.Name = "rtxtConsoleLog";
            this.rtxtConsoleLog.ReadOnly = true;
            this.rtxtConsoleLog.Size = new System.Drawing.Size(746, 103);
            this.rtxtConsoleLog.TabIndex = 0;
            this.rtxtConsoleLog.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Conference Id:";
            // 
            // txt_confId
            // 
            this.txt_confId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_confId.Location = new System.Drawing.Point(111, 346);
            this.txt_confId.Name = "txt_confId";
            this.txt_confId.ReadOnly = true;
            this.txt_confId.Size = new System.Drawing.Size(100, 21);
            this.txt_confId.TabIndex = 18;
            // 
            // dgw_ConfSitesList
            // 
            this.dgw_ConfSitesList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgw_ConfSitesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_ConfSitesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgw_ConfSitesList.Location = new System.Drawing.Point(9, 20);
            this.dgw_ConfSitesList.Name = "dgw_ConfSitesList";
            this.dgw_ConfSitesList.RowHeadersVisible = false;
            this.dgw_ConfSitesList.RowTemplate.Height = 23;
            this.dgw_ConfSitesList.Size = new System.Drawing.Size(334, 179);
            this.dgw_ConfSitesList.TabIndex = 19;
            // 
            // btn_addSiteToConf
            // 
            this.btn_addSiteToConf.BackColor = System.Drawing.Color.Silver;
            this.btn_addSiteToConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addSiteToConf.Location = new System.Drawing.Point(361, 20);
            this.btn_addSiteToConf.Name = "btn_addSiteToConf";
            this.btn_addSiteToConf.Size = new System.Drawing.Size(176, 40);
            this.btn_addSiteToConf.TabIndex = 20;
            this.btn_addSiteToConf.Text = "addSiteToConfEx";
            this.btn_addSiteToConf.UseVisualStyleBackColor = false;
            this.btn_addSiteToConf.Click += new System.EventHandler(this.btn_addSiteToConf_Click);
            // 
            // btn_delSiteFromConfEx
            // 
            this.btn_delSiteFromConfEx.BackColor = System.Drawing.Color.Silver;
            this.btn_delSiteFromConfEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delSiteFromConfEx.Location = new System.Drawing.Point(361, 66);
            this.btn_delSiteFromConfEx.Name = "btn_delSiteFromConfEx";
            this.btn_delSiteFromConfEx.Size = new System.Drawing.Size(176, 40);
            this.btn_delSiteFromConfEx.TabIndex = 21;
            this.btn_delSiteFromConfEx.Text = "delSiteFromConfEx";
            this.btn_delSiteFromConfEx.UseVisualStyleBackColor = false;
            this.btn_delSiteFromConfEx.Click += new System.EventHandler(this.btn_delSiteFromConfEx_Click);
            // 
            // btn_connectSitesEx
            // 
            this.btn_connectSitesEx.BackColor = System.Drawing.Color.Silver;
            this.btn_connectSitesEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connectSitesEx.Location = new System.Drawing.Point(361, 112);
            this.btn_connectSitesEx.Name = "btn_connectSitesEx";
            this.btn_connectSitesEx.Size = new System.Drawing.Size(176, 40);
            this.btn_connectSitesEx.TabIndex = 22;
            this.btn_connectSitesEx.Text = "connectSitesEx";
            this.btn_connectSitesEx.UseVisualStyleBackColor = false;
            this.btn_connectSitesEx.Click += new System.EventHandler(this.btn_connectSitesEx_Click);
            // 
            // btn_disconnectSitesEx
            // 
            this.btn_disconnectSitesEx.BackColor = System.Drawing.Color.Silver;
            this.btn_disconnectSitesEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_disconnectSitesEx.Location = new System.Drawing.Point(361, 158);
            this.btn_disconnectSitesEx.Name = "btn_disconnectSitesEx";
            this.btn_disconnectSitesEx.Size = new System.Drawing.Size(176, 40);
            this.btn_disconnectSitesEx.TabIndex = 23;
            this.btn_disconnectSitesEx.Text = "disconnectSitesEx";
            this.btn_disconnectSitesEx.UseVisualStyleBackColor = false;
            this.btn_disconnectSitesEx.Click += new System.EventHandler(this.btn_disconnectSitesEx_Click);
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "checked";
            this.Column10.FalseValue = "0";
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            this.Column10.TrueValue = "1";
            this.Column10.Width = 30;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "siteURI";
            this.Column7.HeaderText = "URI";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "siteName";
            this.Column8.HeaderText = "Name";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "siteType";
            this.Column9.HeaderText = "Type";
            this.Column9.Name = "Column9";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgw_ConfSitesList);
            this.groupBox3.Controls.Add(this.btn_disconnectSitesEx);
            this.groupBox3.Controls.Add(this.btn_addSiteToConf);
            this.groupBox3.Controls.Add(this.btn_connectSitesEx);
            this.groupBox3.Controls.Add(this.btn_delSiteFromConfEx);
            this.groupBox3.Location = new System.Drawing.Point(223, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 210);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "conference sites list";
            // 
            // Conference_Sites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 665);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txt_confId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoginManagement);
            this.Name = "Conference_Sites";
            this.Text = "Conference_Sites";
            this.LoginManagement.ResumeLayout(false);
            this.LoginManagement.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_ConfSitesList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridView siteGridView;
        private System.Windows.Forms.Button btn_QuerySiteList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_scheduleConf;
        private System.Windows.Forms.TextBox tb_Rate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Duration;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_BeginTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtxtConsoleLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_confId;
        private System.Windows.Forms.DataGridView dgw_ConfSitesList;
        private System.Windows.Forms.Button btn_addSiteToConf;
        private System.Windows.Forms.Button btn_delSiteFromConfEx;
        private System.Windows.Forms.Button btn_connectSitesEx;
        private System.Windows.Forms.Button btn_disconnectSitesEx;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

