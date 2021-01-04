namespace TodoListMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "StatusTask", c => c.String());
            DropColumn("dbo.Tasks", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Status", c => c.String());
            DropColumn("dbo.Tasks", "StatusTask");
        }
    }
}
