using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    //TODO:2.添加模型类
    /* 1.右键单击项目。 选择“添加” > “新建文件夹”。 将文件夹命名为“Models”
     * 2.右键单击“Models”文件夹，然后选择“添加” > “类”。 将类命名为 TodoItem，然后选择“添加”
     */
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
