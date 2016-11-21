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

namespace 会议中会场操作Demo
{
    public partial class Conference_Sites : Form
    {
        AuthorizeServiceEx authorService;
        ConferenceMgrServiceEx cmService;
        public Conference_Sites()
        {
            InitializeComponent();
            authorService = AuthorizeServiceEx.Instance();
            cmService = ConferenceMgrServiceEx.Instance();
            this.tb_BeginTime.Text = DateTime.Now.ToString();
            this.updateConfSitesDataTable();
        }

        private void ConsoleLog(string log)
        {
            this.rtxtConsoleLog.AppendText(DateTime.Now.ToString() + ": " + log + "\r\n");
        }

        #region Login management info
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

        // Call AuthorizeServiceEx::KeepAlive interface
        private void AliveCode(object sender, System.Timers.ElapsedEventArgs e)
        {
            int result = authorService.KeepAlive();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = this.textBox1.Text.ToString();
                string password = this.textBox2.Text.ToString();
                int result = authorService.Login(userName, password);
                if (result == 0)
                {
                    Thread thread = new Thread(new ThreadStart(this.KeepAliveThread));
                    thread.Start();

                }
                this.ConsoleLog("Login resultCode = " + result.ToString());

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            try
            {
                int result = authorService.Logout();
                this.ConsoleLog("Logout resultCode = " + result.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion


        DataTable sitesTable;
        DataTable confSitesTable;

        // query sites list
        private void btn_QuerySiteList_Click(object sender, EventArgs e)
        {
            try
            {
                List<SiteInfoEx> sites = null;
                //调用会议服务中的querySitesEx方法查询所有会场信息，返回TPSDKResponseEx< List<SiteInfoEx>>对象。 
                TPSDKResponseEx<List<SiteInfoEx>> result = cmService.querySitesEx();
                //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
                int resultCode = result.resultCode;
                if (0 == resultCode)
                {
                    //如果查询成功，则返回所有会场信息 
                    sites = result.result;
                    //更新会场数据
                    this.updateSiteDataTable();
                    foreach (SiteInfoEx site in sites)
                    {
                        this.sitesTable.Rows.Add(site.uri, site.name, site.type, site.from, site.rate, 0);
                    }
                    //日志
                    this.ConsoleLog("querySitesEx resultCode = " + resultCode.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btn_scheduleConf_Click(object sender, EventArgs e)
        {
            try
            {
                this.updateConfSitesDataTable();
                if (sitesTable == null)
                {
                    return;
                }
                           
                List<SiteInfoEx> siteslist = new List<SiteInfoEx>();
                for (int i = 0; i < sitesTable.Rows.Count; i++)
                {
                    if (sitesTable.Rows[i]["checked"].Equals("1"))
                    {
                        //新建会场
                        SiteInfoEx siteInfo1 = new SiteInfoEx();
                        //会场URI为01033001 
                        siteInfo1.uri = sitesTable.Rows[i]["siteURI"].ToString();
                        //会场速率为1920K
                        siteInfo1.rate = "1920K";
                        //会场名称为site1
                        siteInfo1.name = sitesTable.Rows[i]["siteName"].ToString();
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

                        siteslist.Add(siteInfo1);
                    }

                }

                ConferenceInfoEx conferenceInfo = new ConferenceInfoEx();
                conferenceInfo.name = this.tb_Name.Text.ToString();
                conferenceInfo.beginTime = Convert.ToDateTime(this.tb_BeginTime.Text.ToString());
                conferenceInfo.duration = this.tb_Duration.Text.ToString();
                conferenceInfo.rate = this.tb_Rate.ToString();
                conferenceInfo.sites = siteslist.ToArray<SiteInfoEx>();

                //调用会议服务的scheduleConfEx方法预约会议，返回TPSDKResponseEx<ConferenceInfoEx>对象
                TPSDKResponseEx<ConferenceInfoEx> result = cmService.scheduleConfEx(conferenceInfo);
                //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
                int resultCode = result.resultCode;
                if (0 == resultCode)
                {
                    //预约成功，则返回预约后的会议信息
                    string confId = result.result.confId;
                    this.txt_confId.Text = confId;
                    this.ConsoleLog("queryScheduleConferencesEx resultCode = " + result.resultCode.ToString() + ";confId = " + confId);
                    
                    for(int i=0;i<siteslist.Count;i++)
                    {
                        //新建一个SiteInfoEX对象 
                        SiteInfoEx siteInfo = siteslist[i];
                        this.confSitesTable.Rows.Add(siteInfo.uri, siteInfo.name, siteInfo.type, "0");
                    }
                    this.dgw_ConfSitesList.Update();
                }
                else
                {
                    this.ConsoleLog("queryScheduleConferencesEx resultCode = " + result.resultCode.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        /// <summary>
        /// 添加会场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addSiteToConf_Click(object sender, EventArgs e)
        {
            try
            {
                if (sitesTable == null)
                {
                    return;
                }
                List<SiteInfoEx> siteslist = new List<SiteInfoEx>();
                for (int i = 0; i < sitesTable.Rows.Count; i++)
                {
                    if (sitesTable.Rows[i]["checked"].Equals("1"))
                    {
                        //新建会场
                        SiteInfoEx siteInfo1 = new SiteInfoEx();
                        //会场URI为01033001 
                        siteInfo1.uri = sitesTable.Rows[i]["siteURI"].ToString();
                        //会场速率为1920K
                        siteInfo1.rate = "1920K";
                        //会场名称为site1
                        siteInfo1.name = sitesTable.Rows[i]["siteName"].ToString();
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

                        siteslist.Add(siteInfo1);
                    }
                }
                if(siteslist.Count==0)
                {
                    return;
                }
                for(int i=0;i<siteslist.Count;i++)
                {
                    //新建一个SiteInfoEX对象 
                    SiteInfoEx siteInfo = siteslist[i];

                    //调用会议服务中的addSiteToConfEx方法，返回TPSDKResponseEx<List<SiteAccessInfoEx>>>对象。 
                    TPSDKResponseEx<List<SiteAccessInfoEx>> result = cmService.addSiteToConfEx(this.txt_confId.Text, siteInfo, null);
                    //如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
                    this.ConsoleLog("addSiteToConfEx resultCode = " + result.resultCode);
                    if (0 == result.resultCode)
                    {
                        bool flag = false;
                        for(int j=0;j<confSitesTable.Rows.Count;j++)
                        {
                            if(confSitesTable.Rows[j]["siteURI"].Equals(siteInfo.uri))
                            {
                                flag = true;
                            }
                        }
                        if(flag)
                        {
                            this.confSitesTable.Rows.Add(siteInfo.uri, siteInfo.name, siteInfo.type, 0); 
                        }
                        else
                        {
                            this.ConsoleLog("The site is already exist: " + siteInfo.uri);
                        }
                    }
                }
                this.dgw_ConfSitesList.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 删除会议中的会场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delSiteFromConfEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.confSitesTable == null || this.txt_confId.Text == "")
                {
                    return;
                }
                List<string> uriList = new List<string>();
                for(int i=0;i<confSitesTable.Rows.Count;i++)
                {                    
                    if(confSitesTable.Rows[i]["checked"].Equals("1"))
                    {
                        uriList.Add(confSitesTable.Rows[i]["siteURI"].ToString());
                    }
                }
                if(uriList.Count==0)
                {
                    return;
                }
                for(int i=0;i<uriList.Count;i++)
                {
                    int result = cmService.delSiteFromConfEx(this.txt_confId.Text, uriList[i], null);
                    this.ConsoleLog("delSiteFromConfEx resultCode = " + result);
                    if(result==0)
                    {
                        DataRow row = this.confSitesTable.Rows.Find(uriList[i]);
                        this.confSitesTable.Rows.Remove(row);
                    }
                }
                this.dgw_ConfSitesList.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 呼叫多个会场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connectSitesEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.confSitesTable == null || this.txt_confId.Text == "")
                {
                    return;
                }
                List<string> uriList = new List<string>();
                for (int i = 0; i < confSitesTable.Rows.Count; i++)
                {
                    if (confSitesTable.Rows[i]["checked"].Equals("1"))
                    {
                        uriList.Add(confSitesTable.Rows[i]["siteURI"].ToString());
                    }
                }
                if (uriList.Count == 0)
                {
                    return;
                }
                int resultCode = cmService.connectSitesEx(this.txt_confId.Text, uriList);
                this.ConsoleLog("connectSitesEx resultCode = " + resultCode);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 挂断多个会场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_disconnectSitesEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.confSitesTable == null || this.txt_confId.Text == "")
                {
                    return;
                }
                List<string> uriList = new List<string>();
                for (int i = 0; i < confSitesTable.Rows.Count; i++)
                {
                    if (confSitesTable.Rows[i]["checked"].Equals("1"))
                    {
                        uriList.Add(confSitesTable.Rows[i]["siteURI"].ToString());
                    }
                }
                if (uriList.Count == 0)
                {
                    return;
                }
                int resultCode = cmService.disconnectSitesEx(this.txt_confId.Text, uriList);
                this.ConsoleLog("disconnectSitesEx resultCode = " + resultCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void updateSiteDataTable()
        {
            if (this.sitesTable != null)
            {
                this.sitesTable = null;
            }
            //初始化会议ID的datatable
            this.sitesTable = new DataTable();
            this.sitesTable.Columns.Add("siteURI");
            this.sitesTable.Columns.Add("siteName");
            this.sitesTable.Columns.Add("siteType");
            this.sitesTable.Columns.Add("siteFrom");
            this.sitesTable.Columns.Add("siteRate");
            this.sitesTable.Columns.Add("checked");
            DataColumn[] column = new DataColumn[] { this.sitesTable.Columns["siteURI"] };
            this.sitesTable.PrimaryKey = column;
            this.siteGridView.DataSource = sitesTable;
            this.siteGridView.Update();
        }

        public void updateConfSitesDataTable()
        {
            if (this.confSitesTable != null)
            {
                this.confSitesTable = null;
            }
            //初始化会议ID的datatable
            this.confSitesTable = new DataTable();
            this.confSitesTable.Columns.Add("siteURI");
            this.confSitesTable.Columns.Add("siteName");
            this.confSitesTable.Columns.Add("siteType");
            this.confSitesTable.Columns.Add("checked");
            DataColumn[] column = new DataColumn[] { this.confSitesTable.Columns["siteURI"] };
            this.confSitesTable.PrimaryKey = column;
            this.dgw_ConfSitesList.DataSource = confSitesTable;
            this.dgw_ConfSitesList.Update();
        }
    }
}
