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
    public partial class SetAudioSwitch : Form
    {
        public string confid;
        public int swtichGate;
        public int isSwitch;
        
        public SetAudioSwitch()
        {
            InitializeComponent();
        }

        private void set_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.groupBox1);

                this.confid = this.textBox1.Text.ToString();
                this.swtichGate =Convert.ToInt32(this.textBox2.Text.ToString());
                this.isSwitch = Convert.ToInt32(this.comboBox1.Text.ToString());

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
