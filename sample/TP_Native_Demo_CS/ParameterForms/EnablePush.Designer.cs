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
    partial class EnablePush
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
            this.cb_pushMode = new System.Windows.Forms.ComboBox();
            this.tb_extendParam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OK_Button);
            this.groupBox1.Controls.Add(this.cb_pushMode);
            this.groupBox1.Controls.Add(this.tb_extendParam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 155);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "推送参数";
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(54, 119);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 30);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "确认";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // cb_pushMode
            // 
            this.cb_pushMode.FormattingEnabled = true;
            this.cb_pushMode.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "推送方式",
            "0：NONE",
            "1：PULL",
            "2：CALLBACK"});
            this.cb_pushMode.Location = new System.Drawing.Point(71, 28);
            this.cb_pushMode.Name = "cb_pushMode";
            this.cb_pushMode.Size = new System.Drawing.Size(100, 20);
            this.cb_pushMode.TabIndex = 4;
            this.cb_pushMode.Text = "0";
            // 
            // tb_extendParam
            // 
            this.tb_extendParam.Location = new System.Drawing.Point(71, 66);
            this.tb_extendParam.Name = "tb_extendParam";
            this.tb_extendParam.Size = new System.Drawing.Size(100, 21);
            this.tb_extendParam.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "扩展参数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "推送方式：";
            // 
            // EnablePush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 179);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnablePush";
            this.Text = "EnablePush";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_pushMode;
        private System.Windows.Forms.TextBox tb_extendParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK_Button;

    }
}