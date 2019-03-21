using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    //TODO:3.添加数据库上下文
    /* DbContext,是负责数据与对象互操作的主要的类型。它主要负责以下一些动作：
     * EntitySet : DbContext 包含所有从数据库表中被映射出来的实体对象的集合（如DbSet<TEntity>）。
     * Querying : DbContext 将LINQ To Entities 转化为SQL 查询语句并发送至数据库。
     * Change Tracking : 它保持变更追踪，一旦实体对象发生改变它就会从数据库中进行查询。
     * Persisting Data : 它也可以基于实体状态对数据库进行插入，更新和删除操作。
     * Caching : DbContext 默认作一级缓存，它存储在上下文类的生命周期中检索过的实体对象。
     * Manage Relationship : 在DB-First 或 Model-First 中 DbContext 使用CSDL, MSL 和 SSDL 管理关系，在Code-First中使用流式API管理关系。
     * Object Materialization ： DbContext 将原始的表数据转化至实体对象中。
     * 
     * 
     * Entity Framework
     * 是一个对象关系映射(ORM)框架，它能使开发人员用关系型数据定义特定领域的对象，并且开发人员不再需要编写大量的数据库访问代码
     * 
    */
    public class TodoContext : DbContext//TODO:了解下DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
