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
    public partial class SiteInfo : Form
    {
        public string orgId;
        public TerminalInfoEx siteInfo;
        
        public SiteInfo()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //准备将会场添加到的组织节点ID中
                this.orgId = this.tb_orgId.Text.ToString();
                //准备添加的会场数据
                this.siteInfo = new TerminalInfoEx();
                //会场名称
                siteInfo.name = this.tb_Site1_Name.Text.ToString();
                //会场标识
                siteInfo.uri = this.tb_Site1_URI.Text.ToString();
                //会场类型
                siteInfo.type = Convert.ToInt32(this.tb_Site1_Type.Text.ToString());
                //速率。格式为“速率值k/M”，如“1920k”。默认由系统自动选择
                siteInfo.rate = this.tb_Site1_Rate.Text.ToString();
                //（可选）H.323、SIP协议会场注册SC的用户名
                //siteInfo.regUser = "eSDK_test";
                siteInfo.regUser = this.textBox1.Text.ToString();
                //（可选）H.323、SIP协议会场注册SC的密码
                //siteInfo.regPassword = "Huawei@123";
                siteInfo.regPassword = this.textBox2.Text.ToString();
                //（可选）终端支持的视频能力参数列表。如果不填，则认为支持所有视频
                VideoCapbilityItemEx vc = new VideoCapbilityItemEx();
                int[] vf = { Convert.ToInt32(this.tb_Site1_VF.Text.ToString()) };
                //视频协议对应的视频格式列表
                vc.videoFormat = vf;
                //视频协议
                vc.videoProtocol = Convert.ToInt32(this.tb_Site1_VP.Text.ToString());
                VideoCapbilityItemEx[] videoCapbility = { vc };               
                siteInfo.videoCapbility = videoCapbility;

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
