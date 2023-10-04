using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EasyToDoList
{
    public partial class Form1 : Form
    {
        private Dictionary<string, ToDoList> _ToDoLists;
        private List<TextBox> _TaskTextBoxes;
        private CreateFormToDoList _CreateFormToDoList;

        public Form1()
        {
            this._TaskTextBoxes = new List<TextBox>();
            this._CreateFormToDoList = new CreateFormToDoList();
            InitializeComponent();
            InitializeDataFromDb();
        }

        private void InitializeDataFromDb()//Клас для работы с бд
        {
            _ToDoLists = new Dictionary<string, ToDoList>();
            
            using (ApplicationContext context = new ApplicationContext())
            {
                List<ToDoList> toDoListsFromDb = context.ToDoLists.ToList();
                List<Task> tasksFromDb = context.Tasks.ToList();

                foreach (var toDo in toDoListsFromDb)
                {
                    AddFormToDoList(toDo.Name);
                    _ToDoLists[toDo.Name] = toDo;

                    foreach (var task in tasksFromDb)
                        if (toDo.Id == task.IdToDoList)
                            ListForTasks.Items.Add(task.Name); 
                }   
            }
        }

        private void InputNameToDo_Leave(object sender, EventArgs e)
        {
            if (InputNameToDo.Text == string.Empty)
            {
                InputNameToDo.Text = "Input name your ToDo";
                InputNameToDo.ForeColor = Color.Gray;
            }
        }

        private void InputNameToDo_Enter(object sender, EventArgs e)
        {
            if (InputNameToDo.Text == "Input name your ToDo")
            {
                InputNameToDo.Text = "";
                InputNameToDo.ForeColor = Color.Black;
            }
        }

        private void AddToDo_Click(object sender, EventArgs e)//Класс Для работы с бд
        {
            AddFormToDoList(InputNameToDo.Text);
            using (ApplicationContext context = new ApplicationContext())
            {
                ToDoList toDoList = new ToDoList()
                {
                    Name = InputNameToDo.Text,
                    Tasks = new List<Task>()
                };
                context.ToDoLists.Add(toDoList);
                context.SaveChanges();
            }
            InputNameToDo.Text = "";
        }

        private void AddFormToDoList(string inputText)//класс для работы с формами 
        {
            BodyForToDoListItem = new Panel();
            BodyForToDoListItem.Name = inputText + "Panel";
            BodyForToDoListItem.Location = new Point(40, 105);
            BodyForToDoListItem.Size = new Size(200, 330);
            BodyForToDoListItem.BackColor = ColorTranslator.FromHtml("#91C8E4");
            BodyForToDoListItem.Margin = new Padding(15, 40, 15, 0);
            ArrayForToDoListItem.Controls.Add(BodyForToDoListItem);

            HeaderForToDoListItem = new Label();
            HeaderForToDoListItem.Name = inputText + "Label";
            HeaderForToDoListItem.BackColor = ColorTranslator.FromHtml("#91C8E4");
            HeaderForToDoListItem.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
            HeaderForToDoListItem.Text = inputText;
            HeaderForToDoListItem.Font = new Font(inputText, 14, NameOfProject.Font.Style);
            HeaderForToDoListItem.Padding = new Padding(0, 10, 0, 0);
            HeaderForToDoListItem.AutoSize = false;
            HeaderForToDoListItem.Location = new Point(0, 0);
            HeaderForToDoListItem.Size = new Size(200, 40);
            BodyForToDoListItem.Controls.Add(HeaderForToDoListItem);

            ListForTasks = new CheckedListBox();
            ListForTasks.Name = inputText + "CheckedListBox";
            ListForTasks.Location = new Point(15, 50);
            ListForTasks.Size = new Size(170, 240);
            ListForTasks.Font = new Font(ListForTasks.Items.ToString(), 10);
            BodyForToDoListItem.Controls.Add(ListForTasks);

            InputNameOfTask = new TextBox();
            InputNameOfTask.Name = inputText + "TextBox";
            InputNameOfTask.Multiline = true;
            InputNameOfTask.Location = new Point(15, 293);
            InputNameOfTask.Size = new Size(110, 25);
            InputNameOfTask.TextAlign = HorizontalAlignment.Right;
            InputNameOfTask.Font = new Font(InputNameOfTask.Text, 10);
            BodyForToDoListItem.Controls.Add(InputNameOfTask);

            InputNameOfTask.Tag = ListForTasks;
            _TaskTextBoxes.Add(InputNameOfTask);

            AddTaskInToDoList = new Button();
            AddTaskInToDoList.Name = inputText;
            AddTaskInToDoList.Location = new Point(135, 291);
            AddTaskInToDoList.Size = new Size(50, 28);
            AddTaskInToDoList.BackColor = Color.White;
            AddTaskInToDoList.Text = "Add";
            AddTaskInToDoList.BackColor = ColorTranslator.FromHtml("#749BC2");
            AddTaskInToDoList.Click += AddTaskInToDoList_Click;
            BodyForToDoListItem.Controls.Add(AddTaskInToDoList);
            /*            _CreateFormToDoList.AddFormToDoList(InputNameToDo.Text, ArrayForToDoListItem, _TaskTextBoxes);
                        */

        }

        private void AddTaskInToDoList_Click(object sender, EventArgs e)//Класс для работы с бд
        {
            Button addButton = (Button)sender;

            using (ApplicationContext context = new ApplicationContext())
            {
                ToDoList toDoList = context.ToDoLists.ToList().Find(x => x.Name == addButton.Name);
                foreach (TextBox taskTextBox in _TaskTextBoxes)
                    if (taskTextBox.Text != String.Empty)
                    {
                        Task task = new Task()
                        {
                            Name = taskTextBox.Text,
                            IdToDoList = toDoList.Id
                        };
                        context.Tasks.Add(task);
                        context.SaveChanges();
                        if (taskTextBox.Tag is ListBox listBox)
                            listBox.Items.Add(taskTextBox.Text);
                        taskTextBox.Text = "";
                    }
            }
        }
    }
}
