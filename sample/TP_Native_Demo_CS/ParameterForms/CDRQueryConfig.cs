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
    public partial class CDRQueryConfig : Form
    {
        public MultiPointCDRQueryConfigEx MultiPoint_queryConfig;
        public PointToPointCDRQueryConfigEx PointToPoint_queryConfig;
        
        public CDRQueryConfig()
        {
            InitializeComponent();
            this.tb_beginTime.Text = DateTime.Now.ToString();
        }

        private void query_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.groupBox1);

                this.MultiPoint_queryConfig = new MultiPointCDRQueryConfigEx();
                this.PointToPoint_queryConfig = new PointToPointCDRQueryConfigEx();
                //页面配置
                PageParamEx pageParam = new PageParamEx();
                pageParam.numberPerPage = Convert.ToInt32(this.tb_numberPerPage.Text.ToString());
                pageParam.currentPage = Convert.ToInt32(this.tb_currentPage.Text.ToString());
                //PointToPoint查询
                this.PointToPoint_queryConfig.beginTime = Convert.ToDateTime(this.tb_beginTime.Text.ToString());
                this.PointToPoint_queryConfig.duration = this.tb_Duration.Text.ToString();
                this.PointToPoint_queryConfig.pageParam = pageParam;
                //MultiPoint查询
                this.MultiPoint_queryConfig.beginTime = Convert.ToDateTime(this.tb_beginTime.Text.ToString());
                this.MultiPoint_queryConfig.duration = this.tb_Duration.Text.ToString();
                this.MultiPoint_queryConfig.pageParam = pageParam;
                this.MultiPoint_queryConfig.siteUri = this.tb_siteURI.Text.ToString();

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

    }
}
