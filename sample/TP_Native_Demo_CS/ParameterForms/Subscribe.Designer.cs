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
    partial class Subscribe
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
            this.cb_Subscrib = new System.Windows.Forms.ComboBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_ConferenceID = new System.Windows.Forms.ListBox();
            this.del_ID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.add_ID = new System.Windows.Forms.Button();
            this.tb_confID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Subscrib);
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_ConferenceID);
            this.groupBox1.Controls.Add(this.del_ID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.add_ID);
            this.groupBox1.Controls.Add(this.tb_confID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 225);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会议ID列表";
            // 
            // cb_Subscrib
            // 
            this.cb_Subscrib.FormattingEnabled = true;
            this.cb_Subscrib.Items.AddRange(new object[] {
            "0",
            "1",
            "描述",
            "0：取消订阅",
            "1：订阅"});
            this.cb_Subscrib.Location = new System.Drawing.Point(198, 102);
            this.cb_Subscrib.Name = "cb_Subscrib";
            this.cb_Subscrib.Size = new System.Drawing.Size(100, 20);
            this.cb_Subscrib.TabIndex = 8;
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(226, 181);
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
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "订阅标记：";
            // 
            // lb_ConferenceID
            // 
            this.lb_ConferenceID.FormattingEnabled = true;
            this.lb_ConferenceID.ItemHeight = 12;
            this.lb_ConferenceID.Location = new System.Drawing.Point(6, 20);
            this.lb_ConferenceID.Name = "lb_ConferenceID";
            this.lb_ConferenceID.Size = new System.Drawing.Size(120, 184);
            this.lb_ConferenceID.TabIndex = 0;
            // 
            // del_ID
            // 
            this.del_ID.Location = new System.Drawing.Point(229, 50);
            this.del_ID.Name = "del_ID";
            this.del_ID.Size = new System.Drawing.Size(70, 30);
            this.del_ID.TabIndex = 4;
            this.del_ID.Text = "删除";
            this.del_ID.UseVisualStyleBackColor = true;
            this.del_ID.Click += new System.EventHandler(this.del_ID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会议ID：";
            // 
            // add_ID
            // 
            this.add_ID.Location = new System.Drawing.Point(134, 51);
            this.add_ID.Name = "add_ID";
            this.add_ID.Size = new System.Drawing.Size(70, 30);
            this.add_ID.TabIndex = 3;
            this.add_ID.Text = "添加";
            this.add_ID.UseVisualStyleBackColor = true;
            this.add_ID.Click += new System.EventHandler(this.add_ID_Click);
            // 
            // tb_confID
            // 
            this.tb_confID.Location = new System.Drawing.Point(198, 21);
            this.tb_confID.Name = "tb_confID";
            this.tb_confID.Size = new System.Drawing.Size(100, 21);
            this.tb_confID.TabIndex = 2;
            // 
            // Subscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 247);
            this.Controls.Add(this.groupBox1);
            this.Name = "Subscribe";
            this.Text = "Subscribe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_ConferenceID;
        private System.Windows.Forms.Button del_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_ID;
        private System.Windows.Forms.TextBox tb_confID;
        private System.Windows.Forms.ComboBox cb_Subscrib;
    }
}