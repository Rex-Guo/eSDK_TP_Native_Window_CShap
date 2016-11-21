##TP Native CShape SDK
TP Native PC开发的SDK主要接口包括：鉴权管理、会议预约会议控制
会场管理、MCU管理等能力。

###V.1.5.70
####1、增加8个新的接口功能，如下所示：
- **会议查询功能**

　　1、queryScheduleConferencesEx（查询会议状态列表）

- **Adhoc会议功能接口**
  
　　2、addAdhocConfTemplateEx（添加Adhoc会议模板）

　　3、editAdhocConfTemplateEx（编辑Adhoc会议模板）

　　4、delAdhocConfTemplateEx（删除Adhoc会议模板）

　　5、queryAdhocConfTemplateListEx（查询Adhoc会议模板列表）

- **消息推送功能**

　　6、enablePushEx（开启消息推送功能）
       
　　7、subscribeEx（订阅或取消订阅）
       
　　8、queryNotificationEx（读取通知消息）
####2、编译SDK的.Net版本升级，支持TLS1.1协议
　　目前.net版本以升级到.net framework 4.5.2