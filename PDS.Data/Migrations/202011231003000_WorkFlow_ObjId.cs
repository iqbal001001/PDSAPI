namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkFlow_ObjId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlowItem", "ObjId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlowItem", "ObjId");
        }
    }
}
