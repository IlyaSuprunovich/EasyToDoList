using System.Drawing;

namespace EasyToDoList
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderForName = new System.Windows.Forms.Panel();
            this.AddToDo = new System.Windows.Forms.Button();
            this.InputNameToDo = new System.Windows.Forms.TextBox();
            this.NameOfProject = new System.Windows.Forms.Label();
            this.ArrayForToDoListItem = new System.Windows.Forms.FlowLayoutPanel();
            this.HeaderForName.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderForName
            // 
            this.HeaderForName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(169)))));
            this.HeaderForName.Controls.Add(this.AddToDo);
            this.HeaderForName.Controls.Add(this.InputNameToDo);
            this.HeaderForName.Controls.Add(this.NameOfProject);
            this.HeaderForName.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderForName.Location = new System.Drawing.Point(0, 0);
            this.HeaderForName.Name = "HeaderForName";
            this.HeaderForName.Size = new System.Drawing.Size(1182, 143);
            this.HeaderForName.TabIndex = 0;
            // 
            // AddToDo
            // 
            this.AddToDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(155)))), ((int)(((byte)(194)))));
            this.AddToDo.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddToDo.Location = new System.Drawing.Point(947, 46);
            this.AddToDo.Name = "AddToDo";
            this.AddToDo.Size = new System.Drawing.Size(123, 52);
            this.AddToDo.TabIndex = 2;
            this.AddToDo.Text = "Add";
            this.AddToDo.UseVisualStyleBackColor = false;
            this.AddToDo.Click += new System.EventHandler(this.AddToDo_Click);
            // 
            // InputNameToDo
            // 
            this.InputNameToDo.AccessibleDescription = "";
            this.InputNameToDo.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputNameToDo.ForeColor = System.Drawing.Color.Gray;
            this.InputNameToDo.Location = new System.Drawing.Point(500, 46);
            this.InputNameToDo.Multiline = true;
            this.InputNameToDo.Name = "InputNameToDo";
            this.InputNameToDo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InputNameToDo.Size = new System.Drawing.Size(423, 52);
            this.InputNameToDo.TabIndex = 1;
            this.InputNameToDo.Text = "Input name your ToDo";
            this.InputNameToDo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.InputNameToDo.Enter += new System.EventHandler(this.InputNameToDo_Enter);
            this.InputNameToDo.Leave += new System.EventHandler(this.InputNameToDo_Leave);
            // 
            // NameOfProject
            // 
            this.NameOfProject.AutoSize = true;
            this.NameOfProject.Font = new System.Drawing.Font("Verdana", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfProject.Location = new System.Drawing.Point(79, 46);
            this.NameOfProject.Name = "NameOfProject";
            this.NameOfProject.Size = new System.Drawing.Size(352, 51);
            this.NameOfProject.TabIndex = 0;
            this.NameOfProject.Text = "Easy ToDoList";
            // 
            // ArrayForToDoListItem
            // 
            this.ArrayForToDoListItem.AutoScroll = true;
            this.ArrayForToDoListItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.ArrayForToDoListItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ArrayForToDoListItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArrayForToDoListItem.Location = new System.Drawing.Point(0, 143);
            this.ArrayForToDoListItem.Margin = new System.Windows.Forms.Padding(0);
            this.ArrayForToDoListItem.Name = "ArrayForToDoListItem";
            this.ArrayForToDoListItem.Size = new System.Drawing.Size(1182, 510);
            this.ArrayForToDoListItem.TabIndex = 1;
            this.ArrayForToDoListItem.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.ArrayForToDoListItem);
            this.Controls.Add(this.HeaderForName);
            this.Name = "Form1";
            this.Text = "ToDoList";
            this.HeaderForName.ResumeLayout(false);
            this.HeaderForName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderForName;
        private System.Windows.Forms.Label NameOfProject;
        private System.Windows.Forms.Button AddToDo;
        public System.Windows.Forms.TextBox InputNameToDo;
        public System.Windows.Forms.FlowLayoutPanel ArrayForToDoListItem;
        private System.Windows.Forms.Panel BodyForToDoListItem;
        private System.Windows.Forms.Label HeaderForToDoListItem;
        private System.Windows.Forms.CheckedListBox ListForTasks;
        private System.Windows.Forms.TextBox InputNameOfTask;
        private System.Windows.Forms.Button AddTaskInToDoList;
    }
}

