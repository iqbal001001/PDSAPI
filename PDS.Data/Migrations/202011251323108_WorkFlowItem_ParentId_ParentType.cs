namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkFlowItem_ParentId_ParentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlowItem", "ParentId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkFlowItem", "ParentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlowItem", "ParentType");
            DropColumn("dbo.WorkFlowItem", "ParentId");
        }
    }
}
