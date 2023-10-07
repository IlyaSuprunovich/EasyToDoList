using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToDoList
{
    public class Task 
    {
        public int Id { get; set; }
        public int IdToDoList { get; set; }
        public string Name { get; set; }
       
        public virtual ToDoList ToDoList { get; set; }
    }
}
