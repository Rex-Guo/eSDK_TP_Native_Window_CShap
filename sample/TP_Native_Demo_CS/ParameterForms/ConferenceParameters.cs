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
using TP_Native_Demo;
using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;

namespace TP_Native_Demo.ParameterForms
{
    public partial class ConferenceParameter : Form
    {
        
        public ConferenceInfoEx scheduleConf = new ConferenceInfoEx();
        
        public RecurrenceConfInfoEx scheduleCurrenceConf = new RecurrenceConfInfoEx();

        public List<string> list;
        
        public ConferenceParameter()
        {
            InitializeComponent();
            this.tb_BeginTime.Text = DateTime.Now.ToString();
            this.tb_BeginTime_Edit.Text = DateTime.Now.ToString();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.groupBox1);
                
                #region 普通会议
                scheduleConf.name = this.tb_Name.Text.ToString();
                scheduleConf.beginTime = Convert.ToDateTime(this.tb_BeginTime.Text.ToString());
                scheduleConf.duration = this.tb_Duration.Text.ToString();
                scheduleConf.rate = this.tb_Rate.Text.ToString();
                //新建会场
                SiteInfoEx siteInfo1 = new SiteInfoEx();
                //会场URI为01033001 
                siteInfo1.uri = this.tb_Site1_URI.Text.ToString();
                //会场速率为1920K
                siteInfo1.rate = "1920K";
                //会场名称为site1
                siteInfo1.name = this.tb_Site1_Name.Text.ToString();
                //呼叫方式为MCU主动呼叫会场
                siteInfo1.dialingMode = 0;
                //会场来源为内部会场
                siteInfo1.from = 0;
                //会场类型为H.323会场类型
                siteInfo1.type = 4;
                //会场视频格式为4CIF
                siteInfo1.videoFormat = 0;
                //会场视频协议为H.263
                siteInfo1.videoProtocol = 0;
                siteInfo1.isLockVideoSource = 1;
                siteInfo1.participantType = 2;

                SiteInfoEx siteInfo2 = new SiteInfoEx();
                siteInfo2.uri = this.tb_Site2_URI.Text.ToString();
                siteInfo2.name = this.tb_Site2_Name.Text.ToString();
                siteInfo2.rate = "1920K";
                siteInfo2.dialingMode = 0;
                siteInfo2.from = 0;
                siteInfo2.type = 4;
                siteInfo2.videoFormat = 0;
                siteInfo2.videoProtocol = 0;
                siteInfo2.isLockVideoSource = 1;
                siteInfo2.participantType = 2;
                //向会议中添加会场
                SiteInfoEx[] sites = { siteInfo1, siteInfo2 };
                scheduleConf.sites = sites;
                scheduleConf.isRecording = 0;
                scheduleConf.cpResouce = Convert.ToInt32(this.tb_cpResouce_Add.Text.ToString());
                scheduleConf.password = this.tb_PWD_Add.Text.ToString();
                scheduleConf.chairmanPassword = this.tb_chairmanPWD_Add.Text.ToString();
                scheduleConf.mainSiteUri = this.tb_mainSite_Add.Text.ToString();
                //会议通知
                ConferenceNotice conferenceNotice = new ConferenceNotice();
                conferenceNotice.content = "123";
                conferenceNotice.email = "esdk@huawei.com";
                scheduleConf.conferenceNotice = conferenceNotice;
                #endregion

                #region 周期会议
                scheduleCurrenceConf.name = this.tb_Name.Text.ToString();
                scheduleCurrenceConf.beginTime = Convert.ToDateTime(this.tb_BeginTime.Text.ToString());
                scheduleCurrenceConf.duration = this.tb_Duration.Text.ToString();
                scheduleCurrenceConf.rate = this.tb_Rate.Text.ToString();
                
                scheduleCurrenceConf.sites = sites;
                scheduleCurrenceConf.isRecording = 0;
                scheduleCurrenceConf.cpResouce = Convert.ToInt32(this.tb_cpResouce_Add.Text.ToString());
                scheduleCurrenceConf.password = this.tb_PWD_Add.Text.ToString();
                scheduleCurrenceConf.chairmanPassword = this.tb_chairmanPWD_Add.Text.ToString();
                scheduleCurrenceConf.mainSiteUri = this.tb_mainSite_Add.Text.ToString();

                scheduleCurrenceConf.frequency = Convert.ToInt32(this.tb_frequency_Add.Text.ToString());
                scheduleCurrenceConf.interval = Convert.ToInt32(this.tb_Interval_Add.Text.ToString());
                scheduleCurrenceConf.count = Convert.ToInt32(this.tb_Count_Add.Text.ToString());
                scheduleCurrenceConf.timeZone = this.tb_timeZone_Add.Text.ToString();

                #endregion

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void OK_Edit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.groupBox4);

