using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyToDoList
{
    public class CreateFormToDoList
    {
        public Panel BodyForToDoListItem { get; set; }
        public Label HeaderForToDoListItem { get; set; }
        public CheckedListBox ListForTasks { get; set; }
        public TextBox InputNameOfTask { get; set; } 
        public Button AddTaskInToDoList { get; set; }
        public List<TextBox> TaskTextBoxes { get; set; }


        private Form1 _Form1 { get; set; }
        

        public CreateFormToDoList( Form1 form)
        {
            this._Form1 = form;
            this.TaskTextBoxes = new List<TextBox>();   
        }

        public void AddFormToDoList(string inputText)
        {
            BodyForToDoListItem = new Panel();
            BodyForToDoListItem.Name = inputText + "Panel";
            BodyForToDoListItem.Location = new Point(40, 105);
            BodyForToDoListItem.Size = new Size(200, 330);
            BodyForToDoListItem.BackColor = ColorTranslator.FromHtml("#91C8E4");
            BodyForToDoListItem.Margin = new Padding(15, 40, 15, 0);
           _Form1.ArrayForToDoListItem.Controls.Add(BodyForToDoListItem);

            HeaderForToDoListItem = new Label();
            HeaderForToDoListItem.Name = inputText + "Label";
            HeaderForToDoListItem.BackColor = ColorTranslator.FromHtml("#91C8E4");
            HeaderForToDoListItem.TextAlign = (ContentAlignment)HorizontalAlignment.Center;
            HeaderForToDoListItem.Text = inputText;
            HeaderForToDoListItem.Font = new Font(inputText, 14, System.Drawing.FontStyle.Bold);
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
            TaskTextBoxes.Add(InputNameOfTask);

            AddTaskInToDoList = new Button();
            AddTaskInToDoList.Name = inputText;
            AddTaskInToDoList.Location = new Point(135, 291);
            AddTaskInToDoList.Size = new Size(50, 28);
            AddTaskInToDoList.BackColor = Color.White;
            AddTaskInToDoList.Text = "Add";
            AddTaskInToDoList.BackColor = ColorTranslator.FromHtml("#749BC2");
            AddTaskInToDoList.Click += AddTaskInToDoList_Click;
            BodyForToDoListItem.Controls.Add(AddTaskInToDoList);
        }

        private void AddTaskInToDoList_Click(object sender, EventArgs e)
        {
            Button addButton = (Button)sender;

            using (ApplicationContext context = new ApplicationContext())
            {
                ToDoList toDoList = context.ToDoLists.ToList().Find(x => x.Name == addButton.Name);
                foreach (TextBox taskTextBox in TaskTextBoxes)
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
