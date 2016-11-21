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
    public partial class AdhocConfParameters : Form
    {
        public string[] ConfAccessCodes;
        public DateTime beginTime;
        public string duration;
        
        public string orgId;
        public AdhocConfTemplateParamEx adhocConfTemplate;
        
        public AdhocConfParameters()
        {
            InitializeComponent();
            this.tb_beginTime.Text = DateTime.Now.ToString();
        }

        #region 查询Adhoc会议
        
        private void Query_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lb_AccessCode.Items.Count != 0 && this.tb_beginTime.Text != "" && this.tb_duration.Text != "")
                {
                    this.beginTime = Convert.ToDateTime(this.tb_beginTime.Text.ToString());
                    this.duration = this.tb_duration.Text.ToString();
                    List<string> list = new List<string>();
                    for (int i = 0; i < this.lb_AccessCode.Items.Count; i++)
                    {
                        
                        list.Add(this.lb_AccessCode.Items[i].ToString());
                    }
                    this.ConfAccessCodes = list.ToArray();

                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    throw new Exception("AccessCode list or confID is empty!");
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void add_AccessCode_Click(object sender, EventArgs e)
        {
            if (this.tb_AccessCode.Text != "")
            {
                this.lb_AccessCode.Items.Add(this.tb_AccessCode.Text.ToString());
            }
        }

        private void del_AccessCode_Click(object sender, EventArgs e)
        {
            if (this.tb_AccessCode.Text != "")
            {
                this.lb_AccessCode.Items.Remove(this.tb_AccessCode.Text.ToString());
            }
        }

        #endregion

        #region 添加Adhoc会议
        
        private void Add_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // 会议模板添加到的组织
                this.orgId = this.tb_orgId_Add.Text.ToString();
                
                // Adhoc会议模板参数
                this.adhocConfTemplate = new AdhocConfTemplateParamEx();
                // Adhoc模板ID, 新增时为0
                adhocConfTemplate.adhocConfTemplateId = this.tb_TemplateId_Add.Text.ToString();
                // 会议模板名称
                adhocConfTemplate.name = this.tb_TemplateName_Add.Text.ToString();
                // 会议激活号码
                adhocConfTemplate.accessCode = this.tb_AccessCode_Add.Text.ToString();
                adhocConfTemplate.duration = this.tb_Duration_Add.Text.ToString();
                // 计费码
                adhocConfTemplate.billCode = this.tb_billcode_Add.Text.ToString();
                //
                adhocConfTemplate.password = this.tb_Password_Add.Text.ToString();
                // 多画面资源数
                adhocConfTemplate.cpResource = Convert.ToInt32(this.tb_cpResource_Add.Text.ToString());
                // 速率
                adhocConfTemplate.rate = this.tb_Rate_Add.Text.ToString();
                // 媒体流加密方式，0：自动协商是否使用加密
                adhocConfTemplate.mediaEncryptType = Convert.ToInt32(this.tb_mediaEncryptType_Add.Text.ToString());
                // 是否支持直播功能, 0：不支持 1：支持
                adhocConfTemplate.isLiveBroadcast = Convert.ToInt32(this.tb_isLiveBroadcast_Add.Text.ToString());
                // 是否支持录播功能, 0：不支持 1：支持
                adhocConfTemplate.isRecording = Convert.ToInt32(this.tb_isRecording_Add.Text.ToString());
                // 胶片演示方式
                adhocConfTemplate.presentation = 0;
                // 辅流视频参数
                VideoParamEx videoParam = new VideoParamEx();
                // 视频协议为H.261协议
                videoParam.protocol = 1;
                // 视频格式为Auto
                videoParam.format = 0;
                adhocConfTemplate.presentationVideo = videoParam;
                // 会议主会场
                //adhocConfTemplate.mainSiteUri = "01033001";
                // 会议通知信息
                ConferenceNoticeEx notice = new ConferenceNoticeEx();
                // 邮箱地址
                notice.email = "abc@huawei.com";
                // 通知信息内容
                notice.content = "0";
                // 电话号码
                notice.telephone = "051269993940";
                adhocConfTemplate.notice = notice;

                List<SiteInfoEx> sites = new List<SiteInfoEx>();
                //新建一个SiteInfoEx对象 
                SiteInfoEx siteInfo1 = new SiteInfoEx();
                //会场URI为01033001 
                siteInfo1.uri = this.tb_Site1_URI_Add.Text.ToString();
                //会场速率为1920k 
                siteInfo1.rate = this.tb_Site1_Rate_Add.Text.ToString();
                //会场名称为site1 
                siteInfo1.name = this.tb_Site1_Name_Add.Text.ToString();
                //呼叫方式为MCU主动呼叫会场 
                siteInfo1.dialingMode = Convert.ToInt32(this.tb_Site1_Call_Add.Text.ToString());
                //会场来源为内部会场 
                siteInfo1.from = Convert.ToInt32(this.tb_Site1_Come_Add.Text.ToString());
                //会场类型为H.323会场类型 
                siteInfo1.type = Convert.ToInt32(this.tb_Site1_Type_Add.Text.ToString());
                //会场视频格式为Auto 
                siteInfo1.videoFormat = Convert.ToInt32(this.tb_Site1_VF_Add.Text.ToString());
                //会场视频协议为H.261 
                siteInfo1.videoProtocol = Convert.ToInt32(this.tb_Site1_VP_Add.Text.ToString()); ;
                //预约会议需要两个以上会场，所以再新建一个会场  
                SiteInfoEx siteInfo2 = new SiteInfoEx();
                siteInfo2.uri = this.tb_Site2_URI_Add.Text.ToString();
                siteInfo2.rate = this.tb_Site2_Rate_Add.Text.ToString();
                siteInfo2.name = this.tb_Site2_Name_Add.Text.ToString();
                siteInfo2.dialingMode = Convert.ToInt32(this.tb_Site2_Call_Add.Text.ToString());
                siteInfo2.from = Convert.ToInt32(this.tb_Site2_Come_Add.Text.ToString());
                siteInfo2.type = Convert.ToInt32(this.tb_Site2_Type_Add.Text.ToString());
                siteInfo2.videoFormat = Convert.ToInt32(this.tb_Site2_VF_Add.Text.ToString());
                siteInfo2.videoProtocol = Convert.ToInt32(this.tb_Site2_VP_Add.Text.ToString());
                //向会议模板中添加会场 
                sites.Add(siteInfo1);
                sites.Add(siteInfo2);
                SiteInfoEx[] site = sites.ToArray();
                adhocConfTemplate.sites = site;

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        
        #endregion

        #region 编辑Adhoc会议
        
        private void edit_Button_Click(object sender, EventArgs e)
        {
            try
            {

                // Adhoc会议模板参数
                this.adhocConfTemplate = new AdhocConfTemplateParamEx();
                // Adhoc模板ID, 新增时为0
                adhocConfTemplate.adhocConfTemplateId = this.tb_TemplateId_Edit.Text.ToString();
                // 会议模板名称
                adhocConfTemplate.name = this.tb_TemplateName_Edit.Text.ToString();
                // 会议激活号码
                adhocConfTemplate.accessCode = this.tb_AccessCode_Edit.Text.ToString();
                adhocConfTemplate.duration = this.tb_Duration_Edit.Text.ToString();
                // 计费码
                adhocConfTemplate.billCode = this.tb_billcode_Edit.Text.ToString();
                //
                adhocConfTemplate.password = this.tb_Password_Edit.Text.ToString();
                // 多画面资源数
                adhocConfTemplate.cpResource = Convert.ToInt32(this.tb_cpResource_Edit.Text.ToString());
                // 速率
                adhocConfTemplate.rate = this.tb_Rate_Edit.Text.ToString();
                // 媒体流加密方式，0：自动协商是否使用加密
                adhocConfTemplate.mediaEncryptType = Convert.ToInt32(this.tb_mediaEncryptType_Edit.Text.ToString());
                // 是否支持直播功能, 0：不支持 1：支持
                adhocConfTemplate.isLiveBroadcast = Convert.ToInt32(this.tb_isLiveBroadcast_Edit.Text.ToString());
                // 是否支持录播功能, 0：不支持 1：支持
                adhocConfTemplate.isRecording = Convert.ToInt32(this.tb_isRecording_Edit.Text.ToString());
                // 胶片演示方式
                adhocConfTemplate.presentation = 0;
                // 辅流视频参数
                VideoParamEx videoParam = new VideoParamEx();
                // 视频协议为H.261协议
                videoParam.protocol = 1;
                // 视频格式为Auto
                videoParam.format = 0;
                adhocConfTemplate.presentationVideo = videoParam;
                // 会议主会场
                //adhocConfTemplate.mainSiteUri = "01033001";
                // 会议通知信息
                ConferenceNoticeEx notice = new ConferenceNoticeEx();
                // 邮箱地址
                notice.email = "abc@huawei.com";
                // 通知信息内容
                notice.content = "0";
                // 电话号码
                notice.telephone = "051269993940";
                adhocConfTemplate.notice = notice;

                List<SiteInfoEx> sites = new List<SiteInfoEx>();
                //新建一个SiteInfoEx对象 
                SiteInfoEx siteInfo1 = new SiteInfoEx();
                //会场URI为01033001 
                siteInfo1.uri = this.tb_Site1_URI_Edit.Text.ToString();
                //会场速率为1920k 
                siteInfo1.rate = this.tb_Site1_Rate_Edit.Text.ToString();
                //会场名称为site1 
                siteInfo1.name = this.tb_Site1_Name_Edit.Text.ToString();
                //呼叫方式为MCU主动呼叫会场 
                siteInfo1.dialingMode = Convert.ToInt32(this.tb_Site1_Call_Edit.Text.ToString());
                //会场来源为内部会场 
                siteInfo1.from = Convert.ToInt32(this.tb_Site1_Come_Edit.Text.ToString());
                //会场类型为H.323会场类型 
                siteInfo1.type = Convert.ToInt32(this.tb_Site1_Type_Edit.Text.ToString());
                //会场视频格式为Auto 
                siteInfo1.videoFormat = Convert.ToInt32(this.tb_Site1_VF_Edit.Text.ToString());
                //会场视频协议为H.261 
                siteInfo1.videoProtocol = Convert.ToInt32(this.tb_Site1_VP_Edit.Text.ToString()); ;
                //预约会议需要两个以上会场，所以再新建一个会场  
                SiteInfoEx siteInfo2 = new SiteInfoEx();
                siteInfo2.uri = this.tb_Site2_URI_Edit.Text.ToString();
                siteInfo2.rate = this.tb_Site2_Rate_Edit.Text.ToString();
                siteInfo2.name = this.tb_Site2_Name_Edit.Text.ToString();
                siteInfo2.dialingMode = Convert.ToInt32(this.tb_Site2_Call_Edit.Text.ToString());
                siteInfo2.from = Convert.ToInt32(this.tb_Site2_Come_Edit.Text.ToString());
                siteInfo2.type = Convert.ToInt32(this.tb_Site2_Type_Edit.Text.ToString());
                siteInfo2.videoFormat = Convert.ToInt32(this.tb_Site2_VF_Edit.Text.ToString());
                siteInfo2.videoProtocol = Convert.ToInt32(this.tb_Site2_VP_Edit.Text.ToString());
                //向会议模板中添加会场 
                sites.Add(siteInfo1);
                sites.Add(siteInfo2);
                SiteInfoEx[] site = sites.ToArray();
                adhocConfTemplate.sites = site;

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region 删除Adhoc会议
        
        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tb_TemplateId_Delete.Text != "")
                {
                    this.adhocConfTemplate = new AdhocConfTemplateParamEx();
                    adhocConfTemplate.adhocConfTemplateId = this.tb_TemplateId_Delete.Text.ToString();
                }
                else
                {
                    throw new Exception("The adhocConfTemplateId is empty");
                }

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

    }
}
