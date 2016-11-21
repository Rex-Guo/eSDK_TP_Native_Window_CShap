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
    partial class SiteStatus
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_beginTime = new System.Windows.Forms.TextBox();
            this.lb_SiteURI = new System.Windows.Forms.ListBox();
            this.del_Site = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.add_Site = new System.Windows.Forms.Button();
            this.tb_SiteURI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Duration = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Duration);
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_beginTime);
            this.groupBox1.Controls.Add(this.lb_SiteURI);
            this.groupBox1.Controls.Add(this.del_Site);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.add_Site);
            this.groupBox1.Controls.Add(this.tb_SiteURI);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 224);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会场列表";
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(236, 174);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 30);
            this.OK_Button.TabIndex = 7;
            this.OK_Button.Text = "确认";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "开始时间：";
            // 
            // tb_beginTime
            // 
            this.tb_beginTime.Location = new System.Drawing.Point(192, 101);
            this.tb_beginTime.Name = "tb_beginTime";
            this.tb_beginTime.Size = new System.Drawing.Size(119, 21);
            this.tb_beginTime.TabIndex = 6;
            // 
            // lb_SiteURI
            // 
            this.lb_SiteURI.FormattingEnabled = true;
            this.lb_SiteURI.ItemHeight = 12;
            this.lb_SiteURI.Location = new System.Drawing.Point(6, 20);
            this.lb_SiteURI.Name = "lb_SiteURI";
            this.lb_SiteURI.Size = new System.Drawing.Size(120, 184);
            this.lb_SiteURI.TabIndex = 0;
            // 
            // del_Site
            // 
            this.del_Site.Location = new System.Drawing.Point(241, 51);
            this.del_Site.Name = "del_Site";
            this.del_Site.Size = new System.Drawing.Size(70, 30);
            this.del_Site.TabIndex = 4;
            this.del_Site.Text = "删除";
            this.del_Site.UseVisualStyleBackColor = true;
            this.del_Site.Click += new System.EventHandler(this.del_Site_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会场URI：";
            // 
            // add_Site
            // 
            this.add_Site.Location = new System.Drawing.Point(165, 51);
            this.add_Site.Name = "add_Site";
            this.add_Site.Size = new System.Drawing.Size(70, 30);
            this.add_Site.TabIndex = 3;
            this.add_Site.Text = "添加";
            this.add_Site.UseVisualStyleBackColor = true;
            this.add_Site.Click += new System.EventHandler(this.add_Site_Click);
            // 
            // tb_SiteURI
            // 
            this.tb_SiteURI.Location = new System.Drawing.Point(195, 21);
            this.tb_SiteURI.Name = "tb_SiteURI";
            this.tb_SiteURI.Size = new System.Drawing.Size(116, 21);
            this.tb_SiteURI.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "时间间隔：";
            // 
            // tb_Duration
            // 
            this.tb_Duration.Location = new System.Drawing.Point(192, 134);
            this.tb_Duration.Name = "tb_Duration";
            this.tb_Duration.Size = new System.Drawing.Size(119, 21);
            this.tb_Duration.TabIndex = 9;
            this.tb_Duration.Text = "P0Y0M0DT1H0M0.000S";
            // 
            // SiteStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 240);
            this.Controls.Add(this.groupBox1);
            this.Name = "SiteStatus";
            this.Text = "SiteStatus";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Duration;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_beginTime;
        private System.Windows.Forms.ListBox lb_SiteURI;
        private System.Windows.Forms.Button del_Site;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_Site;
        private System.Windows.Forms.TextBox tb_SiteURI;
    }
}