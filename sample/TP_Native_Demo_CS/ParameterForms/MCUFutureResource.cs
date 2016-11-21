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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;

namespace TP_Native_Demo.ParameterForms
{
    public partial class MCUFutureResource : Form
    {

        public int[] mcus;
        public DateTime begintime;
        public string duration;

        public MCUFutureResource()
        {
            InitializeComponent();
            this.tb_beginTime.Text = DateTime.Now.ToString();
        }

        private void OK_Button_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.lb_mcuId.Items.Count != 0 && this.tb_duration.Text != "")
                {
                    this.duration = this.tb_duration.Text.ToString();
                    List<int> list = new List<int>();
                    for (int i = 0; i < this.lb_mcuId.Items.Count; i++)
                    {
                        list.Add(Convert.ToInt32(lb_mcuId.Items[i].ToString()));
                    }
                    this.mcus = list.ToArray();
                }
                else
                {
                    throw new Exception("some object is null!");
                }
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void add_Site_Click_1(object sender, EventArgs e)
        {
            if (this.tb_mucId.Text != string.Empty && this.tb_beginTime.Text != string.Empty)
            {
                this.lb_mcuId.Items.Add(this.tb_mucId.Text.ToString());
            }
        }

        private void del_Site_Click_1(object sender, EventArgs e)
        {
            if (this.tb_mucId.Text != string.Empty)
            {
                this.lb_mcuId.Items.Remove(this.tb_mucId.Text.ToString());
            }
        }
    }
}
