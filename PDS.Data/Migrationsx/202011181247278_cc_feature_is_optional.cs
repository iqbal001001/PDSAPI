namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc_feature_is_optional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feature", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropIndex("dbo.Feature", new[] { "ClinicalCategoryId" });
            AlterColumn("dbo.Feature", "ClinicalCategoryId", c => c.Int());
            CreateIndex("dbo.Feature", "ClinicalCategoryId");
            AddForeignKey("dbo.Feature", "ClinicalCategoryId", "dbo.ClinicalCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feature", "ClinicalCategoryId", "dbo.ClinicalCategory");
            DropIndex("dbo.Feature", new[] { "ClinicalCategoryId" });
            AlterColumn("dbo.Feature", "ClinicalCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Feature", "ClinicalCategoryId");
            AddForeignKey("dbo.Feature", "ClinicalCategoryId", "dbo.ClinicalCategory", "Id", cascadeDelete: true);
        }
    }
}
