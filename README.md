# MvcSignalR
MVC的SignalR例子,这是一个SignalR学习的学习例子，从网上下载的QQ模板，简单修改，用SignalR模拟QQ消息
# SignalR学习
> ASP.NET SignalR 是为.NET 开发者提供即时通讯Web 应用的类库。即时通讯Web服务就是服务器将内容自动推送到已经连接的客户端，而不是服务器等待客户端发起一个新的数据请求。SignalR简化了构建实时应用的过程，它包括了一个Asp .Net服务器端库和一个Js端库，集成了数种常见的消息传输方式，如long polling，WebSocket，并提供相应的Api供开发人员选择如何调用，帮助其可以简单快速地实现客户端与服务器端相互间的实时通信。
当环境条件合适时，SignalR将WebSocket作为底层传输方式的优先实现，当然，它也能很高效地回退到其他技术。同时，SignalR提供了非常良好的Api以供远程调用(RPC) 浏览器中的js代码。

### SignalR的优点
> 1. SignalR 不仅能够自动管理连接，而且能够同时向所有的客户端广播消息，就像聊天室一样。你也能够发送消息到指定的客户端。SignalR提供的连接是持久的，它不像传统的HTTP连接需要为每次收发消息建立单独的连接。
> 2. SignalR 同时在服务端提供了远程过程调用协议（RPC），让你能够“主动”推送消息到浏览器中的客户端，而不像普通的Web服务一样的应答方式。
> 3. SignalR 应用能够运用到成千的客户端上，通过使用服务总线、SQL Server或者Redis。
> 4. SignalR 是开源的，能够通过GitHub很容易得到。

### 应用场景
> 1. 即时响应应用,例如：在线聊天，游戏，天气或者股票信息
> 2. 用户需要随时更新数据的网页运用，例如：仪表盘和监控运用，其他协同应用程序（文档协同操作）、工作流更新或者是即时表格
> 3. 高频繁从服务器更新的应用，例如：实时在线游戏

### 官方网址
> 1. https://docs.microsoft.com/en-us/aspnet/signalr/  
> 2. https://github.com/SignalR/SignalR  

### 运行示例图
![运行图](https://github.com/jasonhua95/MvcSignalR/blob/master/rundemo.jpg)
