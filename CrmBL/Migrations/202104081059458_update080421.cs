﻿namespace CrmBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update080421 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Checks", "Price");
        }
    }
}
