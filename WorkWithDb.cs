using EasyToDoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ApplicationContext = EasyToDoList.ApplicationContext;

namespace TestDb
{
    public class WorkWithDb
    {
        public Dictionary<string, ToDoList> ToDoLists { get; set; }

        private CreateFormToDoList _CreateFormToDoList { get; set; }
        private Form1 _Form1 { get; set; }


        public WorkWithDb(CreateFormToDoList createFormToDoList, Form1 form1)
        {
            this._CreateFormToDoList = createFormToDoList;
            this._Form1 = form1;
        }

        public void InitializeDataFromDb()
        {
            ToDoLists = new Dictionary<string, ToDoList>();

            using (ApplicationContext context = new ApplicationContext())
            {
                List<ToDoList> toDoListsFromDb = context.ToDoLists.ToList();
                List<Task> tasksFromDb = context.Tasks.ToList();

                foreach (var toDo in toDoListsFromDb)
                {
                    _CreateFormToDoList.AddFormToDoList(toDo.Name);
                    ToDoLists[toDo.Name] = toDo;

                    foreach (var task in tasksFromDb)
                        if (toDo.Id == task.IdToDoList)
                            _CreateFormToDoList.ListForTasks.Items.Add(task.Name);
                }
            }
        }

        public void AddToDo_Click(object sender, EventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                ToDoList toDoList = new ToDoList()
                {
                    Name = _Form1.InputNameToDo.Text,
                    Tasks = new List<Task>()
                };
                context.ToDoLists.Add(toDoList);
                context.SaveChanges();
            }
        }
    }
}
