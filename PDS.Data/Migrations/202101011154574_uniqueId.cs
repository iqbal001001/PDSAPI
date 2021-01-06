namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.RoomRate", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.HospitalType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductLine", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductCode", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.Ancillary", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.Item", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.FeatureItem", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.Feature", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ClinicalCategory", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ClinicalItem", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ClinicalProductCategory", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductCategory", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.FeatureGroup", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.FeatureType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductExcess", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ExcessGroup", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ExcessType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductVersion", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductSuite", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.RoomRateType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.Limit", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.LimitType", "UniqueId", c => c.Guid(nullable: false));
            AddColumn("dbo.WorkFlowItem", "UniqueId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlowItem", "UniqueId");
            DropColumn("dbo.LimitType", "UniqueId");
            DropColumn("dbo.Limit", "UniqueId");
            DropColumn("dbo.RoomRateType", "UniqueId");
            DropColumn("dbo.ProductSuite", "UniqueId");
            DropColumn("dbo.ProductVersion", "UniqueId");
            DropColumn("dbo.ExcessType", "UniqueId");
            DropColumn("dbo.ExcessGroup", "UniqueId");
            DropColumn("dbo.ProductExcess", "UniqueId");
            DropColumn("dbo.FeatureType", "UniqueId");
            DropColumn("dbo.FeatureGroup", "UniqueId");
            DropColumn("dbo.ProductCategory", "UniqueId");
            DropColumn("dbo.ClinicalProductCategory", "UniqueId");
            DropColumn("dbo.ClinicalItem", "UniqueId");
            DropColumn("dbo.ClinicalCategory", "UniqueId");
            DropColumn("dbo.Feature", "UniqueId");
            DropColumn("dbo.FeatureItem", "UniqueId");
            DropColumn("dbo.Item", "UniqueId");
            DropColumn("dbo.Ancillary", "UniqueId");
            DropColumn("dbo.ProductCode", "UniqueId");
            DropColumn("dbo.ProductLine", "UniqueId");
            DropColumn("dbo.HospitalType", "UniqueId");
            DropColumn("dbo.RoomRate", "UniqueId");
            DropColumn("dbo.AccessType", "UniqueId");
        }
    }
}
