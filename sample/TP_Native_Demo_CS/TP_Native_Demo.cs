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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;
using com.huawei.esdk.tp.professional.eSDKPlatformKeyMgrService;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

using TP_Native_Demo.ParameterForms;


namespace TP_Native_Demo
{
    public partial class TP_Native_Demo : Form
    {
        AuthorizeServiceEx authorService;
        ConferenceMgrServiceEx cmService;
        ConferenceCtrlServiceEx ccService;
        SiteServiceEx sService;
        PlatformKeyServiceProvider platformKey;
        MCUMgrServiceEx MCUService;
        TerminalConferenceCtrlServiceEx terminalService;
        OrgaMgrServiceEx orgaMgrService;
        ScribMgrServiceEx scribMgrService;
        
        DataTable log_dt;
        DataTable confID_dt;
        DataTable sites_dt;

        public TP_Native_Demo()
        {
            InitializeComponent();

            authorService = AuthorizeServiceEx.Instance();
            cmService = ConferenceMgrServiceEx.Instance();
            ccService = ConferenceCtrlServiceEx.Instance();
            platformKey = PlatformKeyServiceProvider.Instance();
            sService = SiteServiceEx.Instance();
            MCUService = MCUMgrServiceEx.Instance();
            terminalService = TerminalConferenceCtrlServiceEx.Instance();
            scribMgrService = ScribMgrServiceEx.Instance();
            orgaMgrService = OrgaMgrServiceEx.Instance();
                
        }

        private void TP_Demo_Load(object sender, EventArgs e)
        {
            //初始化日志数据
            TPLogMgr.LogInit();
            //初始化接口日志datatable
            this.log_dt = new DataTable();
            this.log_dt.Columns.Add("logType");
            this.log_dt.Columns.Add("logLevel");
            this.log_dt.Columns.Add("logContent");
            this.LogGridView.DataSource = log_dt;
            this.LogGridView.Update();
            //初始化会议ID的datatable
            this.confID_dt = new DataTable();
            this.confID_dt.Columns.Add("conferenceID");
            DataColumn[] cols = new DataColumn[] { this.confID_dt.Columns["conferenceID"] };
            this.confID_dt.PrimaryKey = cols;
            this.ConfID_GridView.DataSource=confID_dt;
            this.ConfID_GridView.Update();
        }

        #region 鉴权管理接口

        /// <summary>
        /// 登入SMC系统
        /// </summary>
        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                LoginParameter login = new LoginParameter();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.Yes)
                {
                    HttpWebRequest.DefaultWebProxy = null;
                    //int result = authorService.Login("dongjian", "Huawei@123");
                    int result = authorService.Login(login.name, login.passWord);
                    if (result == 0)
                    {
                        this.Login.Text = "登入成功";
                        Thread thread = new Thread(new ThreadStart(this.KeepAliveThread));
                        thread.Start();
                        this.WriteLog("Run", 0, "Login success:" + result.ToString());
                    }
                    else
                    {
                        this.WriteLog("Run", 0, "Login fail." + result.ToString());
                    }
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        /// <summary>
        /// 登出SMC系统
        /// </summary>
        private void Logout_Click(object sender, EventArgs e)
        {
            if (Login.Text == "登入成功")
            {
                int result = authorService.Logout();
                if (result == 0)
                {
                    this.Login.Text = "登入";
                    this.WriteLog("Run", 0, "Logout success:"+result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "Logout fail:"+result.ToString());
                }
            }
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
            if (result == 0)
            {
                this.WriteLog("Run", 0, "KeepAlive success."+result.ToString());
            }
            else
            {
                this.WriteLog("Run", 0, "KeepAlive failed."+result.ToString());
            }
        }

        #endregion

        #region 会议调度接口

        ConferenceInfoEx conferenceInfo = new ConferenceInfoEx();
        
        RecurrenceConfInfoEx recurrenceConfInfo = new RecurrenceConfInfoEx();
        
        DateTime? beginTime = null;

        DateTime? recurrenceBeginTime = null;
        
        //召集或预约普通会议
        public int scheduleConf()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个ConferenceInfoEx对象
            ConferenceInfoEx scheduleConf = new ConferenceInfoEx();

            scheduleConf = conferenceParameter.scheduleConf;
            scheduleConf.sites[1].type = 7;
            //会议开始时间为30分钟之后 
            scheduleConf.beginTime = scheduleConf.beginTime;

            //调用会议服务的scheduleConfEx方法预约会议，返回TPSDKResponseEx<ConferenceInfoEx>对象
            TPSDKResponseEx<ConferenceInfoEx> result = cmService.scheduleConfEx(scheduleConf);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //预约成功，则返回预约后的会议信息
                conferenceInfo = result.result;
                beginTime = scheduleConf.beginTime;
                //Message日志
                MessageLog<ConferenceInfoEx> messageLog = new MessageLog<ConferenceInfoEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
        }

