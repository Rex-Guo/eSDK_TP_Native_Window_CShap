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
using System.Net;

using com.huawei.esdk.tp.professional.eSDKPlatformKeyMgrService;
using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace TP_Native_Demo
{
    public partial class eSDK_TP_Native_Demo : Form
    {
        AuthorizeServiceEx authorService;
        public eSDK_TP_Native_Demo()
        {
            InitializeComponent();
            authorService = AuthorizeServiceEx.Instance();
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
                this.ConsoleLog("Login resultCode = " + result.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Login succ")
            {
                int result = authorService.Logout();
                if (result == 0)
                {
                    this.Login.Text = "Login";
                }
                this.ConsoleLog("Logout resultCode = " + result.ToString());
            }
        }
    }
}
