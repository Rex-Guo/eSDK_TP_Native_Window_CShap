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
    public partial class CameraControl : Form
    {
        public CameraControlEx cameraConrtrol;
        public string siteURI;
        
        public CameraControl()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.groupBox1);
                
                cameraConrtrol = new CameraControlEx();
                cameraConrtrol.camState = Convert.ToInt32(this.comboBox1.Text.ToString());
                cameraConrtrol.camAction = Convert.ToInt32(this.textBox1.Text.ToString());
                cameraConrtrol.camPos = Convert.ToInt32(this.textBox2.Text.ToString());
                cameraConrtrol.camSrc = Convert.ToInt32(this.textBox3.Text.ToString());

                this.siteURI = this.textBox4.Text.ToString();

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
