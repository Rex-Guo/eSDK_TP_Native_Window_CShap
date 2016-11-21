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
    partial class CDRQueryConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_beginTime = new System.Windows.Forms.TextBox();
            this.tb_Duration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_siteURI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_numberPerPage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_currentPage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.query_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tb_siteURI);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_Duration);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_beginTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询开始时间：";
            // 
            // tb_beginTime
            // 
            this.tb_beginTime.Location = new System.Drawing.Point(123, 29);
            this.tb_beginTime.Name = "tb_beginTime";
            this.tb_beginTime.Size = new System.Drawing.Size(147, 21);
            this.tb_beginTime.TabIndex = 1;
            // 
            // tb_Duration
            // 
            this.tb_Duration.Location = new System.Drawing.Point(123, 83);
            this.tb_Duration.Name = "tb_Duration";
            this.tb_Duration.Size = new System.Drawing.Size(147, 21);
            this.tb_Duration.TabIndex = 3;
            this.tb_Duration.Text = "PT2H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询时间间隔：";
            // 
            // tb_siteURI
            // 
            this.tb_siteURI.Location = new System.Drawing.Point(123, 133);
            this.tb_siteURI.Name = "tb_siteURI";
            this.tb_siteURI.Size = new System.Drawing.Size(147, 21);
            this.tb_siteURI.TabIndex = 5;
            this.tb_siteURI.Text = "01033001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "指定会场URI(可选)：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_currentPage);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_numberPerPage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 102);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "返回页面设置";
            // 
            // tb_numberPerPage
            // 
            this.tb_numberPerPage.Location = new System.Drawing.Point(110, 24);
            this.tb_numberPerPage.Name = "tb_numberPerPage";
            this.tb_numberPerPage.Size = new System.Drawing.Size(147, 21);
            this.tb_numberPerPage.TabIndex = 5;
            this.tb_numberPerPage.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "每页记录条数：";
            // 
            // tb_currentPage
            // 
            this.tb_currentPage.Location = new System.Drawing.Point(110, 65);
            this.tb_currentPage.Name = "tb_currentPage";
            this.tb_currentPage.Size = new System.Drawing.Size(147, 21);
            this.tb_currentPage.TabIndex = 7;
            this.tb_currentPage.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "返回结果页码：";
            // 
            // query_Button
            // 
            this.query_Button.Location = new System.Drawing.Point(116, 316);
            this.query_Button.Name = "query_Button";
            this.query_Button.Size = new System.Drawing.Size(75, 30);
            this.query_Button.TabIndex = 1;
            this.query_Button.Text = "查询";
            this.query_Button.UseVisualStyleBackColor = true;
            this.query_Button.Click += new System.EventHandler(this.query_Button_Click);
            // 
            // CDRQueryConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 354);
            this.Controls.Add(this.query_Button);
            this.Controls.Add(this.groupBox1);
            this.Name = "CDRQueryConfig";
            this.Text = "CDRQueryConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_siteURI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Duration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_beginTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_currentPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_numberPerPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button query_Button;
    }
}