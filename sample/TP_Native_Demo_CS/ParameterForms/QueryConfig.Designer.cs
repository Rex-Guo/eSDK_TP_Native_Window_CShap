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
    partial class QueryConfig
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
            this.tb_SortIndex = new System.Windows.Forms.ComboBox();
            this.tb_Sort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_currentPage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_numberPerPage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_columnIndex = new System.Windows.Forms.ComboBox();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.query_Button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_focusItem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_SortIndex);
            this.groupBox1.Controls.Add(this.tb_Sort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排序";
            // 
            // tb_SortIndex
            // 
            this.tb_SortIndex.FormattingEnabled = true;
            this.tb_SortIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "描述",
            "0：会场名称",
            "1：会场URI",
            "2：会场状态",
            "3：会场类型",
            "4：会议模板名称",
            "5：会议模板接入号",
            "6：MUC名称"});
            this.tb_SortIndex.Location = new System.Drawing.Point(70, 62);
            this.tb_SortIndex.Name = "tb_SortIndex";
            this.tb_SortIndex.Size = new System.Drawing.Size(102, 20);
            this.tb_SortIndex.TabIndex = 5;
            this.tb_SortIndex.Text = "0";
            // 
            // tb_Sort
            // 
            this.tb_Sort.FormattingEnabled = true;
            this.tb_Sort.Items.AddRange(new object[] {
            "0",
            "1",
            "描述",
            "0：升序",
            "1：降序"});
            this.tb_Sort.Location = new System.Drawing.Point(71, 28);
            this.tb_Sort.Name = "tb_Sort";
            this.tb_Sort.Size = new System.Drawing.Size(101, 20);
            this.tb_Sort.TabIndex = 4;
            this.tb_Sort.Text = "0";
            this.tb_Sort.SelectionChangeCommitted += new System.EventHandler(this.tb_Sort_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据标识：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "排序方式：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_currentPage);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_numberPerPage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "页面设置";
            // 
            // tb_currentPage
            // 
            this.tb_currentPage.Location = new System.Drawing.Point(104, 60);
            this.tb_currentPage.Name = "tb_currentPage";
            this.tb_currentPage.Size = new System.Drawing.Size(68, 21);
            this.tb_currentPage.TabIndex = 11;
            this.tb_currentPage.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "返回结果页码：";
            // 
            // tb_numberPerPage
            // 
            this.tb_numberPerPage.Location = new System.Drawing.Point(104, 20);
            this.tb_numberPerPage.Name = "tb_numberPerPage";
            this.tb_numberPerPage.Size = new System.Drawing.Size(67, 21);
            this.tb_numberPerPage.TabIndex = 9;
            this.tb_numberPerPage.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "每页记录条数：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_columnIndex);
            this.groupBox3.Controls.Add(this.tb_Value);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(218, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "过滤条件";
            // 
            // tb_columnIndex
            // 
            this.tb_columnIndex.FormattingEnabled = true;
            this.tb_columnIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "描述",
            "0：会场名称",
            "1：会场URI",
            "2：会场状态",
            "3：会场类型",
            "4：会议模板名称",
            "5：会议模板接入号"});
            this.tb_columnIndex.Location = new System.Drawing.Point(68, 20);
            this.tb_columnIndex.Name = "tb_columnIndex";
            this.tb_columnIndex.Size = new System.Drawing.Size(101, 20);
            this.tb_columnIndex.TabIndex = 6;
            this.tb_columnIndex.Text = "1";
            // 
            // tb_Value
            // 
            this.tb_Value.Location = new System.Drawing.Point(69, 56);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(100, 21);
            this.tb_Value.TabIndex = 7;
            this.tb_Value.Text = "VCT2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "字符条件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据标识：";
            // 
            // query_Button
            // 
            this.query_Button.Location = new System.Drawing.Point(167, 229);
            this.query_Button.Name = "query_Button";
            this.query_Button.Size = new System.Drawing.Size(75, 34);
            this.query_Button.TabIndex = 2;
            this.query_Button.Text = "查询";
            this.query_Button.UseVisualStyleBackColor = true;
            this.query_Button.Click += new System.EventHandler(this.query_Button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_focusItem);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(218, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "焦点数据";
            // 
            // tb_focusItem
            // 
            this.tb_focusItem.Location = new System.Drawing.Point(76, 35);
            this.tb_focusItem.Name = "tb_focusItem";
            this.tb_focusItem.Size = new System.Drawing.Size(100, 21);
            this.tb_focusItem.TabIndex = 5;
            this.tb_focusItem.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "焦点数据ID：";
            // 
            // QueryConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 275);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.query_Button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "QueryConfig";
            this.Text = "QueryConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_currentPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_numberPerPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button query_Button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_focusItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox tb_Sort;
        private System.Windows.Forms.ComboBox tb_SortIndex;
        private System.Windows.Forms.ComboBox tb_columnIndex;
    }
}