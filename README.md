##eSDK TP NATIVE SDK CShape
华为eSDK提供的eSDK TP NATIVE SDK CShape可以快速为合作伙伴提供统一账号管理、视频会议调度、会议控制等业务能力。
##版本信息
V2.1.00
##开发环境
- 操作系统：Windows7专业版
- Microsoft Visual Studio:Visual Studio 2013专业版（支持.NET 4.5.2）
##文档指引
- src文件夹：包含TP NATIVE SDK CShape的dll以及其依赖的日志库
- sample文件夹：包含eSDK提供的场景化展示样例
- doc:包含eSDK提供的开发指南文档和接口文档
##入门指引
在开始阅读本章节前，请至[远程实验室](http://developer.huawei.com/ict/cn/remotelab "远程实验室")企业云通信(EC)的调测环境，以方便后续操作
###接入视讯系统
- 业务流程<br/><br/>
  用户登入(Login) -> 保持心跳(Keepalive) -> 用户登出(Logout)
  <br/>
  <br/> 
- 流程说明
  1. 第三方应用程序(Application)调用login接口向eSDK TP Server请求登入。并携带有用户名和密码。eSDK TP Server返回登录结果。
  2. 每隔一段时间(小于60s,建议30s),第三方应用程序调用keepAlive接口向eSDK TP Server请求保活。
  3. 在调用完所有业务接口后，第三方应用程序调用logout接口向eSDK TP Server请求登出。
  <br/>
  <br/>
- 前提条件
  1. eSDK TP Server上的SMC服务已正确配置并启动，并已获取eSDK TP Server服务地址、端口、账号、密码。eSDK TP安装配置过程及结果验证请参考《eSDK TP V100R005C70安装配置指南》。
  2. 已获取eSDK TP SDK软件包。
  <br/>
  <br/>
- 实现说明<br/>
  **步骤一：用户登入**<br/>
  **`AuthorizeServiceEx authorService = AuthorizeServiceEx.Instance();`<br/>
  `/// <summary>`<br/>
  `/// 登入SMC系统`<br/>
  `/// </summary>`<br/>
  `private void Login_Click(object sender, EventArgs e)`<br/>
  `{`<br/>
  　　`try`<br/>
  　　`{`<br/>
  　　　　`string userName=this.textBox1.Text.ToString();`<br/>
  　　　　`string password=this.textBox2.Text.ToString();`<br/>
  　　　　`int result = authorService.Login(userName,password);`<br/>
　　　　  `if (result == 0)`<br/>
　　　　  `{`<br/>
　　　　　　  `this.Login.Text = "Login succ";`<br/>
 　　　　　　 `//登入成功，开启保活线程`<br/>
　　　　　　  `Thread thread = new Thread(new ThreadStart(this.KeepAliveThread));`<br/>
　　　　　　  `thread.Start();`<br/>
　　　　  `}`<br/>
　　  　　`this.ConsoleLog("Login resultCode = " + result.ToString());`<br/>
　　 `}`<br/>
　　 `catch (Exception error)`<br/>
　　 `{`<br/>
　　 `MessageBox.Show(error.ToString());`<br/>
　　 `}`<br/>
  `}`<br/>**
  <br/>
  **步骤二：用户保活**<br/>
  **`// 用户登录认证后的保持心跳计时器`<br/>
  `private System.Timers.Timer timer = null;`<br/>
  `//保持心跳间隔时间30s`<br/>
  `private double aliveTime = 30000;`<br/>
  `//计时器设置`<br/>
  `private void KeepAliveThread()`<br/>
  `{`<br/>
  　　`timer = new System.Timers.Timer();`<br/>
  　　`timer.Interval = aliveTime;`<br/>
  　　`//定时触发AliveCode事件`<br/>
  　　`timer.Elapsed += new System.Timers.ElapsedEventHandler(AliveCode);`<br/>
  　　`timer.AutoReset = true;`<br/>
  　　`timer.Enabled = true;`<br/>
  `}`<br/>
  `//调用AuthorizeServiceEx中的KeepAlive接口`<br/>
  `private void AliveCode(object sender, System.Timers.ElapsedEventArgs e)`<br/>
  `{`<br/>
  　　`int result = authorService.KeepAlive();`<br/>
  `}`<br/>**
　<br/>
  **步骤三：用户登出**<br/>
  **`/// <summary>`<br/>
  `/// 登出SMC系统`<br/>
  `/// </summary>`<br/>
  `private void Logout_Click(object sender, EventArgs e)`<br/>
  `{`<br/>
  　　`if (Login.Text == "Login succ")`<br/>
  　　`{`<br/>
  　　　　`int result = authorService.Logout();`<br/>
  　　　　`if (result == 0)`<br/>
  　　　　`{`<br/>
  　　　　　　`this.Login.Text = "Login";`<br/>
 　　　　 `}`<br/>
 　　　　 `this.ConsoleLog("Logout resultCode = " + result.ToString());`<br/>
 　　 `}`<br/>
  `}`<br/>**
 

##获取帮助
在开发过程中，您有任何问题均可以至[DevCenter](https://devcenter.huawei.com/uniportal/login;jsessionid=1E1896F28071BC2F2785E516912A7F4C?execution=e1s1 "DevCenter")中提单跟踪。也可以在[华为开发者社区](http://bbs.csdn.net/forums/hwucdeveloper "华为开发者社区")中查找或提问。另外，华为热线电话：400-822-9999 (转二次开发)