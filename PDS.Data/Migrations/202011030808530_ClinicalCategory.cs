namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClinicalCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClinicalItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicalCategoryId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
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
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClinicalCategory", t => t.ClinicalCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ClinicalCategoryId)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClinicalProductCategory", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ClinicalProductCategory", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropForeignKey("dbo.ClinicalItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ClinicalItem", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropIndex("dbo.ClinicalProductCategory", new[] { "ProductCategoryId" });
            DropIndex("dbo.ClinicalProductCategory", new[] { "ClinicalCategoryId" });
            DropIndex("dbo.ClinicalItem", new[] { "ItemId" });
            DropIndex("dbo.ClinicalItem", new[] { "ClinicalCategoryId" });
            DropTable("dbo.ClinicalProductCategory");
            DropTable("dbo.ClinicalItem");
        }
    }
}
