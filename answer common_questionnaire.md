对于以下问题的作答有些参考自网络（来自网络的附有链接），但是我认为知识是共享的，学习是开源的，对于一些新的知识可以从网上获取并学习，接下来就是总结和吸收，灵活应用知识去解决问题。

# DevOps
简单理解：Dev（开发） + Ops （运维）

是一组过程、方法与系统的统称，用于促进开发（应用程序/软件工程）、技术运营和质量保障（QA）部门之间的沟通、协作与整合。
(待完善……)
# 死锁
定义：多个进程循环等待其他进程占有的资源而无限期地等待下去。

进程A占用了资源R1
进程B占用了资源R2
进程A等待进程B占用的资源R2
进程B等待进程A占用的资源R1

eg：
可能的情况：子线程获取了锁lock1后睡眠，睡眠过程中主线程获取了锁lock2，此时子线程睡眠结束等待锁lock2，此时lock2被主线程占用，主线程等待锁lock1，但是lock1又被子线程占用，这样主线程和子线程就一直等着多方占用的资源，造成两个线程一直阻塞，这种现象称为死锁。
```csharp
    class Program
    {
        public static object lock1 = new object();
        public static object lock2 = new object();
        public void DoSomething()
        {
           
            lock (lock1)
            {
                Thread.Sleep(500);
                Console.WriteLine($"子线程{Thread.CurrentThread.ManagedThreadId}获取了锁lock1，等待获取锁lock2");
                lock (lock2)
                {
                    Console.WriteLine("没出现这句话表示死锁了");
                }
            }
        }

        static void Main()
        {
            Program a = new Program();
            Thread th = new Thread(new ThreadStart(a.DoSomething));
            th.Start();

            lock (lock2) 
            {

                Console.WriteLine("主线程获取了锁lock2，等待获取锁lock1");
                lock (lock1)
                {
                    Console.WriteLine("没出现这句话表示死锁了");
                }
            }

            Console.WriteLine("没出现这句话表示死锁了");
        } 

    }
```
代码参考：https://blog.csdn.net/xufox/article/details/16331287

# http 状态码
类比淘宝购物

|状态码|简单描述|详细描述|
| :-- | :-- | :-- |
|200|成功|购物成功
|400|错误请求|商家不知道卖家买什么型号的商品       
|401|身份验证错误|买家提供了假身份
|403|禁止|商家拒绝发货
|500|服务器内部错误|商家遇到问题无法发货

# 编译型语言 vs 解释型语言

|语言|定义|优点|缺点|
| :-- | :-- | :-- | :-- |
|编译型语言(eg:C/C++)|先将源代码编译成机器能识别的机器语言，机器直接运行编译后的机器语言|执行效率高，耗内存少|依赖平台，不安全(能访问内存的任何区域) ，不适合web开发|
|解释型语言(eg:java)|源代码不需要预先编译，运行时先解释再运行|跨平台,运行时安全检查(适合web开发)|耗内存和cpu资源|

# SQL查询
users
|user_id|user_name|
| :-- | :-- |
|1|Jane Doe|
|2|John Doe|
|3|jack R. Mills|

tasks
|task_id|task_name
| :-- | :-- |
|1|Go to gym|
|2|Meet friends at 11 bar|
|3|Write weekly technical report to Francisco|

made_by
|id|user_id|task_id
| :-- | :-- | :-- |
|1|1|2|
|2|2|1|
|3|3|3|

查询指定username对应的任务列表:

```sql
select t.task_name 
    from made_by m 
    join tasks t on m.task_id = t.task_id 
    join users u on m.user_id = u.user_id
    where u.user_name = 'jane Doe';
```
# docker容器 vs 虚拟机
(待完善……)

#  OAUTH2 vs d  OpenID Connect
## 开放认证协议

[OAUTH2](http://www.ruanyifeng.com/blog/2014/05/oauth_2_0.html)

![框图](http://www.ruanyifeng.com/blogimg/asset/2014/bg2014051203.png)

（A）用户打开客户端以后，客户端要求用户给予授权。

（B）用户同意给予客户端授权。

（C）客户端使用上一步获得的授权，向认证服务器申请令牌。

（D）认证服务器对客户端进行认证以后，确认无误，同意发放令牌。

（E）客户端使用令牌，向资源服务器申请获取资源。

（F）资源服务器确认令牌无误，同意向客户端开放资源。

[OpenID Connect](https://help.aliyun.com/document_detail/48019.html)

(待完善……)
# a squash merge vs a merge
(待完善……)