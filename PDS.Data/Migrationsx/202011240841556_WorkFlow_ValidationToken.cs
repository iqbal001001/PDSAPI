namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkFlow_ValidationToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlowItem", "ValiationToken", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlowItem", "ValiationToken");
        }
    }
}
