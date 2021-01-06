namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomRate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductLineId = c.Int(nullable: false),
                        HospitalTypeId = c.Int(nullable: false),
                        AccessTypeId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessType", t => t.AccessTypeId, cascadeDelete: true)
                .ForeignKey("dbo.HospitalType", t => t.HospitalTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductLine", t => t.ProductLineId, cascadeDelete: true)
                .ForeignKey("dbo.RoomRateType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.ProductLineId)
                .Index(t => t.HospitalTypeId)
                .Index(t => t.AccessTypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.HospitalType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductLine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodeId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCode", t => t.CodeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductVersion", t => t.VersionId, cascadeDelete: true)
                .Index(t => t.CodeId)
                .Index(t => t.VersionId);
            
            CreateTable(
                "dbo.ProductCode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        Excess = c.Int(nullable: false),
                        HospitalRanking = c.Int(nullable: false),
                        ExtrasRanking = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ancillary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutCodeId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCode", t => t.ProdutCodeId, cascadeDelete: true)
                .Index(t => t.ProdutCodeId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureItemId = c.Int(nullable: false),
                        Code = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        SpecialtyCode = c.String(unicode: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                        ProviderNumber = c.String(unicode: false),
                        BenefitReplacementPeriod = c.Int(nullable: false),
                        ReasonabilityRules = c.String(unicode: false),
                        AssessorRules = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feature", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        WaitingPeriod = c.Int(nullable: false),
                        IsMentalHealthWaiver = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        ClinicalCategoryId = c.Int(),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicalCategory", t => t.ClinicalCategoryId)
                .ForeignKey("dbo.FeatureGroup", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.FeatureType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.GroupId)
                .Index(t => t.ClinicalCategoryId);
            
            CreateTable(
                "dbo.ClinicalCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClinicalItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicalCategoryId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicalCategory", t => t.ClinicalCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ClinicalCategoryId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ClinicalProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicalCategoryId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicalCategory", t => t.ClinicalCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ClinicalCategoryId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductExcess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductLineId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Excess = c.Int(nullable: false),
                        PerEpisodic = c.Boolean(nullable: false),
                        PerAdult = c.Boolean(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExcessGroup", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ExcessType", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductLine", t => t.ProductLineId, cascadeDelete: true)
                .Index(t => t.ProductLineId)
                .Index(t => t.TypeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.ExcessGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExcessType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductVersion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        SalesChannels = c.Int(),
                        MinAgeOfOldesPersion = c.String(unicode: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        StateCoverge = c.Int(),
                        Scale = c.Int(),
                        ScaleQuoteMap = c.Int(),
                        CoPayment = c.Int(),
                        AccidentWaiver = c.Int(),
                        DaySurgeryWaiver = c.Int(),
                        ChildrenWaiver = c.Int(),
                        Description = c.String(unicode: false),
                        StaffSubsidy = c.Boolean(),
                        PerEpisodic = c.Int(nullable: false),
                        SuiteId = c.Int(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductSuite", t => t.SuiteId, cascadeDelete: true)
                .Index(t => t.SuiteId);
            
            CreateTable(
                "dbo.ProductSuite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.RoomRateType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Limit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LimitTypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Percentage = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LimitType", t => t.LimitTypeId, cascadeDelete: true)
                .Index(t => t.LimitTypeId);
            
            CreateTable(
                "dbo.LimitType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DisplayName = c.String(unicode: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkFlowItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Json = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        ParentId = c.Int(nullable: false),
                        ParentType = c.String(unicode: false),
                        API = c.String(unicode: false),
                        ApprovalStatus = c.Int(nullable: false),
                        ObjId = c.Int(nullable: false),
                        ValiationToken = c.Guid(nullable: false),
                        UpdatedBy = c.String(unicode: false),
                        UpdatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedBy = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Limit", "LimitTypeId", "dbo.LimitType");
            DropForeignKey("dbo.RoomRate", "TypeId", "dbo.RoomRateType");
            DropForeignKey("dbo.ProductVersion", "SuiteId", "dbo.ProductSuite");
            DropForeignKey("dbo.ProductSuite", "CategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductLine", "VersionId", "dbo.ProductVersion");
            DropForeignKey("dbo.RoomRate", "ProductLineId", "dbo.ProductLine");
            DropForeignKey("dbo.ProductExcess", "ProductLineId", "dbo.ProductLine");
            DropForeignKey("dbo.ProductExcess", "TypeId", "dbo.ExcessType");
            DropForeignKey("dbo.ProductExcess", "GroupId", "dbo.ExcessGroup");
            DropForeignKey("dbo.ProductLine", "CodeId", "dbo.ProductCode");
            DropForeignKey("dbo.Ancillary", "ProdutCodeId", "dbo.ProductCode");
            DropForeignKey("dbo.FeatureItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Feature", "TypeId", "dbo.FeatureType");
            DropForeignKey("dbo.FeatureItem", "FeatureId", "dbo.Feature");
            DropForeignKey("dbo.Feature", "GroupId", "dbo.FeatureGroup");
            DropForeignKey("dbo.Feature", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropForeignKey("dbo.ClinicalProductCategory", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ClinicalProductCategory", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropForeignKey("dbo.ClinicalItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ClinicalItem", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropForeignKey("dbo.Ancillary", "ItemId", "dbo.Item");
            DropForeignKey("dbo.RoomRate", "HospitalTypeId", "dbo.HospitalType");
            DropForeignKey("dbo.RoomRate", "AccessTypeId", "dbo.AccessType");
            DropIndex("dbo.Limit", new[] { "LimitTypeId" });
            DropIndex("dbo.ProductSuite", new[] { "CategoryId" });
            DropIndex("dbo.ProductVersion", new[] { "SuiteId" });
            DropIndex("dbo.ProductExcess", new[] { "GroupId" });
            DropIndex("dbo.ProductExcess", new[] { "TypeId" });
            DropIndex("dbo.ProductExcess", new[] { "ProductLineId" });
            DropIndex("dbo.ClinicalProductCategory", new[] { "ProductCategoryId" });
            DropIndex("dbo.ClinicalProductCategory", new[] { "ClinicalCategoryId" });
            DropIndex("dbo.ClinicalItem", new[] { "ItemId" });
            DropIndex("dbo.ClinicalItem", new[] { "ClinicalCategoryId" });
            DropIndex("dbo.Feature", new[] { "ClinicalCategoryId" });
            DropIndex("dbo.Feature", new[] { "GroupId" });
            DropIndex("dbo.Feature", new[] { "TypeId" });
            DropIndex("dbo.FeatureItem", new[] { "ItemId" });
            DropIndex("dbo.FeatureItem", new[] { "FeatureId" });
            DropIndex("dbo.Ancillary", new[] { "ItemId" });
            DropIndex("dbo.Ancillary", new[] { "ProdutCodeId" });
            DropIndex("dbo.ProductLine", new[] { "VersionId" });
            DropIndex("dbo.ProductLine", new[] { "CodeId" });
            DropIndex("dbo.RoomRate", new[] { "TypeId" });
            DropIndex("dbo.RoomRate", new[] { "AccessTypeId" });
            DropIndex("dbo.RoomRate", new[] { "HospitalTypeId" });
            DropIndex("dbo.RoomRate", new[] { "ProductLineId" });
            DropTable("dbo.WorkFlowItem");
            DropTable("dbo.LimitType");
            DropTable("dbo.Limit");
            DropTable("dbo.RoomRateType");
            DropTable("dbo.ProductSuite");
            DropTable("dbo.ProductVersion");
            DropTable("dbo.ExcessType");
            DropTable("dbo.ExcessGroup");
            DropTable("dbo.ProductExcess");
            DropTable("dbo.FeatureType");
            DropTable("dbo.FeatureGroup");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ClinicalProductCategory");
            DropTable("dbo.ClinicalItem");
            DropTable("dbo.ClinicalCategory");
            DropTable("dbo.Feature");
            DropTable("dbo.FeatureItem");
            DropTable("dbo.Item");
            DropTable("dbo.Ancillary");
            DropTable("dbo.ProductCode");
            DropTable("dbo.ProductLine");
            DropTable("dbo.HospitalType");
            DropTable("dbo.RoomRate");
            DropTable("dbo.AccessType");
        }
    }
}
