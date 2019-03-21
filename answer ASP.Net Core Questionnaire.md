# 三种不同方式的实例代码实现两个整数相加求和

# ASP.NET Core中Filter的原理及系统包含的Filter类型
Filter是AOP（面向切片编程）编程思想的一种实现方式，聚焦核心业务逻辑，权限/异常/日志/缓存/事务等通用功能在相应的过滤器中实现。

Filter类型：
- 1.Authorization(身份认证)
- 2.Action
- 3.Result
- 3.Exception(异常)

原理分析:

以下是对Filter的默认实现，可以看出有四种类型接口分别是IAuthorizationFilter，IActionFilter，IResultFilter，IExceptionFilter，默认实现是对这些接口的实现，同时也继承了FilterAttribute这个特性类。所以Filter是通过在方法上添加相应的特性(Attribute)，在运行过程中通过反射获取特性，并执行特定的操作。
```csharp
public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
{...}
public abstract class ActionFilterAttribute : FilterAttribute, IActionFilter, IResultFilter
{...}
public class HandleErrorAttribute : FilterAttribute, IExceptionFilter
{...}
```
# 在ASP.NET Core中如何实现依赖注入
在ASP.NET Core中DI的核心分为两个组件：
- IServiceCollection 负责注册
- IServiceProvider   负责提供实例

## 1.定义一个接口IOperation及其实现Operation
```csharp
public interface IOperation
{ 
    Guid OperationId { get; }
}

public class Operation
{
    private Guid _guid;
    public Guid OperationId => _guid;
    
    public Operation() 
    {
        _guid = Guid.NewGuid();
    }
}
```

## 2.在Startup.cs的方法ConfigureServices中注册
```csharp
public void ConfigureServices(IServiceCollection services)
{
    //Transient:每次都会创建一个新的实例
    services.AddTransient<IOperation, Operation>();
    //Singleto:整个应用程序生命周期内只创建一个实例
    services.AddSingleton<IOperation, Operation>();
    //Scoped:在同一个Scope内只初始化一个实例
    services.AddScoped<IOperation, Operation>();


    /*可以通过GetService获取实例
    var provider = services.BuildServiceProvider();
    using (var scope = provider.CreateScope())
    {
        var p = scope.ServiceProvider;
        var scopeobj = p.GetService<IOperation>();
        var transient = p.GetService<IOperation>();
        var singleton = p.GetService<IOperation>();
    }
    */
    services.AddMvc();
)
```

## 3.依赖注入到控制器
```csharp
private IOperation _operatione;
public XXController(IOperation operatione)
{
    _operatione = operatione;
}
```

## 4.依赖注入到视图
```html 
@inject IOperation operatione
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head></head>
<body>
  @operatione.OperationId
</body>
</html>
```
