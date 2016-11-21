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
    partial class MCUFutureResource
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
            this.label3 = new System.Windows.Forms.Label();
            this.tb_beginTime = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_duration = new System.Windows.Forms.TextBox();
            this.lb_mcuId = new System.Windows.Forms.ListBox();
            this.del_Site = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.add_Site = new System.Windows.Forms.Button();
            this.tb_mucId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_beginTime);
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_duration);
            this.groupBox1.Controls.Add(this.lb_mcuId);
            this.groupBox1.Controls.Add(this.del_Site);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.add_Site);
            this.groupBox1.Controls.Add(this.tb_mucId);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 215);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MUC ID 列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "开始时间：";
            // 
            // tb_beginTime
            // 
            this.tb_beginTime.Location = new System.Drawing.Point(201, 88);
            this.tb_beginTime.Name = "tb_beginTime";
            this.tb_beginTime.Size = new System.Drawing.Size(134, 21);
            this.tb_beginTime.TabIndex = 11;
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(260, 174);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 30);
            this.OK_Button.TabIndex = 7;
            this.OK_Button.Text = "确认";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "时间间隔：";
            // 
            // tb_duration
            // 
            this.tb_duration.Location = new System.Drawing.Point(200, 124);
            this.tb_duration.Name = "tb_duration";
            this.tb_duration.Size = new System.Drawing.Size(135, 21);
            this.tb_duration.TabIndex = 6;
            this.tb_duration.Text = "PT1H";
            // 
            // lb_mcuId
            // 
            this.lb_mcuId.FormattingEnabled = true;
            this.lb_mcuId.ItemHeight = 12;
            this.lb_mcuId.Location = new System.Drawing.Point(6, 20);
            this.lb_mcuId.Name = "lb_mcuId";
            this.lb_mcuId.Size = new System.Drawing.Size(120, 184);
            this.lb_mcuId.TabIndex = 0;
            // 
            // del_Site
            // 
            this.del_Site.Location = new System.Drawing.Point(265, 48);
            this.del_Site.Name = "del_Site";
            this.del_Site.Size = new System.Drawing.Size(70, 30);
            this.del_Site.TabIndex = 4;
            this.del_Site.Text = "删除";
            this.del_Site.UseVisualStyleBackColor = true;
            this.del_Site.Click += new System.EventHandler(this.del_Site_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "MCU ID：";
            // 
            // add_Site
            // 
            this.add_Site.Location = new System.Drawing.Point(189, 48);
            this.add_Site.Name = "add_Site";
            this.add_Site.Size = new System.Drawing.Size(70, 30);
            this.add_Site.TabIndex = 3;
            this.add_Site.Text = "添加";
            this.add_Site.UseVisualStyleBackColor = true;
            this.add_Site.Click += new System.EventHandler(this.add_Site_Click_1);
            // 
            // tb_mucId
            // 
            this.tb_mucId.Location = new System.Drawing.Point(200, 21);
            this.tb_mucId.Name = "tb_mucId";
            this.tb_mucId.Size = new System.Drawing.Size(135, 21);
            this.tb_mucId.TabIndex = 2;
            // 
            // MCUFutureResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 239);
            this.Controls.Add(this.groupBox1);
            this.Name = "MCUFutureResource";
            this.Text = "MCUFutureResource";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_beginTime;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_duration;
        private System.Windows.Forms.ListBox lb_mcuId;
        private System.Windows.Forms.Button del_Site;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_Site;
        private System.Windows.Forms.TextBox tb_mucId;
    }
}