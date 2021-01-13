namespace PDS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductVersion", "SalesChannels", c => c.Int());
            AlterColumn("dbo.ProductVersion", "StateCoverge", c => c.Int());
            AlterColumn("dbo.ProductVersion", "Scale", c => c.Int());
            AlterColumn("dbo.ProductVersion", "ScaleQuoteMap", c => c.Int());
            AlterColumn("dbo.ProductVersion", "CoPayment", c => c.Int());
            AlterColumn("dbo.ProductVersion", "AccidentWaiver", c => c.Int());
            AlterColumn("dbo.ProductVersion", "DaySurgeryWaiver", c => c.Int());
            AlterColumn("dbo.ProductVersion", "ChildrenWaiver", c => c.Int());
            AlterColumn("dbo.ProductVersion", "StaffSubsidy", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductVersion", "StaffSubsidy", c => c.String());
            AlterColumn("dbo.ProductVersion", "ChildrenWaiver", c => c.String());
            AlterColumn("dbo.ProductVersion", "DaySurgeryWaiver", c => c.String());
            AlterColumn("dbo.ProductVersion", "AccidentWaiver", c => c.String());
            AlterColumn("dbo.ProductVersion", "CoPayment", c => c.String());
            AlterColumn("dbo.ProductVersion", "ScaleQuoteMap", c => c.String());
            AlterColumn("dbo.ProductVersion", "Scale", c => c.String());
            AlterColumn("dbo.ProductVersion", "StateCoverge", c => c.String());
            AlterColumn("dbo.ProductVersion", "SalesChannels", c => c.String());
        }
    }
}
