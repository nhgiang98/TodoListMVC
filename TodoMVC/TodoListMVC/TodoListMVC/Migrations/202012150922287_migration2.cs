﻿namespace TodoListMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Role");
        }
    }
}