        private void scheduleConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.scheduleConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "scheduleConf success:" + result.ToString());
                    this.confID_dt.Rows.Add(conferenceInfo.confId);
                }
                else
                {
                    this.WriteLog("Run", 0, "scheduleConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //修改已经预约的普通会议
        public int editScheduleConf()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();            
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            ////新建一个ConferenceInfoEx对象
            ConferenceInfoEx scheduleConf = new ConferenceInfoEx();
            scheduleConf = conferenceParameter.scheduleConf;
            //会议开始时间为30分钟之后 
            scheduleConf.beginTime = scheduleConf.beginTime;

            //调用会议服务的scheduleConfEx方法预约会议，返回TPSDKResponseEx<ConferenceInfoEx>对象
            TPSDKResponseEx<ConferenceInfoEx> result = cmService.editScheduledConfEx(scheduleConf);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //预约成功，则返回预约后的会议信息
                scheduleConf = result.result;

                //Message日志
                MessageLog<ConferenceInfoEx> messageLog = new MessageLog<ConferenceInfoEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
          
        }

        private void editScheduleConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.editScheduleConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "editScheduleConf success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "editScheduleConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //召集或预约周期会议
        public int scheduleRecurrenceConferenceEx()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个ConferenceInfoEx对象
            RecurrenceConfInfoEx scheduleConf = new RecurrenceConfInfoEx();
            scheduleConf = conferenceParameter.scheduleCurrenceConf;
            beginTime = scheduleConf.beginTime;
            //调用会议服务的scheduleConfEx方法预约会议，返回TPSDKResponseEx<ConferenceInfoEx>对象
            TPSDKResponseEx<RecurrenceConfInfoEx> result = cmService.scheduleRecurrenceConferenceEx(scheduleConf);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //预约成功，则返回预约后的会议信息
                recurrenceConfInfo = result.result;
                recurrenceBeginTime = scheduleConf.beginTime;
                //Message日志
                MessageLog<RecurrenceConfInfoEx> messageLog = new MessageLog<RecurrenceConfInfoEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
        }

        private void scheduleRecurrenceConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.scheduleRecurrenceConferenceEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "scheduleRecurrenceConferenceEx success:" + result.ToString());
                    this.confID_dt.Rows.Add(recurrenceConfInfo.confId);
                }
                else
                {
                    this.WriteLog("Run", 0, "scheduleRecurrenceConferenceEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //修改已经预约的周期会议
        public int editRecurrenceConfInfoEx()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个ConferenceInfoEx对象
            RecurrenceConfInfoEx scheduleConf = new RecurrenceConfInfoEx();
            scheduleConf = conferenceParameter.scheduleCurrenceConf;
            beginTime = scheduleConf.beginTime;
            //调用会议服务的scheduleConfEx方法预约会议，返回TPSDKResponseEx<ConferenceInfoEx>对象
            TPSDKResponseEx<RecurrenceConfInfoEx> result = cmService.editRecurrenceConferenceEx(scheduleConf, beginTime);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //预约成功，则返回预约后的会议信息
                recurrenceConfInfo = result.result;
                //Message日志
                MessageLog<RecurrenceConfInfoEx> messageLog = new MessageLog<RecurrenceConfInfoEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            recurrenceBeginTime = scheduleConf.beginTime;
            return resultCode;
        }

        private void editRecurrenceConfInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.editRecurrenceConfInfoEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "editRecurrenceConfInfoEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "editRecurrenceConfInfoEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //延长已预约或正在召开的普通会议或周期性会议
        public int prolongScheduledConf()
        {
            ProlongConference prolong = new ProlongConference();
            prolong.ShowDialog();
            if (prolong.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的proLongScheduledConfEx方法，返回int对象。
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。
            int resultCode = cmService.prolongScheduledConfEx(prolong.confid, null, prolong.duration);
            return resultCode;

        }

        private void prolongScheduledConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.prolongScheduledConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "prolongScheduledConf success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "prolongScheduledConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //删除预约会议或结束正在召开的会议
        public int delScheduledConf()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[1]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            ////新建一个ConferenceInfoEx对象
            ConferenceInfoEx scheduleConf = new ConferenceInfoEx();
            scheduleConf = conferenceParameter.scheduleConf;
            
            //调用会议服务中的delScheduledConfEx方法，返回int对象。 
            //如果返回值为0，则表示取消或删除会议成功，否则，表示取消或删除会议失败，具体失败原因，请参考错误码列表。
            int resultCode=0;
            
            if (scheduleConf.confId != "" && scheduleConf.confId != null)
            {
                resultCode = cmService.delScheduledConfEx(scheduleConf.confId, null);
                if (resultCode == 0)
                {
                    conferenceInfo = new ConferenceInfoEx();
                    //删除ConfID_GridView中的对应行
                    if (this.confID_dt.Rows.Find(scheduleConf.confId) != null)
                    {
                        this.confID_dt.Rows.Remove(this.confID_dt.Rows.Find(scheduleConf.confId));
                    }               
                }
            }
            if (recurrenceConfInfo.confId != "" && recurrenceConfInfo.confId != null)
            {
                resultCode = cmService.delScheduledConfEx(recurrenceConfInfo.confId, null);
                if (resultCode == 0)
                    recurrenceConfInfo = new RecurrenceConfInfoEx();
            }
            return resultCode;
        }

        private void delScheduledConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.delScheduledConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "delScheduledConf success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "delScheduledConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询多个已调度会议的状态
        public int queryConferencesStatus()
        {
            ConferenceParameter conferenceParameter = new ConferenceParameter();
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.tabControl2.TabPages.Remove(conferenceParameter.tabControl2.TabPages[0]);
            conferenceParameter.ShowDialog();
            if (conferenceParameter.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryConfSitesStatusEx方法，返回TPSDKResponseEx <List<ConferenceStatusEx>>对象。
            TPSDKResponseEx<List<ConferenceStatusEx>> result = cmService.queryConferencesStatusEx(conferenceParameter.list);
            
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                // 查询成功，则返回一个List<ConferenceStatusEx>对象
                List<ConferenceStatusEx> status = result.result;
                //Message 日志
                MessageListLog<ConferenceStatusEx> messageLog = new MessageListLog<ConferenceStatusEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
        }

        private void queryConfStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryConferencesStatus();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryConferencesStatus success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryConferencesStatus fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询指定会议中的会场状态
        public int queryConfSitesStatus()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId = sitesForConference.conf_ID;
            //新建一个List对象，用于存放需要呼叫的会场URI 
            List<string> list = sitesForConference.list;
            
            //调用会议服务中的queryConfSitesStatusEx方法，返回TPSDKResponseEx <List<SiteStatusEx>>对象。
            TPSDKResponseEx<List<SiteStatusEx>> result = cmService.queryConfSitesStatusEx(conferenceInfo.confId, list);
            
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //如果操作成功，则返回List<SiteStatusEx>对象
                List<SiteStatusEx> status = result.result;
                //Message 日志
                MessageListLog<SiteStatusEx> messageLog = new MessageListLog<SiteStatusEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
        }

        private void queryConferenceSitesStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryConfSitesStatus();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryConfSitesStatus success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryConfSitesStatus fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //向已预约或已召开会议添加会场
        public int addSiteToConf()
        {
            SiteForConference siteForConference = new SiteForConference();
            siteForConference.ShowDialog();
            if (siteForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个SiteInfoEX对象 
            SiteInfoEx siteInfo1 = siteForConference.site; 

            //调用会议服务中的addSiteToConfEx方法，示例中是把会场URI为01033001的会场添加已经预约的会议中，返回TPSDKResponseEx<List<SiteAccessInfoEx>>>对象。 
            TPSDKResponseEx<List<SiteAccessInfoEx>> result = cmService.addSiteToConfEx(siteForConference.conf_ID, siteInfo1, null);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            
            if (0 == result.resultCode)
            {
                //添加成功后，返回新会场接入到会议中的接入号信息 
                List<SiteAccessInfoEx> list = result.result;

                //Message 日志
                MessageListLog<SiteAccessInfoEx> messageLog = new MessageListLog<SiteAccessInfoEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return result.resultCode;
        }

        private void addSiteToConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.addSiteToConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "addSiteToConf success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "addSiteToConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //删除已预约或已召开的会议中的会场
        public int delSiteFromConf()
        {
            SiteForConference siteForConference = new SiteForConference();
            siteForConference.ShowDialog();
            if (siteForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个SiteInfoEX对象 
            SiteInfoEx siteInfo1 = siteForConference.site;
            
            //调用会议服务中的delSiteFromConfEx方法，返回int对象。 
            //如果返回值为0，则表示删除成功，否则，表示删除失败，具体失败原因，请参考错误码列表。 
            int resultCode = cmService.delSiteFromConfEx(siteForConference.conf_ID, siteInfo1.uri, null);

            return resultCode;
        }

        private void delSiteFromConference_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.delSiteFromConf();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "delSiteFromConf success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "delSiteFromConf fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //呼叫指定会议的一个或多个会场
        public int connectSites()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId =sitesForConference.conf_ID;
            //新建一个List对象，用于存放需要呼叫的会场URI 
            List<string> list = sitesForConference.list;
            //调用会议服务中的connectSitesEx方法，返回int对象。 
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。 
            int resultCode = cmService.connectSitesEx(confId, list);
            return resultCode;
        }

        private void connectSitesFromConf_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.connectSites();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "connectSites success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "connectSites fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //断开指定会议中与会的一个或多个会场
        public int disconnectSites()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId = sitesForConference.conf_ID;
            //新建一个List对象，用于存放需要呼叫的会场URI 
            List<string> list = sitesForConference.list;
            //调用会议服务中的disconnectSitesEx方法，返回int值。 
            //如果返回值为0，则表示挂断成功，否则，表示挂断失败，具体失败原因，请参考错误码列表。 
            int resultCode = cmService.disconnectSitesEx(confId, list);
            return resultCode;
        }

        private void disconnectSitesFromConf_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.disconnectSites();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "disconnectSites success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "disconnectSites fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询指定会议中的会场所属MCU
        public int queryConfSiteMCU()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId = sitesForConference.conf_ID;
            //新建一个List对象，用于存放需要呼叫的会场URI 
            List<string> list = sitesForConference.list;
            string[] siteUris = list.ToArray();
            
            //可选。会议开始时间。用于对周期会议中的单个会议进行查询。若周期会议不输入时间，则返回周期会议中第一个会议的会场所属MCU信息
            System.DateTime beginTime1 = (DateTime)beginTime;
            //调用会议服务中的queryConfSiteMCUEx方法，示查询会议中会场所属MCU
            TPSDKResponseEx<SiteMCUEx[]> result = cmService.queryConfSiteMCUEx(confId, siteUris, beginTime1);
            
            //返回错误码，具体说明如下： 0：表示成功； 其他数值：表示失败
            if (result.resultCode == 0)
            {
                //如果查询成功，则返回指定会场的MCU
                SiteMCUEx[] siteMCU = result.result;

                //Message日志
                if (siteMCU != null||siteMCU.Length!=0)
                {
                    List<SiteMCUEx> listMCU=new List<SiteMCUEx>();
                    for (int i = 0; i < siteMCU.Length; i++)
                    {
                        listMCU.Add(siteMCU[i]);
                    }
                    MessageListLog<SiteMCUEx> messageLog = new MessageListLog<SiteMCUEx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
                
            }
            return result.resultCode;
        }

        private void queryConferenceSiteMCU_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryConfSiteMCU();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryConfSiteMCU success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryConfSiteMCU fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }            
        }

        //查询指定接入号、指定时段的Adhoc会议忙闲状态
        public int queryAdhocConfFreeBusy()
        {
            AdhocConfParameters adhocConfParameters = new AdhocConfParameters();
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.ShowDialog();
            if (adhocConfParameters.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //Adhoc会议接入号列表，可以同时查询多个Adhoc的忙闲状态
            string[] confAccessCodes = adhocConfParameters.ConfAccessCodes;
            //查询开始时间
            System.DateTime beginTime1 = adhocConfParameters.beginTime;
            //查询间隔时长，如：P0Y0M2DT1H0M0.000S或者PT2D：表示2天
            string duration = adhocConfParameters.duration;
            
            //调用会议服务中的queryAdhocConfFreeBusyEx方法，查询指定接入号、指定时段的Adhoc会议忙闲状态
            TPSDKResponseEx<AdhocConfFreeBusyStateEx[]> result = cmService.queryAdhocConfFreeBusyEx(confAccessCodes, beginTime1, duration);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //输出Adhoc会议的忙闲状态信息。如果指定的Adhoc会议不存在，则对应的Adhoc会议没有忙闲状态
                AdhocConfFreeBusyStateEx[] freebusy = result.result;
                //Message日志
                if (freebusy != null && freebusy.Length != 0)
                {
                    List<AdhocConfFreeBusyStateEx> listMCU = new List<AdhocConfFreeBusyStateEx>();
                    for (int i = 0; i < freebusy.Length; i++)
                    {
                        listMCU.Add(freebusy[i]);
                    }
                    MessageListLog<AdhocConfFreeBusyStateEx> messageLog = new MessageListLog<AdhocConfFreeBusyStateEx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }

        private void queryAdhocConferenceFreeBusy_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryAdhocConfFreeBusy();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryAdhocConfFreeBusy success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryAdhocConfFreeBusy fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询指定接入号、指定时段的Adhoc会议忙闲状态变化的数据
        public int synchAdhocConfFreeBusy()
        {
            AdhocConfParameters adhocConfParameters = new AdhocConfParameters();
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.ShowDialog();
            if (adhocConfParameters.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //Adhoc会议接入号列表，可以同时查询多个Adhoc的忙闲状态
            string[] confAccessCodes = adhocConfParameters.ConfAccessCodes;
            //查询开始时间
            System.DateTime beginTime1 = adhocConfParameters.beginTime;
            //查询间隔时长，如：P0Y0M2DT1H0M0.000S或者PT2D：表示2天
            string duration = adhocConfParameters.duration;

            //调用会议服务中的synchAdhocConfFreeBusyEx方法，查询指定Adhoc会议在指定时间段内发生忙闲状态变化的数据
            TPSDKResponseEx<AdhocConfFreeBusyStateEx[]> result = cmService.synchAdhocConfFreeBusyEx(confAccessCodes, beginTime1, duration);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //输出Ad   hoc会议的忙闲状态信息。如果指定的Ad hoc会议不存在，则对应的Ad hoc会议没有忙闲状态
                AdhocConfFreeBusyStateEx[] freebusy = result.result;
                //Message日志
                if (freebusy != null && freebusy.Length != 0)
                {
                    List<AdhocConfFreeBusyStateEx> listMCU = new List<AdhocConfFreeBusyStateEx>();
                    for (int i = 0; i < freebusy.Length; i++)
                    {
                        listMCU.Add(freebusy[i]);
                    }
                    MessageListLog<AdhocConfFreeBusyStateEx> messageLog = new MessageListLog<AdhocConfFreeBusyStateEx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }

        private void synchAdhocConferenceFreeBusy_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.synchAdhocConfFreeBusy();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "synchAdhocConfFreeBusy success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "synchAdhocConfFreeBusy fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询Adhoc类型的会议模板列表
        public int queryAdhocConference()
        {
            QueryConfig queryConfig = new QueryConfig();
            queryConfig.ShowDialog();
            if (queryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryAdhocConferencesEx方法，查询Adhoc类型的会议模板列表
            TPSDKResponseSecondEx<AdhocConferenceEx[], PagesInfoEx> result = cmService.queryAdhocConferencesEx(queryConfig.queryConfigEx);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //操作成功，则根据查询条件，返回查询的会场信息列表
                AdhocConferenceEx[] adhocConferences = result.result1;
                //输出查询结果的翻页信息
                PagesInfoEx pageInfo = result.result2;
                //Message日志
                if (adhocConferences != null && adhocConferences.Length != 0)
                {
                    List<AdhocConferenceEx> listMCU = new List<AdhocConferenceEx>();
                    for (int i = 0; i < adhocConferences.Length; i++)
                    {
                        listMCU.Add(adhocConferences[i]);
                    }
                    MessageListLog<AdhocConferenceEx> messageLog = new MessageListLog<AdhocConferenceEx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }

        private void queryAdhocConferenceList_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryAdhocConference();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryAdhocConference success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryAdhocConference fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //向组织添加Adhoc会议模板，返回模板ID
        public int addAdhocConfTemplateEx()
        {
            AdhocConfParameters adhocConfParameters = new AdhocConfParameters();
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.ShowDialog();
            if (adhocConfParameters.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            // 会议模板添加到的组织
            String orgId = adhocConfParameters.orgId;
            // Adhoc会议模板参数
            AdhocConfTemplateParamEx adhocConfTemplate = adhocConfParameters.adhocConfTemplate;
            
            //调用会议服务的addAdhocConfTemplateEx方法添加会议模板，
            //TPSDKResponseEx<String>对象 
            TPSDKResponseEx<string> result = cmService.addAdhocConfTemplateEx(orgId, adhocConfTemplate);

            if (0 == result.resultCode)
            {
                //添加成功，返回会议模板ID
                String adhocConfTemplateId = result.result;
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":templateID = " + adhocConfTemplateId.ToString() + "\r\n");
            }
            return result.resultCode;
        }

        private void addAdhocConferenceTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.addAdhocConfTemplateEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "addAdhocConfTemplateEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "addAdhocConfTemplateEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //编辑Adhoc会议模板
        public int editAdhocConfTemplateEx()
        {
            AdhocConfParameters adhocConfParameters = new AdhocConfParameters();
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[1]);
            adhocConfParameters.ShowDialog();
            if (adhocConfParameters.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            // Adhoc会议模板参数
            AdhocConfTemplateParamEx adhocConfTemplate = adhocConfParameters.adhocConfTemplate;                        
            int resultCode = cmService.editAdhocConfTemplateEx(adhocConfTemplate);
            return resultCode;
        }

        private void editAdhocConferenceTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.editAdhocConfTemplateEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "editAdhocConfTemplateEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "editAdhocConfTemplateEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //删除Adhoc会议
        public int delAdhocConfTemplateEx()
        {
            AdhocConfParameters adhocConfParameters = new AdhocConfParameters();
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.tabControl2.TabPages.Remove(adhocConfParameters.tabControl2.TabPages[0]);
            adhocConfParameters.ShowDialog();
            if (adhocConfParameters.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            // Adhoc会议模板参数
            AdhocConfTemplateParamEx adhocConfTemplate = adhocConfParameters.adhocConfTemplate;
            int resultCode = cmService.delAdhocConfTemplateEx(adhocConfTemplate.adhocConfTemplateId);
            return resultCode;
        }

        private void delAdhocConferenceTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.delAdhocConfTemplateEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "delAdhocConfTemplateEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "delAdhocConfTemplateEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询符号条件的Adhoc会议模板列表
        public int queryAdhocConfTemplateListEx()
        {
            QueryConfig queryConfig = new QueryConfig();
            queryConfig.ShowDialog();
            if (queryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务的queryScheduleConferencesEx方法查询所有的调度会议状态
            //返回TPSDKResponseEx<List<ConferenceStatusEx>>对象
            TPSDKResponseEx<List<AdhocConfTemplateParamEx>> result = cmService.queryAdhocConfTemplateListEx(queryConfig.queryConfigEx);
            if (result.resultCode == 0)
            {
                //Message 日志
                MessageListLog<AdhocConfTemplateParamEx> messageLog = new MessageListLog<AdhocConfTemplateParamEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return result.resultCode;
        }

        private void queryAdhocConferenceTemplateList_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryAdhocConfTemplateListEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryAdhocConfTemplateListEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryAdhocConfTemplateListEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询多点CDR话单
        public int queryMultiPointCDR()
        {
            CDRQueryConfig cdrQueryConfig = new CDRQueryConfig();
            cdrQueryConfig.ShowDialog();
            if (cdrQueryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryMultiPointCDREx方法，查询多点CDR话单
            TPSDKResponseEx<QueryMultiPointCDRExResponse> result = cmService.queryMultiPointCDREx(cdrQueryConfig.MultiPoint_queryConfig);
            //返回错误码，具体说明如下： 0：表示成功； 其他数值：表示失败
            if (result.resultCode == 0)
            {
                //查询出来的多点CDR话单数据
                MultiPointCDREx[] cdr = result.result.cdr;
                //输出查询结果的翻页信息
                PagesInfoEx pageInfo = result.result.pageInfo;
                //Message日志
                if (cdr != null || cdr.Length != 0)
                {
                    List<MultiPointCDREx> listMCU = new List<MultiPointCDREx>();
                    for (int i = 0; i < cdr.Length; i++)
                    {
                        listMCU.Add(cdr[i]);
                    }
                    MessageListLog<MultiPointCDREx> messageLog = new MessageListLog<MultiPointCDREx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }

        private void queryMultiPointCDR_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryMultiPointCDR();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryMultiPointCDR success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryMultiPointCDR fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询点对点CDR话单
        public int queryPointToPointCDR()
        {
            CDRQueryConfig cdrQueryConfig = new CDRQueryConfig();
            cdrQueryConfig.ShowDialog();
            if (cdrQueryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryPointToPointCDREx方法，查询点对点CDR话单
            TPSDKResponseEx<QueryPointToPointCDRExResponse> result = cmService.queryPointToPointCDREx(cdrQueryConfig.PointToPoint_queryConfig);
            if (result.resultCode == 0)
            {
                //查询出来的点对点CDR话单数据
                PointToPointCDREx[] cdr = result.result.cdr;
                //输出查询结果的翻页信息
                PagesInfoEx pageInfo = result.result.pageInfo;
                //Message日志
                if (cdr != null || cdr.Length != 0)
                {
                    List<PointToPointCDREx> listMCU = new List<PointToPointCDREx>();
                    for (int i = 0; i < cdr.Length; i++)
                    {
                        listMCU.Add(cdr[i]);
                    }
                    MessageListLog<PointToPointCDREx> messageLog = new MessageListLog<PointToPointCDREx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }

        private void queryPointToPointCDR_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryPointToPointCDR();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryPointToPointCDR success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryPointToPointCDR fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //获取会议是否支持多画面，支持的多画面模式列表，以及当前多画面资源数
        public int getContinuousPresenceInfo()
        {
            GetContinousPresence getContinousPresence = new GetContinousPresence();
            getContinousPresence.ShowDialog();
            if (getContinousPresence.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId = getContinousPresence.confID;
            //调用会议服务中的getContinuousPresenceInfoEx方法，获取会议是否支持多画面，支持的多画面模式列表，以及当前多画面资源数
            TPSDKResponseEx<GetContinuousPresenceInfoResponseEx> result = cmService.getContinuousPresenceInfoEx(confId);
            //返回错误码，具体说明如下： 0：表示成功； 其他数值：表示失败
            if (result.resultCode == 0)
            {
                //输出会议支持的多画面类型，具体格式请参考“设置多画面参数”接口中的target描述
                string[] targets = result.result.targets;
                //输出会议多画面资源数，该值决定同时有多少个不同的子画面存在
                int cpResource = result.result.cpResource;
                //输出当前会议能支持的多画面模式列表
                int[] supportCPModes = result.result.supportCPModes;
            }
            return result.resultCode;
        }

        private void getContinuousPresenceInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.getContinuousPresenceInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "getContinuousPresenceInfo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "getContinuousPresenceInfo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //读取指定会议的多画面参数
        public int getContinuousPresenceParam()
        {
            GetContinousPresence getContinousPresence = new GetContinousPresence();
            getContinousPresence.ShowDialog();
            if (getContinousPresence.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议Id
            string confId = getContinousPresence.confID;
            //读取的多画面类型，具体格式请参考“设置多画面参数”接口中的target描述。如果读取的会议不支持指定的类型，将返回失败提示
            string target = getContinousPresence.targerType;
            //调用会议服务中的getContinuousPresenceParamEx方法，读取指定会议的多画面参数
            TPSDKResponseSecondEx<int, string[]> result = cmService.getContinuousPresenceParamEx(confId, target);
            //返回错误码，具体说明如下： 0：表示成功； 其他数值：表示失败
            if (result.resultCode == 0)
            {
                //多画面模式
                int presenceMode = result.result1;
                //子画面会场标识顺序列表
                string[] subPics = result.result2;
            }
            return result.resultCode;
        }

        private void getContinuousPresenceParam_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.getContinuousPresenceParam();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "getContinuousPresenceParam success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "getContinuousPresenceParam fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询所有的调度会议状态，支持翻页、过滤
        public int queryScheduleConferencesEx()
        {
            QueryConfig queryConfig = new QueryConfig();
            queryConfig.ShowDialog();
            if (queryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //QueryConfigEx queryConfigEx = new QueryConfigEx();

            ////对查询结果按照会场名升序方式进行排序
            //List<SortItemsEx> sortItemExs = new List<SortItemsEx>();
            //SortItemsEx sortItemEx = new SortItemsEx();
            //sortItemEx.sort = 0;
            //sortItemEx.itemIndex = 0;
            //sortItemExs.Add(sortItemEx);

            ////获取满足会场名包含vct2条件的会场
            //List<FiltersEx> filtersExs = new List<FiltersEx>();
            //StringFilterEx filtersEx = new StringFilterEx();
            //filtersEx.columnIndex = 1;
            //filtersEx.value = "VCT2";
            //filtersExs.Add(filtersEx);

            ////每页5个，获取第一页
            //PageParamEx pageParamEx = new PageParamEx();
            //pageParamEx.numberPerPage = 5;
            //pageParamEx.currentPage = 1;

            //queryConfigEx.sortItems = sortItemExs.ToArray<SortItemsEx>();
            //queryConfigEx.filters = filtersExs.ToArray<FiltersEx>();
            //queryConfigEx.focusItem = 0;
            //queryConfigEx.pageParam = pageParamEx;

            //调用会议服务的queryScheduleConferencesEx方法查询所有的调度会议状态
            //返回TPSDKResponseEx<List<ConferenceStatusEx>>对象
            TPSDKResponseEx<List<ConferenceStatusEx>> result = cmService.queryScheduleConferencesEx(queryConfig.queryConfigEx);
            if (result.resultCode == 0)
            {
                //Message 日志
                MessageListLog<ConferenceStatusEx> messageLog = new MessageListLog<ConferenceStatusEx>(result.result);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return result.resultCode;
        }

        private void queryScheduleConferencesStatus_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryScheduleConferencesEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryScheduleConferencesEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryScheduleConferencesEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //调用订阅服务的enablePushEx方法开启推送功能
        public int enablePushEx()
        {
            EnablePush enablePush = new EnablePush();
            enablePush.ShowDialog();
            if (enablePush.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            int pullMode = enablePush.pushMode;
            string extendParameter = enablePush.extendParam;
            
            int resultcode;
            resultcode = scribMgrService.enablePushEx(pullMode, extendParameter);
            return resultcode;
        }

        private void enablePush_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.enablePushEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "enablePushEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "enablePushEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //订阅或取消订阅信息的列表
        public int subscribeEx()
        {
            Subscribe subscribe = new Subscribe();
            subscribe.ShowDialog();
            if (subscribe.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            int resultcode;
            resultcode = scribMgrService.subscribeEx(subscribe.subscribeInfoExs);
            return resultcode;
        }

        private void subscribe_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.subscribeEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "subscribeEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "subscribeEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //调用订阅服务的queryNotificationEx方法读取的通知消息
        public int queryNotificationEx()
        {
            TPSDKResponseEx<List<NotificationEx>> result = scribMgrService.queryNotificationEx();
            if (result.resultCode == 0)
            {
                List<NotificationEx> orgs = result.result;
            }
            return result.resultCode;
        }

        private void queryNotification_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryNotificationEx();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryNotificationEx success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryNotificationEx fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region 会议控制接口

        //设置指定会场的视频源，即指定会议中的某个会场观看另一个会场的视频画面
        public int setVideoSource()
        {
            SetVideoSource setVS = new SetVideoSource();
            setVS.ShowDialog();
            if (setVS.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            int resultCode = ccService.setVideoSourceEx(setVS.confID, setVS.site1_URI, setVS.site2_URI, setVS.isLock);
            return resultCode;
        }

        private void setVideoSource_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setVideoSource();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setVideoSource success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setVideoSource fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //设置会议的声控切换，当声音强度达到设置好的阈值时，会场图像被广播
        public int setAudioSwitch()
        {
            SetAudioSwitch setAS = new SetAudioSwitch();
            setAS.ShowDialog();
            if (setAS.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            int resultCode = ccService.setAudioSwitchEx(setAS.confid, setAS.swtichGate, setAS.isSwitch);
            return resultCode;
        }

        private void setAudioSwitch_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setAudioSwitch();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setAudioSwitch success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setAudioSwitch fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场开始、取消广播
        public int setBroadcastSite()
        {
            SetBroadcastSite setBS = new SetBroadcastSite();
            setBS.ShowDialog();
            if (setBS.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            int resultCode = ccService.setBroadcastSiteEx(setBS.confid, setBS.siteURI, setBS.isBroadcastSite); 
            return resultCode;
        }

        private void setBroadcastSite_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setBroadcastSite();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setBroadcastSite success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setBroadcastSite fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //开始、取消广播多画面
        public int setBroadcastContinuousPresence()
        {
            SetBroadcastSite setBS = new SetBroadcastSite();
            setBS.ShowDialog();
            if (setBS.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setBroadcastContinuousPresenceEx方法，返回int对象。 
            //如果返回值为0，则表示广播多画面成功，否则，表示广播多画面失败，具体失败原因，请参考错误码列表。 
            int result = ccService.setBroadcastContinuousPresenceEx(setBS.confid, setBS.isBroadcastSite);
            return result;
        }

        private void setBroadcastContinuousPresence_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setBroadcastContinuousPresence();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setBroadcastContinuousPresence success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setBroadcastContinuousPresence fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场闭音，关闭会场麦克风输入
        public int setSitesMute()
        {
            SetSitesQuietOrMute setSM = new SetSitesQuietOrMute();
            setSM.ShowDialog();
            if (setSM.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建List对象，存放需要闭音的会场的URI 
            List<string> list = setSM.list;
            
            //调用会议服务中的setSitesMuteEx方法,返回int对象。 
            //如果返回值为0，则表示闭音成功，否则，表示闭音失败，具体失败原因，请参考错误码列表。 
            int resultCode = ccService.setSitesMuteEx(setSM.conf_ID, list, setSM.isMuteOrQuiet);
            return resultCode;
        }

        private void setSitesMute_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setSitesMute();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setSitesMute success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setSitesMute fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场静音，关闭会场扬声器输出
        public int setSitesQuiet()
        {
            SetSitesQuietOrMute setSQ = new SetSitesQuietOrMute();
            setSQ.ShowDialog();
            if (setSQ.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建List对象，存放需要闭音的会场的URI 
            List<string> list = setSQ.list; 
            
            //调用会议服务中的setSitesQuietEx方法，返回int对象。 
            //如果返回值为0，则表示静音成功，否则，表示静音失败，具体失败原因，请参考错误码列表。 
            int resultCode = ccService.setSitesQuietEx(setSQ.conf_ID, list, setSQ.isMuteOrQuiet);
            return resultCode;
        }

        private void setSitesQuiet_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setSitesQuiet();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setSitesQuiet success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setSitesQuiet fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //设置会议多画面模式及子画面信息
        public int setContinuousPresence()
        {
            SetContinuousPresence setCP = new SetContinuousPresence();
            setCP.ShowDialog();
            if (setCP.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setContinuousPresenceEx方法，返回int 
            //如果返回值为0，则表示设置成功，否则，表示设置失败，具体失败原因，请参考错误码列表。 
            List<string> subPics = setCP.list;
            string confId = setCP.conf_ID;
            string target = setCP.target;
            int type = setCP.presenceMode;
            
            int result = ccService.setContinuousPresenceEx(confId, target, type, subPics);
            return result;
        }

        private void setContinuousPresence_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setContinuousPresence();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setContinuousPresence success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setContinuousPresence fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //申请成为主席会场
        public int requestConfChair()
        {
            ConfidAndSiteURI requestChair = new ConfidAndSiteURI();
            requestChair.ShowDialog();
            if (requestChair.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的requestConfChairEx方法，申请主席
            int result = ccService.requestConfChairEx(requestChair.confID, requestChair.site_URI);
            return result;
        }

        private void requestConfChair_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.requestConfChair();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "requestConfChair success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "requestConfChair fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //释放主席
        public int releaseConfChair()
        {
            Confid releaseChair = new Confid();
            releaseChair.ShowDialog();
            if (releaseChair.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的releaseConfChairEx方法，释放主席
            int result = ccService.releaseConfChairEx(releaseChair.confid);
            return result;
        }

        private void releaseConfChair_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.releaseConfChair();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "releaseConfChair success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "releaseConfChair fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场发言
        public int setFloor()
        {
            ConfidAndSiteURI setfloor = new ConfidAndSiteURI();
            setfloor.ShowDialog();
            if (setfloor.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setFloorEx方法，示例中会议ID为86的会议指定01033001会场发言，返回int对象。
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。
            int result = ccService.setFloorEx(setfloor.confID, setfloor.site_URI);
            return result;
        }

        private void setFloor_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setFloor();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setFloor success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setFloor fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //设置会议中指定会场的音量值大小
        public int setConfSiteVolume()
        {
            SetConfSiteVolume setVolume = new SetConfSiteVolume();
            setVolume.ShowDialog();
            if (setVolume.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setConfSiteVolumeEx方法,返回int对象。
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。
            int result = ccService.setConfSiteVolumeEx(setVolume.confid, setVolume.sites);
            return result;
        }

        private void setConfSiteVolume_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setConfSiteVolume();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setConfSiteVolume success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setConfSiteVolume fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //打开会议中会场的视频
        public int displayConfSiteLocalVideo()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会场URI列表
            string[] siteUris = sitesForConference.list.ToArray();
            //调用会议服务中的displayConfSiteLocalVideoEx方法，示例中会议ID为86的会议打开01033001和01034001会场视频，返回int对象。
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。
            int result = ccService.displayConfSiteLocalVideoEx(sitesForConference.conf_ID, siteUris);

            return result;
        }

        private void displayConfSiteLocalVideo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.displayConfSiteLocalVideo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "displayConfSiteLocalVideo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "displayConfSiteLocalVideo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //关闭会议中会场的视频
        public int hideConfSiteLocalVideo()
        {
            SitesForConference sitesForConference = new SitesForConference();
            sitesForConference.ShowDialog();
            if (sitesForConference.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会场URI列表
            string[] siteUris = sitesForConference.list.ToArray();
            //调用会议服务中的HideConfSiteLocalVideoEx方法，示例中会议ID为86的会议关闭01033001和01034001会场视频，返回int对象。
            //如果返回值为0，则表示呼叫成功，否则，表示呼叫失败，具体失败原因，请参考错误码列表。
            int result = ccService.HideConfSiteLocalVideoEx(sitesForConference.conf_ID, siteUris);
            return result;
        }

        private void hideConfSiteLocalVideo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.hideConfSiteLocalVideo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "hideConfSiteLocalVideo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "hideConfSiteLocalVideo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //锁定的演示者令牌
        public int lockPresentation()
        {
            ConfidAndSiteURI lockpresentation = new ConfidAndSiteURI();
            lockpresentation.ShowDialog();
            if (lockpresentation.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议ID
            string confId = lockpresentation.confID;
            //锁定辅流令牌的会场URI
            string siteUri = lockpresentation.site_URI;
            //调用会议服务中的lockPresentationEx方法，锁定的演示者令牌
            int result = ccService.lockPresentationEx(confId, siteUri);
            return result;
        }

        private void lockPresentation_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.lockPresentation();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "lockPresentation success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "lockPresentation fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //解锁的演示者令牌
        public int unlockPresentation()
        {
            Confid unlockpresentation = new Confid();
            unlockpresentation.ShowDialog();
            if (unlockpresentation.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //会议ID
            string confId = unlockpresentation.confid;
            //调用会议服务中的unlockPresentationEx方法，解锁的演示者令牌
            int result = ccService.unlockPresentationEx(confId);

            return result;
        }

        private void unlockPresentation_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.unlockPresentation();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "unlockPresentation success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "unlockPresentation fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region 会场管理接口

        //查询所有会场列表
        public int querySites()
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
                    this.sites_dt.Rows.Add(site.uri, site.name, site.type, site.from, site.rate, "0");
                }
                //Message日志
                MessageListLog<SiteInfoEx> messageLog = new MessageListLog<SiteInfoEx>(sites);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return resultCode;
        }
        private void querySites_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.querySites();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "querySites Info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "querySites Info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询指定会场指定时间段内的忙闲状态
        public int querySiteStatus()
        {
            SiteStatus siteStatus = new SiteStatus();
            siteStatus.ShowDialog();
            if (siteStatus.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个List对象，用于存放需要查询忙闲状态的会场URI
            List<string> list = siteStatus.list;
            //示例中开始时间为8小时后
            DateTime date = siteStatus.begintime.AddHours(8);
            //需要查询的时间范围为60分钟之内
            string duration = siteStatus.duration; 
            //调用会议服务中的querySiteStatusEx方法，示例中是查询会场URI为01033001和01034001的会场从8小时后开始的60分钟内的忙闲状态，返回TPSDKResponseEx <Dictionary<string,List<FreeBusyStateEx>>>对象。
            TPSDKResponseEx<Dictionary<string, List<FreeBusyStateEx>>> result = cmService.querySiteStatusEx(list, date, duration);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //如果查询成功，则返回一个Dictionary<string, List<FreeBusyStateEx>>对象
                Dictionary<string, List<FreeBusyStateEx>> status = result.result;
            }
            return resultCode;

        }
        private void querySiteStatus_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.querySiteStatus();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "querySiteStatus info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "querySiteStatus info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        
        //指定会场在指定时间段内发生忙闲状态同步
        public int synchSiteStatus()
        {
            SiteStatus siteStatus = new SiteStatus();
            siteStatus.ShowDialog();
            if (siteStatus.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //新建一个List对象，用于存放需要查询忙闲状态的会场URI
            List<string> list = siteStatus.list;
            //示例中开始时间为8小时后
            DateTime beginTime = siteStatus.begintime;
            //需要查询的时间范围为60分钟之内
            string duration = siteStatus.duration;
            //调用会议服务中的synchSiteStatusEx方法，示例中是把会场URI为01033001和01034001的会场的忙闲状态同步，返回TPSDKResponseEx<Dictionary<string, List<FreeBusyStateEx>>>对象。
            TPSDKResponseEx<Dictionary<string, List<FreeBusyStateEx>>> result = cmService.synchSiteStatusEx(list, beginTime, duration);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //操作成功后，返回Dictionary<string, List<FreeBusyStateEx>>对象
                Dictionary<string, List<FreeBusyStateEx>> status = result.result;
            }
            return resultCode;
        }
        private void synchSiteStatus_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.synchSiteStatus();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "synchSiteStatus info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "synchSiteStatus info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //在SMC侧添加会场信息
        public int addSiteInfo()
        {
            SiteInfo siteInfo = new SiteInfo();
            siteInfo.ShowDialog();
            if (siteInfo.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的addSiteInfoEx方法，在SMC侧添加会场信息
            int result = sService.addSiteInfoEx(siteInfo.orgId, siteInfo.siteInfo);
            return result;
        }
        private void addSiteInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.addSiteInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "addSiteInfo info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "addSiteInfo info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //编辑会场信息
        public int editSiteInfo()
        {
            SiteInfo siteInfo = new SiteInfo();
            siteInfo.ShowDialog();
            if (siteInfo.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的editSiteInfoEx方法，编辑会场信息
            int result = sService.editSiteInfoEx(siteInfo.siteInfo);

            return result;
        }
        private void editSiteInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.editSiteInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "editSiteInfo info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "editSiteInfo info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //删除会场信息
        public int deleteSiteInfo()
        {
            DeleteSitesList siteInfo = new DeleteSitesList();
            siteInfo.ShowDialog();
            if (siteInfo.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //准备删除会场的URI
            string[] siteUris = siteInfo.sites_URI;
            //调用会场服务中的deleteSiteInfoEx方法，删除会场信息
            int result = sService.deleteSiteInfoEx(siteUris);
            return result;
        }
        private void deleteSiteInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.deleteSiteInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "deleteSiteInfo info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "deleteSiteInfo info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询会场信息
        public int querySiteInfo()
        {
            QueryConfig queryConfig = new QueryConfig();
            queryConfig.ShowDialog();
            if (queryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的querySitesInfoEx方法，查询会场信息
            TPSDKResponseEx<QuerySitesInfoExResponse> result = sService.querySitesInfoEx(queryConfig.queryConfigEx);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //操作成功，则根据查询条件，返回查询的会场信息列表
                TerminalInfoEx[] sites = result.result.sites;
                //输出查询结果的翻页信息
                PagesInfoEx pageInfo = result.result.pageInfo;

                //Message日志
                if (sites != null || sites.Length != 0)
                {
                    List<TerminalInfoEx> listMCU = new List<TerminalInfoEx>();
                    for (int i = 0; i < sites.Length; i++)
                    {
                        listMCU.Add(sites[i]);
                    }
                    MessageListLog<TerminalInfoEx> messageLog = new MessageListLog<TerminalInfoEx>(listMCU);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");

                    //更新会场数据
                    this.updateSiteDataTable();
                    foreach (TerminalInfoEx site in listMCU)
                    {
                        this.sites_dt.Rows.Add(site.uri, site.name, site.type, "--", site.rate, "0");
                    }
                }
            }
            return result.resultCode;
        }
        private void querySitesInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.querySiteInfo();
                
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "querySiteInfo info success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "querySiteInfo info fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        
        #endregion

        #region MCU管理接口

        //查询SMC2.0上的MCU信息列表
        public int queryMCUInfo()
        {
            QueryConfig queryConfig = new QueryConfig();
            queryConfig.ShowDialog();
            if (queryConfig.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用MCU服务中的queryMCUInfoEx方法，查询SMC 2.0 上的MCU信息列表
            TPSDKResponseSecondEx<MCUInfoEx[], PagesInfoEx> result = MCUService.queryMCUInfoEx(queryConfig.queryConfigEx);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //操作成功，则根据查询条件，返回查询的会场信息列表
                MCUInfoEx[] mcus = result.result1;
                //MessageLog
                List<MCUInfoEx> list = new List<MCUInfoEx>();
                for (int i = 0; i < mcus.Length; i++)
                {
                    list.Add(mcus[i]);
                }
                MessageListLog<MCUInfoEx> messageLog = new MessageListLog<MCUInfoEx>(list);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                //输出查询结果的翻页信息
                PagesInfoEx pageInfo = result.result2;
            }
            return result.resultCode;
        }
        private void queryMCUInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryMCUInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryMCUInfo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryMCUInfo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询未来时间MCU的资源占用情况，即查询预约会议占用的MCU的资源情况
        public int queryMCUFutureResource()
        {
            MCUFutureResource mcuFutureResource = new MCUFutureResource();
            mcuFutureResource.ShowDialog();
            if (mcuFutureResource.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //待查询资源的MCU ID列表
            int[] mcus = mcuFutureResource.mcus;
            //查询开始时间
            System.DateTime beginTime = mcuFutureResource.begintime;
            //查询间隔时长，如：P0Y0M0DT1H0M0.000S或者PT1H：表示1小时
            string duration = mcuFutureResource.duration;
            //调用MCU服务中的queryMCUFutureResourceEx方法，查询未来时间MCU的资源占用情况
            TPSDKResponseEx<MCUResourceEx[]> result = MCUService.queryMCUFutureResourceEx(mcus, beginTime, duration);
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //MCU的资源未来时间资源占用数据
                MCUResourceEx[] mcuResList = result.result;
                //MessageLog
                List<MCUResourceEx> list = new List<MCUResourceEx>();
                for (int i = 0; i < mcuResList.Length; i++)
                {
                    list.Add(mcuResList[i]);
                }
                MessageListLog<MCUResourceEx> messageLog = new MessageListLog<MCUResourceEx>(list);
                this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
            }
            return result.resultCode;
        }
        private void queryMCUFutureResource_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryMCUFutureResource();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryMCUFutureResource success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryMCUFutureResource fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        
        #endregion

        #region 组织管理接口

        //查询系统的组织节点
        public int queryOrganization()
        {
            //调用组织服务中的queryOrganizationEx方法，查询系统的组织节点
            TPSDKResponseEx<OrganizationItemEx[]> result = orgaMgrService.queryOrganizationEx();
            //返回错误码，具体说明如下：0：表示成功；其他数值：表示失败
            if (result.resultCode == 0)
            {
                //输出系统中所有组织节点信息
                OrganizationItemEx[] orgs = result.result;
                //Message日志
                if (orgs != null && orgs.Length != 0)
                {
                    List<OrganizationItemEx> list = new List<OrganizationItemEx>();
                    for (int i = 0; i < orgs.Length; i++)
                    {
                        list.Add(orgs[i]);
                    }
                    MessageListLog<OrganizationItemEx> messageLog = new MessageListLog<OrganizationItemEx>(list);
                    this.richTextBox1.AppendText(DateTime.Now.ToString() + ":" + messageLog.ToString() + "\r\n");
                }
            }
            return result.resultCode;
        }
        private void queryOrganization_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryOrganization();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryOrganization success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryOrganization fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        
        #endregion

        #region 终端管理接口

        #region 终端会控接口

        //申请主席
        public int requestChair()
        {
            SiteURI request = new SiteURI();
            request.ShowDialog();
            if (request.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的requestChairEx方法，示例中是让会场URI为01033001的会场申请主席，返回int对象。 
            //如果返回值为0，则表示申请主席成功，否则，表示申请主席失败，具体失败原因，请参考错误码列表。 
            int resultCode = terminalService.requestChairEx(request.siteURI);
            return resultCode;

        }
        private void requestChair_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.requestChair();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "requestChair success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "requestChair fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //释放主席
        public int releaseChair()
        {
            SiteURI release = new SiteURI();
            release.ShowDialog();
            if (release.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的releaseChairEx方法，示例中是让会场URI为01033001的会场释放主席，返回int对象。 
            //如果返回值为0，则表示释放主席成功，否则，表示释放主席失败，具体失败原因，请参考错误码列表。 
            int resultCode = terminalService.releaseChairEx(release.siteURI);
            return resultCode;

        }
        private void releaseChair_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.releaseChair();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "releaseChair success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "releaseChair fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询会场所在当前会议中是否存在密码
        public int queryConfCtrlPwd()
        {
            SiteURI queryPwd = new SiteURI();
            queryPwd.ShowDialog();
            if (queryPwd.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryConfCtrlPwdEx方法，示例中是查询会场URI为01033001的会场所在会议是否存在密码，返回TPSDKResponseEx<int?>对象。 
            TPSDKResponseEx<int?> result = terminalService.queryConfCtrlPwdEx(queryPwd.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回int值 
                int? hasPassword = result.result;
            }
            return resultCode;
        }
        private void queryConfCtrlPwd_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryConfCtrlPwd();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryConfCtrlPwd success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryConfCtrlPwd fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询当前会场所在会议中录播和直播的信息
        public int queryBroadInfo()
        {
            SiteURI queryBroad = new SiteURI();
            queryBroad.ShowDialog();
            if (queryBroad.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的queryBroadInfoEx方法，示例中是查询会场URI为01033001的会场所在会议的录播直播状态，返回TPSDKResponseEx<BroadInfoEx>对象。 
            TPSDKResponseEx<BroadInfoEx> result = terminalService.queryBroadInfoEx(queryBroad.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回BroadInfoEx对象 
                BroadInfoEx broadInfo = result.result;
            }
            return resultCode;
        }
        private void queryBroadInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryBroadInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryBroadInfo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryBroadInfo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //启动或停止录播
        public int setRecordBroad()
        {
            SiteAndBroad setRB = new SiteAndBroad();
            setRB.ShowDialog();
            if (setRB.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setRecordBroadEx方法，示例中是让会场URI为01033001的会议开始录播，返回int对象。 
            //如果返回值为0，则表示开始录播成功，否则，表示开始录播失败，具体失败原因，请参考错误码列表。 
            int resultCode = terminalService.setRecordBroadEx(setRB.siteURI, setRB.isBroad);
            return resultCode;
        }
        private void setRecordBroad_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setRecordBroad();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setRecordBroad success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setRecordBroad fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //启动或停止直播
        public int setDirectBroad()
        {
            SiteAndBroad setDB = new SiteAndBroad();
            setDB.ShowDialog();
            if (setDB.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会议服务中的setRecordBroadEx方法，示例中是让会场URI为01033001的会议开始录播，返回int对象。 
            //如果返回值为0，则表示开始录播成功，否则，表示开始录播失败，具体失败原因，请参考错误码列表。 
            int resultCode = terminalService.setDirectBroadEx(setDB.siteURI, setDB.isBroad);
            return resultCode;
        }
        private void setDirectBroad_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setDirectBroad();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setDirectBroad success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setDirectBroad fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region 辅流管理

        //查询是否接入辅流输入源
        public int sConnectAuxSource()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的isConnectAuxSourceEx方法，示例中是查询会场URI为01033001的会场是否接入辅流视频源，返回TPSDKResponseEx<int?>对象。 
            TPSDKResponseEx<int?> result = sService.isConnectAuxSourceEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回int对象 
                int? isConnectAuxSource = result.result;
            }
            return resultCode;
        }
        private void sConnectAuxSource_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.sConnectAuxSource();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "sConnectAuxSource success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "sConnectAuxSource fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询当前是否正在发送辅流
        public int isSendAuxStream()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的isSendAuxStreamEx方法，示例中是查询会场URI为01033001的会场是否正在发送辅流，返回TPSDKResponseEx<int?>对象。 
            TPSDKResponseEx<int?> result = sService.isSendAuxStreamEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回int对象 
                int? isSendAuxStream = result.result;
            }
            return resultCode;

        }
        private void isSendAuxStream_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.isSendAuxStream();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "isSendAuxStream success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "isSendAuxStream fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //查询是否正在接收远端辅流
        public int isReceiveRemAuxStrm()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的isReceiveRemAuxStrmEx方法，示例中是查询会场URI为01033001的会场是否正在接收辅流，返回TPSDKResponseEx<int?>对象。 
            TPSDKResponseEx<int?> result = sService.isReceiveRemAuxStrmEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回int对象 
                int? isReceiveRemAuxStrm = result.result;
            }
            return resultCode;
        }
        private void isReceiveRemAuxStrm_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.isReceiveRemAuxStrm();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "isReceiveRemAuxStrm success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "isReceiveRemAuxStrm fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场辅流发送控制
        public int setAuxStream()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的setAuxStreamEx方法，示例中是让会场URI为01033001的会场停止发送辅流，返回int对象。 
            //如果返回值为0，则表示停止发送辅流成功，否则，表示停止发送辅流失败，具体失败原因，请参考错误码列表。 
            int resultCode = sService.setAuxStreamEx(site.siteURI, 1);
            return resultCode;
        }
        private void setAuxStream_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setAuxStream();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setAuxStream success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setAuxStream fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //获取辅流视频源列表
        public int queryAuxStreamSources()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            TPSDKResponseEx<Dictionary<int, string>> result = sService.queryAuxStreamSourcesEx(site.siteURI);
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //获取成功后，返回一个Dictionary<int,string>对象。其中KEY为辅流视频源ID，VALUE为辅流视频源名称 
                Dictionary<int, string> Dictionary = result.result;
            }
            return resultCode;
        }
        private void queryAuxStreamSources_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryAuxStreamSources();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryAuxStreamSources success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryAuxStreamSources fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region 音视频控制

        //查询视频输入口接入视频源状态
        public int queryVideoOutSrcState()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的queryVideoOutSrcStateEx方法来查询视频源输入口接入视频源状态，返回 
            //TPSDKResponseEx< List<VideoSourcesInfoEx>>对象，示例中是查询会场URI为01033001的视频源输入口接入视频源状态 
            TPSDKResponseEx<List<VideoSourcesInfoEx>> result = sService.queryVideoOutSrcStateEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回一个List<VideoSourcesInfoEx>对象 
                List<VideoSourcesInfoEx> list = result.result;
            }
            return resultCode;
        }
        private void queryVideoOutSrcState_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryVideoOutSrcState();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryVideoOutSrcState success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryVideoOutSrcState fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //指定会场摄像头控制
        public int ctrlCamera()
        {
            CameraControl cameraControl = new CameraControl();
            cameraControl.ShowDialog();
            if (cameraControl.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的ctrlCamera方法，示例中是让会场URI为01033001的会场输入口为1的摄像头开始向左平移，返回int对象。 
            //如果返回值为0，则表示控制成功，否则，表示控制失败，具体失败原因，请参考错误码列表。 
            int resultCode = sService.ctrlCameraEx(cameraControl.siteURI, cameraControl.cameraConrtrol);
            return resultCode;

        }
        private void ctrlCamera_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.ctrlCamera();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "ctrlCamera success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "ctrlCamera fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //设置主流视频源、辅流视频源
        public int setMainAuxStreamSources()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的setMainAuxStreamSourcesEx方法，示例中设置会场URI为01033001的会场的主流和辅流视频源，返回int对象。  
            //参数localMainSrc和localAuxSrc需分别调用queryMainStreamSourcesEx 和queryAuxStreamSourcesEx获取  
            List<int?> localMainSrc = new List<int?>(); 
            localMainSrc.Add(0); 
            //localMainSrc.Add(1); 
            //如果返回值为0，则表示设置成功，否则，表示设置失败，具体失败原因，请参考错误码列表。  
            int resultCode = sService.setMainAuxStreamSourcesEx(site.siteURI, localMainSrc, 0);
            return resultCode;
        }
        private void setMainAuxStreamSources_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setMainAuxStreamSources();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setMainAuxStreamSources success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setMainAuxStreamSources fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //获取主流视频源的下拉列表框内容
        public int queryMainStreamSources()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的queryMainStreamSourcesEx方法来获取主流视频源，返回 
            //TPSDKResponseEx<Dictionary<int,string>>对象，示例中是查询会场URI为01033001的主流视频源信息 
            TPSDKResponseEx<Dictionary<int, string>> result = sService.queryMainStreamSourcesEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回一个Dictionary<int,string>对象，其中KEY为主流视频源ID，VALUE为主流视频源名称 
                Dictionary<int, string> Dictionary = result.result;
            }
            return resultCode;
        }
        private void queryMainStreamSources_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.queryMainStreamSources();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "queryMainStreamSources success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "queryMainStreamSources fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //改变输出口显示内容
        public int setVideoOutSrc()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的setVideoOutSrcEx方法，示例中是将会场URI为01034001的视频输出口ID为0的输出口显示本地主流，返回int对象。 
            //如果返回值为0，则表示设置成功，否则，表示设置失败，具体失败原因，请参考错误码列表。 
            int resultCode = sService.setVideoOutSrcEx(site.siteURI, 0, 0);
            return resultCode;

        }
        private void setVideoOutSrc_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.setVideoOutSrc();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "setVideoOutSrc success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "setVideoOutSrc fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
        #endregion

        #region 版本与状态接口

        //查询获取会场终端型号/版本信息
        public int querySiteVersionInfo()
        {
            SiteURI site = new SiteURI();
            site.ShowDialog();
            if (site.DialogResult == DialogResult.Cancel)
            {
                return -1;
            }
            //调用会场服务中的querySiteVersionInfoEx方法来查询获取终端型号/版本信息，返回 
            //TPSDKResponseEx<SiteDeviceVersionInfoEx>对象，示例中是查询会场URI为01033001的终端的信息 
            TPSDKResponseEx<SiteDeviceVersionInfoEx> result = sService.querySiteVersionInfoEx(site.siteURI);
            //调用TPSDKResponseEx<T>中的resultCode方法，获取返回码，如果返回码为0，则表示成功，否则，表示失败，具体失败原因，请参考错误码列表。 
            int resultCode = result.resultCode;
            if (0 == resultCode)
            {
                //查询成功后，返回一个SiteDeviceVersionInfoEx对象 
                SiteDeviceVersionInfoEx siteDeviceVersionInfo = result.result;
            }
            return resultCode;
        }
        private void querySiteVersionInfo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int result = this.querySiteVersionInfo();
                if (result == 0)
                {
                    this.WriteLog("Run", 0, "querySiteVersionInfo success:" + result.ToString());
                }
                else
                {
                    this.WriteLog("Run", 0, "querySiteVersionInfo fail:" + result.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #endregion

        #region 日志管理代码
      
        public void WriteLog(string logType, int level, string param)
        {
            try
            {
                TPLogMgr.Log_Run(level, param);
                
                if (!this.LogGridView.InvokeRequired)
                {
                    switch (level)
                    {
                        case 0:
                            this.log_dt.Rows.Add(logType, "Debug", param);
                            break;
                        case 1:
                            this.log_dt.Rows.Add(logType, "Info", param);
                            break;
                        case 2:
                            this.log_dt.Rows.Add(logType, "Warn", param);
                            break;
                        case 3:
                            this.log_dt.Rows.Add(logType, "Error", param);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            finally
            {
                this.LogGridView.DataSource = log_dt;
            }
        }

        public void updateSiteDataTable()
        {
            if (this.sites_dt != null)
            {
                this.sites_dt = null;
            }
            //初始化会议ID的datatable
            this.sites_dt = new DataTable();
            this.sites_dt.Columns.Add("siteURI");
            this.sites_dt.Columns.Add("siteName");
            this.sites_dt.Columns.Add("siteType");
            this.sites_dt.Columns.Add("siteFrom");
            this.sites_dt.Columns.Add("siteRate");
            this.sites_dt.Columns.Add("checked");
            DataColumn[] column = new DataColumn[] { this.sites_dt.Columns["siteURI"] };
            this.sites_dt.PrimaryKey = column;
            this.siteGridView.DataSource = sites_dt;
            this.siteGridView.Update();          
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                if (MessageBox.Show("确定清除日志码？", "确认", messButton) == DialogResult.OK)
                {
                    if (this.log_dt != null)
                    {
                        this.log_dt = null;
                    }
                    this.log_dt = new DataTable();
                    this.log_dt.Columns.Add("logType");
                    this.log_dt.Columns.Add("logLevel");
                    this.log_dt.Columns.Add("logContent");
                    this.LogGridView.DataSource = log_dt;

                    this.richTextBox1.Text = string.Empty;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
       
        #endregion               
       
    }
}
