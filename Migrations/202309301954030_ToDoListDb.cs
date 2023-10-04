namespace EasyToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoListDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ToDoList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.ToDoLists", t => t.ToDoList_Id)
                .Index(t => t.ToDoList_Id);
            
            CreateTable(
                "public.ToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Tasks", "ToDoList_Id", "public.ToDoLists");
            DropIndex("public.Tasks", new[] { "ToDoList_Id" });
            DropTable("public.ToDoLists");
            DropTable("public.Tasks");
        }
    }
}
