using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TestDb;

namespace EasyToDoList
{
    public partial class Form1 : Form
    {
        private CreateFormToDoList _CreateFormToDoList { get; set; }
        private WorkWithDb _WorkWithDb { get; set; }

        public Form1()
        {
            InitializeComponent();
            this._CreateFormToDoList = new CreateFormToDoList(this);
            this._WorkWithDb = new WorkWithDb(this._CreateFormToDoList, this);
            this._WorkWithDb.InitializeDataFromDb();
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

        private void AddToDo_Click(object sender, EventArgs e)
        {
            _CreateFormToDoList.AddFormToDoList(InputNameToDo.Text);
            _WorkWithDb.AddToDo_Click(sender, e);
            InputNameToDo.Text = "";
        }
    }
}
