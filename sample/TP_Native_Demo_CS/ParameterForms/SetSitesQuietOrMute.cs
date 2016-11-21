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

namespace TP_Native_Demo.ParameterForms
{
    public partial class SetSitesQuietOrMute : Form
    {
        public string conf_ID;
        public List<string> list;
        public int isMuteOrQuiet;

        public SetSitesQuietOrMute()
        {
            InitializeComponent();
        }

        private void add_Site_Click_1(object sender, EventArgs e)
        {
            if (this.tb_SiteURI.Text != "")
            {
                this.lb_SiteURI.Items.Add(this.tb_SiteURI.Text.ToString());
            }
        }

        private void del_Site_Click_1(object sender, EventArgs e)
        {
            if (this.tb_SiteURI.Text != "")
            {
                this.lb_SiteURI.Items.Remove(this.tb_SiteURI.Text.ToString());
            }
        }

        private void OK_Button_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.lb_SiteURI.Items.Count != 0 && this.tb_confID.Text != "")
                {
                    this.conf_ID = this.tb_confID.Text.ToString();
                    this.isMuteOrQuiet = Convert.ToInt32(this.comboBox1.Text.ToString());
                    this.list = new List<string>();
                    for (int i = 0; i < this.lb_SiteURI.Items.Count; i++)
                    {
                        this.list.Add(this.lb_SiteURI.Items[i].ToString());
                    }
                }
                else
                {
                    throw new Exception("siteURI list or confID is empty!");
                }
                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

    }
}
