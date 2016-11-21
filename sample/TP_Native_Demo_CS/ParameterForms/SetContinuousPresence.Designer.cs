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
    partial class SetContinuousPresence
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
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_confID = new System.Windows.Forms.TextBox();
            this.lb_SiteURI = new System.Windows.Forms.ListBox();
            this.del_Site = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.add_Site = new System.Windows.Forms.Button();
            this.tb_SiteURI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_confID);
            this.groupBox1.Controls.Add(this.lb_SiteURI);
            this.groupBox1.Controls.Add(this.del_Site);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.add_Site);
            this.groupBox1.Controls.Add(this.tb_SiteURI);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 257);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会场列表";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "多画面标识：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0~49的值"});
            this.comboBox1.Location = new System.Drawing.Point(210, 171);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 20);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "多画面模式：";
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(221, 221);
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
            this.label2.Location = new System.Drawing.Point(135, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "会议ID：";
            // 
            // tb_confID
            // 
            this.tb_confID.Location = new System.Drawing.Point(193, 101);
            this.tb_confID.Name = "tb_confID";
            this.tb_confID.Size = new System.Drawing.Size(100, 21);
            this.tb_confID.TabIndex = 6;
            // 
            // lb_SiteURI
            // 
            this.lb_SiteURI.FormattingEnabled = true;
            this.lb_SiteURI.ItemHeight = 12;
            this.lb_SiteURI.Location = new System.Drawing.Point(6, 20);
            this.lb_SiteURI.Name = "lb_SiteURI";
            this.lb_SiteURI.Size = new System.Drawing.Size(120, 232);
            this.lb_SiteURI.TabIndex = 0;
            // 
            // del_Site
            // 
            this.del_Site.Location = new System.Drawing.Point(226, 50);
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
            this.label1.Location = new System.Drawing.Point(135, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会场URI：";
            // 
            // add_Site
            // 
            this.add_Site.Location = new System.Drawing.Point(134, 51);
            this.add_Site.Name = "add_Site";
            this.add_Site.Size = new System.Drawing.Size(70, 30);
            this.add_Site.TabIndex = 3;
            this.add_Site.Text = "添加";
            this.add_Site.UseVisualStyleBackColor = true;
            this.add_Site.Click += new System.EventHandler(this.add_Site_Click);
            // 
            // tb_SiteURI
            // 
            this.tb_SiteURI.Location = new System.Drawing.Point(196, 21);
            this.tb_SiteURI.Name = "tb_SiteURI";
            this.tb_SiteURI.Size = new System.Drawing.Size(100, 21);
            this.tb_SiteURI.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "类型:(0-49)";
            // 
            // textBox1
            // 
            this.textBox1.FormattingEnabled = true;
            this.textBox1.Items.AddRange(new object[] {
            "空串：会议多画面",
            "0：第一组或默认的那组多画面",
            "N：第N组多画面"});
            this.textBox1.Location = new System.Drawing.Point(210, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 13;
            // 
            // SetContinuousPresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 280);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetContinuousPresence";
            this.Text = "SetContinuousPresence";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_confID;
        private System.Windows.Forms.ListBox lb_SiteURI;
        private System.Windows.Forms.Button del_Site;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_Site;
        private System.Windows.Forms.TextBox tb_SiteURI;
        private System.Windows.Forms.ComboBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}