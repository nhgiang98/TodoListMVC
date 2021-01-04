namespace TodoListMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Status");
        }
    }
}