                #region 普通会议
                scheduleConf.confId = this.tb_ConferenceID_Edit.Text.ToString();
                scheduleConf.name = this.tb_Name_Edit.Text.ToString();
                scheduleConf.beginTime = Convert.ToDateTime(this.tb_BeginTime_Edit.Text.ToString());
                scheduleConf.duration = this.tb_Duration_Edit.Text.ToString();
                scheduleConf.rate = this.tb_Rate_Edit.ToString();
                //新建会场
                SiteInfoEx siteInfo1 = new SiteInfoEx();
                //会场URI为01033001 
                siteInfo1.uri = this.tb_Site1_URI_Edit.Text.ToString();
                //会场速率为1920K
                siteInfo1.rate = "1920K";
                //会场名称为site1
                siteInfo1.name = this.tb_Site1_Name_Edit.Text.ToString();
                //呼叫方式为MCU主动呼叫会场
                siteInfo1.dialingMode = 0;
                //会场来源为内部会场
                siteInfo1.from = 0;
                //会场类型为H.323会场类型
                siteInfo1.type = 4;
                //会场视频格式为4CIF
                siteInfo1.videoFormat = 0;
                //会场视频协议为H.263
                siteInfo1.videoProtocol = 0;
                siteInfo1.isLockVideoSource = 1;
                siteInfo1.participantType = 2;

                SiteInfoEx siteInfo2 = new SiteInfoEx();
                siteInfo2.uri = this.tb_Site2_URI_Edit.Text.ToString();
                siteInfo2.name = this.tb_Site2_Name_Edit.Text.ToString();
                siteInfo2.rate = "1920K";
                siteInfo2.dialingMode = 0;
                siteInfo2.from = 0;
                siteInfo2.type = 4;
                siteInfo2.videoFormat = 0;
                siteInfo2.videoProtocol = 0;
                siteInfo2.isLockVideoSource = 1;
                siteInfo2.participantType = 2;

                //向会议中添加会场
                SiteInfoEx[] sites = { siteInfo1, siteInfo2 };
                scheduleConf.sites = sites;
                scheduleConf.cpResouce = Convert.ToInt32(this.tb_cpResouce_Edit.Text.ToString());
                scheduleConf.password = this.tb_PWD_Edit.Text.ToString();
                scheduleConf.chairmanPassword = this.tb_chairmanPWD_Edit.Text.ToString();
                scheduleConf.mainSiteUri = this.tb_mainSite_Edit.Text.ToString();
                #endregion

                #region 周期会议
                scheduleCurrenceConf.confId = this.tb_ConferenceID_Edit.Text.ToString();
                scheduleCurrenceConf.name = this.tb_Name_Edit.Text.ToString();
                scheduleCurrenceConf.beginTime = Convert.ToDateTime(this.tb_BeginTime_Edit.Text.ToString());
                scheduleCurrenceConf.duration = this.tb_Duration_Edit.Text.ToString();
                scheduleCurrenceConf.rate = this.tb_Rate_Edit.ToString();
                
                scheduleCurrenceConf.sites = sites;
                scheduleCurrenceConf.isRecording = 0;
                scheduleCurrenceConf.cpResouce = Convert.ToInt32(this.tb_cpResouce_Edit.Text.ToString());
                scheduleCurrenceConf.password = this.tb_PWD_Edit.Text.ToString();
                scheduleCurrenceConf.chairmanPassword = this.tb_chairmanPWD_Edit.Text.ToString();
                scheduleCurrenceConf.mainSiteUri = this.tb_mainSite_Edit.Text.ToString();

                scheduleCurrenceConf.frequency = Convert.ToInt32(this.tb_frequency_Edit.Text.ToString());
                scheduleCurrenceConf.interval = Convert.ToInt32(this.tb_Interval_Edit.Text.ToString());
                scheduleCurrenceConf.count = Convert.ToInt32(this.tb_Count_Edit.Text.ToString());
                scheduleCurrenceConf.timeZone = this.tb_timeZone_Edit.Text.ToString();
                #endregion

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void OK_Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                HelpHandler help = new HelpHandler();
                help.TextBoxEmptyChecked(this.panel1);

                scheduleConf.confId = this.tb_confID_del.Text.ToString();

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #region 查询
        
        private void OK_Query_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lb_ConferenceID.Items.Count != 0)
                {
                    this.list = new List<string>();
                    for (int i = 0; i < this.lb_ConferenceID.Items.Count; i++)
                    {
                        list.Add(this.lb_ConferenceID.Items[i].ToString());
                    }
                }
                else
                {
                    throw new Exception("The list of conference ID is empty!");
                }
                this.DialogResult = DialogResult.Yes;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void add_confID_Click(object sender, EventArgs e)
        {
            if (this.tb_conferenceID.Text.ToString() != "")
            {
                this.lb_ConferenceID.Items.Add(this.tb_conferenceID.Text.ToString());
            }
        }

        private void del_confID_Click(object sender, EventArgs e)
        {
            if (this.tb_conferenceID.Text.ToString() != "")
            {
                this.lb_ConferenceID.Items.Remove(this.tb_conferenceID.Text.ToString());
            }
        }

        #endregion

        
    }
}
