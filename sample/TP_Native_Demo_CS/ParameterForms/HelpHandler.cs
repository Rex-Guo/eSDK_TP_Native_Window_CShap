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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.huawei.esdk.tp.professional.DataType;
using com.huawei.esdk.tp.professional.local;

namespace TP_Native_Demo
{
    public class HelpHandler
    {
        
        public void TextBoxEmptyChecked(Control container)
        {
            if (container.Controls.Count != 0)
            {
                foreach (Control c in container.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c.Text == string.Empty)
                        {
                            throw new Exception(c.Name.ToString() + ":is empty,please check");
                        }
                    }
                }
            }
        }

    }

    public class MessageLog<T>
    {
        public object tempClass;
        
        //构造函数
        public MessageLog(T obj)
        {
            this.tempClass = obj;
        }
        
        public override string ToString()
        {
            if (tempClass != null)
            {
                if (typeof(T) == typeof(ConferenceInfoEx))
                {
                    ConferenceInfoEx temp = (ConferenceInfoEx)tempClass;
                    if (temp.sites != null&&temp.beginTime!=null)
                    {
                        StringBuilder buffer = new StringBuilder();
                        buffer.Append("(");
                        for (int i = 0; i < temp.sites.Length; i++)
                        {
                            buffer.Append("name = " + temp.sites[i].name + "," + "uri = " + temp.sites[i].uri);
                            if (i < temp.sites.Length - 1)
                            {
                                buffer.Append(";");
                            }
                        }
                        buffer.Append(")");
                        return "{confId = " + temp.confId + ",Name = " + temp.name + ",Status = " + temp.status + ",accessCode = " + temp.accessCode + ",beginTime = " + temp.beginTime.ToString() + ",sites = " + buffer.ToString() + "}";
                    }
                    return "{confId = " + temp.confId + ",Name = " + temp.name + ",Status = " + temp.status + ",accessCode = " + temp.accessCode + ",sites = null" + "}";
                }
                else if (typeof(T) == typeof(RecurrenceConfInfoEx))
                {
                    RecurrenceConfInfoEx temp = (RecurrenceConfInfoEx)tempClass;
                    return "{confId = " + temp.confId + ",Name = " + temp.name + ",Status = " + temp.status + ",accessCode = " + temp.accessCode + "}";
                }
                else if (typeof(T) == typeof(ConferenceStatusEx))
                {
                    ConferenceStatusEx temp = (ConferenceStatusEx)tempClass;
                    return "{confId = " + temp.id + ",Name = " + temp.name + ",Status = " + temp.status + ",beginTime = " + temp.beginTime + "}";
                }
                else if (typeof(T) == typeof(SiteStatusEx))
                {
                    SiteStatusEx temp = (SiteStatusEx)tempClass;
                    return "{siteUri = " + temp.uri + ",Name = " + temp.name + ",Status = " + temp.status + "}";
                }
                else if (typeof(T) == typeof(SiteAccessInfoEx))
                {
                    SiteAccessInfoEx temp = (SiteAccessInfoEx)tempClass;
                    return "{siteUri = " + temp.uri + ",Name = " + temp.name + ",confaccessCode = " + temp.confAccessCode + "}";
                }
                else if (typeof(T) == typeof(SiteMCUEx))
                {
                    SiteMCUEx temp = (SiteMCUEx)tempClass;
                    return "{siteUri = " + temp.siteUri + ",mcuId = " + temp.mcuId + "}";
                }
                else if (typeof(T) == typeof(AdhocConfFreeBusyStateEx))
                {
                    AdhocConfFreeBusyStateEx temp = (AdhocConfFreeBusyStateEx)tempClass;
                    StringBuilder buffer = new StringBuilder();
                    buffer.Append("(");
                    for (int i = 0; i < temp.freebusys.Length; i++)
                    {
                        buffer.Append("confId = "+temp.freebusys[i].confId + "," +"state = "+ temp.freebusys[i].state);
                        if (i < temp.freebusys.Length - 1)
                        {
                            buffer.Append(";");
                        }
                    }
                    buffer.Append(")");
                    return "{confAccessCode = " + temp.confAccessCode + ",freebusys = " + buffer.ToString() + "}";
                }
                else if (typeof(T) == typeof(AdhocConferenceEx))
                {
                    AdhocConferenceEx temp = (AdhocConferenceEx)tempClass;
                    return "{Name = " + temp.name + ",confaccessCode = " + temp.confAccessCode + "}";
                }
                else if (typeof(T) == typeof(AdhocConfTemplateParamEx))
                {
                    AdhocConfTemplateParamEx temp = (AdhocConfTemplateParamEx)tempClass;
                    return "{Name = " + temp.name +",adhocConfTemplateId = " + temp.adhocConfTemplateId + ",accessCode = " + temp.accessCode + "}";
                }
                else if (typeof(T) == typeof(MultiPointCDREx))
                {
                    MultiPointCDREx temp = (MultiPointCDREx)tempClass;
                    return "{siteName = " + temp.siteName + ",siteUri = " + temp.siteUri + ",siteType = " + temp.siteType.ToString() +
                        ",conferenceName = " + temp.conferenceName + ",conferenceId = " + temp.conferenceId + "}";
                }
                else if (typeof(T) == typeof(PointToPointCDREx))
                {
                    PointToPointCDREx temp = (PointToPointCDREx)tempClass;
                    return "{callingUri = " + temp.callingUri + ",calledUri = " + temp.calledUri  + "}";
                }
                else if (typeof(T) == typeof(NotificationEx))
                {
                    NotificationEx temp = (NotificationEx)tempClass;
                    return "{" + "}";
                }
                else if (typeof(T) == typeof(TerminalInfoEx))
                {
                    TerminalInfoEx temp = (TerminalInfoEx)tempClass;
                    return "{siteName = " +temp.name+",siteUri = "+temp.uri+",siteType = "+temp.type.ToString()+ "}";
                }
                else if (typeof(T) == typeof(SiteInfoEx))
                {
                    SiteInfoEx temp = (SiteInfoEx)tempClass;
                    return "{siteName = " + temp.name + ",siteUri = " + temp.uri + ",siteType = " + temp.type.ToString() + "}";
                }
                else if (typeof(T) == typeof(OrganizationItemEx))
                {
                    OrganizationItemEx temp = (OrganizationItemEx)tempClass;
                    return "{Name = " + temp.name + ",id = " + temp.id + "}";
                }
                else if (typeof(T) == typeof(MCUResourceEx))
                {
                    MCUResourceEx temp = (MCUResourceEx)tempClass;
                    MCUResourceItemEx[] temp1 = temp.resourceList;
                    StringBuilder buffer1 = new StringBuilder();
                    StringBuilder buffer2 = new StringBuilder();
                    buffer1.Append("(");
                    for(int i=0;i<temp1.Length;i++)
                    {
                        ResourceOccupiedStatusEx[] temp2 = temp1[i].resourceStatus;
                        buffer1.Append(temp1[i].resourceType.ToString());
                        buffer2.Append("(");
                        for(int j=0;j<temp2.Length;j++)
                        {
                            ResourceOccupiedStatusEx temp3 = temp2[i];
                            buffer2.Append("freeCount = "+temp3.freeCount+",totalCount = "+temp3.totalCount);
                            if (i < temp2.Length - 1)
                            {
                                buffer2.Append(";");
                            }
                        }
                        if (i < temp1.Length - 1)
                        {
                            buffer1.Append(";");
                        }
                    }

                    buffer1.Append(")");
                    buffer2.Append(")");
                    return "{mcuId = " + temp.mcuId + ",resourceType = " + buffer1.ToString() + ",Count = "+buffer2.ToString()+"}";
                }
                else if (typeof(T) == typeof(MCUInfoEx))
                {
                    MCUInfoEx temp = (MCUInfoEx)tempClass;
                    return "{mucName = " + temp.name + ",mcuId = " + temp.id + "}";
                }
                else
                {
                    return "No this class type !";
                }

            }
            return "object is null!";
        }
    }

    public class MessageListLog<T>
    {
        public List<object> tempClass;
        //构造函数
        public MessageListLog(List<T> list)
        {
            if (list != null || list.Count != 0)
            {
                this.tempClass = new List<object>();
                for (int i = 0; i < list.Count; i++)
                {
                    this.tempClass.Add(list[i]);
                }
            }
        }

        public override string ToString()
        {
            if (this.tempClass == null || this.tempClass.Count == 0)
            {
                return "object is null!";
            }
            StringBuilder buffer = new StringBuilder();

            if (typeof(T) == typeof(ConferenceStatusEx))
            {
                MessageLog<ConferenceStatusEx> messageLog;
                ConferenceStatusEx temp;                
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (ConferenceStatusEx)tempClass[i];
                    messageLog = new MessageLog<ConferenceStatusEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(SiteStatusEx))
            {
                MessageLog<SiteStatusEx> messageLog;
                SiteStatusEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (SiteStatusEx)tempClass[i];
                    messageLog = new MessageLog<SiteStatusEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(SiteAccessInfoEx))
            {
                MessageLog<SiteAccessInfoEx> messageLog;
                SiteAccessInfoEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (SiteAccessInfoEx)tempClass[i];
                    messageLog = new MessageLog<SiteAccessInfoEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(SiteMCUEx))
            {
                MessageLog<SiteMCUEx> messageLog;
                SiteMCUEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (SiteMCUEx)tempClass[i];
                    messageLog = new MessageLog<SiteMCUEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(AdhocConfFreeBusyStateEx))
            {
                MessageLog<AdhocConfFreeBusyStateEx> messageLog;
                AdhocConfFreeBusyStateEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (AdhocConfFreeBusyStateEx)tempClass[i];
                    messageLog = new MessageLog<AdhocConfFreeBusyStateEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(AdhocConferenceEx))
            {
                MessageLog<AdhocConferenceEx> messageLog;
                AdhocConferenceEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (AdhocConferenceEx)tempClass[i];
                    messageLog = new MessageLog<AdhocConferenceEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(AdhocConfTemplateParamEx))
            {
                MessageLog<AdhocConfTemplateParamEx> messageLog;
                AdhocConfTemplateParamEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (AdhocConfTemplateParamEx)tempClass[i];
                    messageLog = new MessageLog<AdhocConfTemplateParamEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(MultiPointCDREx))
            {
                MessageLog<MultiPointCDREx> messageLog;
                MultiPointCDREx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (MultiPointCDREx)tempClass[i];
                    messageLog = new MessageLog<MultiPointCDREx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(PointToPointCDREx))
            {
                MessageLog<PointToPointCDREx> messageLog;
                PointToPointCDREx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (PointToPointCDREx)tempClass[i];
                    messageLog = new MessageLog<PointToPointCDREx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(NotificationEx))
            {
                MessageLog<NotificationEx> messageLog;
                NotificationEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (NotificationEx)tempClass[i];
                    messageLog = new MessageLog<NotificationEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(TerminalInfoEx))
            {
                MessageLog<TerminalInfoEx> messageLog;
                TerminalInfoEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (TerminalInfoEx)tempClass[i];
                    messageLog = new MessageLog<TerminalInfoEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(SiteInfoEx))
            {
                MessageLog<SiteInfoEx> messageLog;
                SiteInfoEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (SiteInfoEx)tempClass[i];
                    messageLog = new MessageLog<SiteInfoEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(OrganizationItemEx))
            {
                MessageLog<OrganizationItemEx> messageLog;
                OrganizationItemEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (OrganizationItemEx)tempClass[i];
                    messageLog = new MessageLog<OrganizationItemEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(MCUResourceEx))
            {
                MessageLog<MCUResourceEx> messageLog;
                MCUResourceEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (MCUResourceEx)tempClass[i];
                    messageLog = new MessageLog<MCUResourceEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else if (typeof(T) == typeof(MCUInfoEx))
            {
                MessageLog<MCUInfoEx> messageLog;
                MCUInfoEx temp;
                for (int i = 0; i < tempClass.Count; i++)
                {
                    temp = (MCUInfoEx)tempClass[i];
                    messageLog = new MessageLog<MCUInfoEx>(temp);
                    buffer.Append(messageLog.ToString());
                    if (i < tempClass.Count - 1)
                    {
                        buffer.Append(";");
                    }
                }
                return buffer.ToString();
            }
            else
            {
                return "No this class type or object is null!";
            }           
        }
    }
}
