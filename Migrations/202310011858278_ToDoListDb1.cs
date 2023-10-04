namespace EasyToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoListDb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Tasks", "IdToDoList", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Tasks", "IdToDoList");
        }
    }
}
