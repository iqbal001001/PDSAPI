namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkFlow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkFlowItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Json = c.String(),
                        Type = c.String(),
                        API = c.String(),
                        ApprovalStatus = c.Int(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkFlowItem");
        }
    }
}
