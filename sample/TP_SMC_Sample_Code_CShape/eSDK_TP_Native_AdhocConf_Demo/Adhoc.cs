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
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using com.huawei.esdk.tp.professional.eSDKPlatformKeyMgrService;
using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;

namespace Adhoc会议模板预约会议
{
    public partial class Adhoc : Form
    {
        AuthorizeServiceEx authorService;
        ConferenceMgrServiceEx cmService;
        public Adhoc()
        {
            InitializeComponent();
            authorService = AuthorizeServiceEx.Instance();
            cmService = ConferenceMgrServiceEx.Instance();
        }

        private void ConsoleLog(string log)
        {
            this.rtxtConsoleLog.AppendText(DateTime.Now.ToString() + ": " + log + "\r\n");
        }

        /// <summary>
        /// 用户登录认证后的保持心跳功能
        /// </summary>
        private System.Timers.Timer timer = null;

        //保持心跳间隔时间40s
        private double aliveTime = 10000;

        //启动线程,使用计时器来完成心跳
        private void KeepAlive_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(this.KeepAliveThread));
            //thread.Start();
        }

        private void KeepAliveThread()
        {
            timer = new System.Timers.Timer();
            timer.Interval = aliveTime;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(AliveCode);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //调用AuthorizeServiceEx中的KeepAlive接口
        private void AliveCode(object sender, System.Timers.ElapsedEventArgs e)
        {
            int result = authorService.KeepAlive();
        }
        
        /// <summary>
        /// 登入SMC系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string userName=this.textBox1.Text.ToString();
                string password=this.textBox2.Text.ToString();
                int result = authorService.Login(userName,password);
                if (result == 0)
                {
                    this.Login.Text = "Login succ";
                    Thread thread = new Thread(new ThreadStart(this.KeepAliveThread));
                    thread.Start();
                        
                }
                ConsoleLog("Login resultCode = " + result.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        /// <summary>
        /// 登出SMC系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Login succ")
            {
                int result = authorService.Logout();
                if (result == 0)
                {
                    this.Login.Text = "Login";
                }
                ConsoleLog("Logout resultCode = " + result.ToString());
            }
        }


        private string orgId;
        
        private AdhocConfTemplateParamEx adhocConfTemplate;
        
        private QueryConfigEx queryConfigEx;

        private DataTable adhocTemplateTable;

        /// <summary>
        /// 添加Ad hoc会议模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addAdhocConfTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                this.orgId = this.txt_orgId.Text.ToString();
                
                // Adhoc会议模板参数
                this.adhocConfTemplate = new AdhocConfTemplateParamEx();
                // Adhoc模板ID, 新增时为0
                adhocConfTemplate.adhocConfTemplateId = this.txt_TemplateId.Text.ToString();
                // 会议模板名称
                adhocConfTemplate.name = this.txt_TemplateName.Text.ToString();
                // 会议激活号码
                adhocConfTemplate.accessCode = this.txt_AccessCode.Text.ToString();
                adhocConfTemplate.duration = this.txt_Duration.Text.ToString();
                // 计费码
                adhocConfTemplate.billCode = this.txt_billcode.Text.ToString();
                //密码
                adhocConfTemplate.password = this.txt_Password.Text.ToString();
                // 多画面资源数
                adhocConfTemplate.cpResource = Convert.ToInt32(this.txt_cpResource.Text.ToString());
                // 速率
                adhocConfTemplate.rate = this.txt_Rate.Text.ToString();
                // 媒体流加密方式，0：自动协商是否使用加密
                adhocConfTemplate.mediaEncryptType = Convert.ToInt32(this.txt_mediaEncryptType.Text.ToString());
                // 是否支持直播功能, 0：不支持 1：支持
                adhocConfTemplate.isLiveBroadcast = Convert.ToInt32(this.txt_isLiveBroadcast.Text.ToString());
                // 是否支持录播功能, 0：不支持 1：支持
                adhocConfTemplate.isRecording = Convert.ToInt32(this.txt_isRecording.Text.ToString());
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
                
                //调用接口添加会议模板
                TPSDKResponseEx<string> result = cmService.addAdhocConfTemplateEx(orgId, adhocConfTemplate);
                this.ConsoleLog("addAdhocConfTemplateEx resultCode = " + result.resultCode);
                if (0 == result.resultCode)
                {
                    //添加成功，返回会议模板ID
                    string adhocConfTemplateId = result.result;
                    this.ConsoleLog("adhocConfTemplateId = " + adhocConfTemplateId);                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 查询Ad hoc会议模板列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_queryAdhocConfTemplateList_Click(object sender, EventArgs e)
        {
            try
            {
                this.queryConfigEx = new QueryConfigEx();
                //对查询结果按照会场名升序方式进行排序
                List<SortItemsEx> sortItemExs = new List<SortItemsEx>();
                SortItemsEx sortItemEx = new SortItemsEx();
                sortItemEx.sort = Convert.ToInt32(this.tb_Sort.Text.ToString());
                sortItemEx.itemIndex = Convert.ToInt32(this.tb_SortIndex.Text.ToString());
                sortItemExs.Add(sortItemEx);
                //获取满足会场名包含vct2条件的会场
                List<FiltersBaseEx> filtersExs = new List<FiltersBaseEx>();
                StringFilterEx filtersEx = new StringFilterEx();
                filtersEx.columnIndex = Convert.ToInt32(this.tb_columnIndex.Text.ToString());
                filtersEx.value = this.tb_Value.Text.ToString();
                filtersExs.Add(filtersEx);
                //每页5个，获取第一页
                PageParamEx pageParamEx = new PageParamEx();
                pageParamEx.numberPerPage = Convert.ToInt32(this.tb_numberPerPage.Text.ToString());
                pageParamEx.currentPage = Convert.ToInt32(this.tb_currentPage.Text.ToString()); ;
                //查询条件属性赋值
                queryConfigEx.sortItems = sortItemExs.ToArray<SortItemsEx>();
                queryConfigEx.filters = filtersExs.ToArray<FiltersBaseEx>();
                queryConfigEx.focusItem = Convert.ToInt32(this.tb_focusItem.Text.ToString());
                queryConfigEx.pageParam = pageParamEx;

                //调用会议服务的queryScheduleConferencesEx方法查询所有的调度会议状态
                //返回TPSDKResponseEx<List<ConferenceStatusEx>>对象
                TPSDKResponseEx<List<AdhocConfTemplateParamEx>> result = cmService.queryAdhocConfTemplateListEx(queryConfigEx);
                this.ConsoleLog("queryAdhocConfTemplateListEx resultCode = " + result.resultCode);
                this.updateAdhocTemplateTable();
                if (result.resultCode == 0)
                {                    
                    List<AdhocConfTemplateParamEx> list = result.result;
                    for(int i=0;i<list.Count;i++)
                    {
                        string AdhocTemplateId = list[i].adhocConfTemplateId;
                        string name = list[i].name;
                        string accessCode = list[i].accessCode;
                        string duration = list[i].duration;
                        string password = list[i].password;
                        this.adhocTemplateTable.Rows.Add(AdhocTemplateId, name, accessCode, duration, password, "0");
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 利用Ad hoc会议模板预约会议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_scheduleConfEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (adhocConfTemplate == null)
                {
                    return;
                }
                ConferenceInfoEx conferenceInfo = new ConferenceInfoEx();
                conferenceInfo.name = adhocConfTemplate.name;
                conferenceInfo.beginTime = DateTime.Now;
                conferenceInfo.duration = adhocConfTemplate.duration;
                conferenceInfo.rate = adhocConfTemplate.rate;
                conferenceInfo.sites = adhocConfTemplate.sites;

                TPSDKResponseEx<ConferenceInfoEx> result = cmService.scheduleConfEx(conferenceInfo);
                //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
                int resultCode = result.resultCode;
                if (0 == resultCode)
                {
                    //预约成功，则返回预约后的会议信息
                    string confId = result.result.confId;
                    this.ConsoleLog("scheduleConfEx by adhocTemplate resultCode = " + resultCode.ToString() + ";confId = " + confId);
                }
                else
                {
                    this.ConsoleLog("scheduleConfEx by adhocTemplate resultCode = " + resultCode.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        /// <summary>
        /// 删除会议模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delAdhocConfTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.adhocTemplateTable==null)
                {
                    return;
                }
                List<string> listId = new List<string>();
                for(int i=0; i<adhocTemplateTable.Rows.Count;i++)
                {
                    if (adhocTemplateTable.Rows[i]["check"].Equals("1"))
                    {
                        listId.Add(adhocTemplateTable.Rows[i]["adhocTemplateId"].ToString());
                    }
                }
                if(listId.Count==0)
                {
                    return;
                }
                foreach(string id in listId)
                {
                    int result = cmService.delAdhocConfTemplateEx(id);
                    this.ConsoleLog("delAdhocConfTemplateEx AdhocConfTemplate id " + id + " resultCode = " + result);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateAdhocTemplateTable()
        {
            if(this.adhocTemplateTable!=null)
            {
                adhocTemplateTable = null;
            }
            this.adhocTemplateTable = new DataTable();
            adhocTemplateTable.Columns.Add("adhocTemplateId");
            adhocTemplateTable.Columns.Add("name");
            adhocTemplateTable.Columns.Add("accessCode");
            adhocTemplateTable.Columns.Add("duration");
            adhocTemplateTable.Columns.Add("password");
            adhocTemplateTable.Columns.Add("check");

            DataColumn[] column = new DataColumn[] { this.adhocTemplateTable.Columns["adhocTemplateId"] };
            this.adhocTemplateTable.PrimaryKey = column;
            this.dgw_AdhocTemplate.DataSource = adhocTemplateTable;
            this.dgw_AdhocTemplate.Update();
        }

        
    }
}
