using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS.Data
{
    public class PDSDBContext : DbContext
    {
        public PDSDBContext() : base("name=PDSDBContext")
        {
        }

        public DbSet<ProductSuite> ProductSuites { get; set; }
        public DbSet<ProductVersion> ProductVersions { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductCode> ProductCodes { get; set; }
        public DbSet<ProductExcess> ProductExcesses { get; set; }
        public DbSet<ExcessType> ExcessTypes { get; set; }
        public DbSet<ExcessGroup> ExcessGroups { get; set; }
        public DbSet<RoomRate> RoomRates { get; set; }
        public DbSet<HospitalType> HospitalTypes { get; set; }
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<RoomRateType> RoomRateTypes { get; set; }

        public DbSet<FeatureGroup> FeatureGroups { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureType> FeatureTypes { get; set; }
        public DbSet<ClinicalCategory> ClinicalCategories { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<LimitType> LimitTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<FeatureItem> FeatureItems { get; set; }

        public DbSet<WorkFlowItem> WorkFlowItems { get; set; }




        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();

        //    builder.Entity<ProductSuite>()
        //   .Property(b => b.Name).HasMaxLength(50);
        //    builder.Entity<ProductVersion>()
        //.Property(b => b.).HasMaxLength(50);
            // Primary keys
            builder.Entity<ProductSuite>()
                .HasKey(q => q.Id)
                .HasMany(q => q.Versions);

            builder.Entity<ProductCategory>()
              .HasKey(q => q.Id);

            builder.Entity<ProductVersion>()
              .HasKey(q => q.Id)
               .HasMany(q => q.Lines)
             .WithRequired(q => q.Version)
             .HasForeignKey((q => q.VersionId));

            builder.Entity<ProductVersion>()
               .HasRequired(c => c.Suite)
                .WithMany(t => t.Versions)
                .HasForeignKey((q => q.SuiteId));

            builder.Entity<ProductVersion>()
                .Property(p => p.SalesChannels)
                .IsOptional();
            builder.Entity<ProductVersion>()
        .Property(p => p.Scale)
        .IsOptional();
            builder.Entity<ProductVersion>()
        .Property(p => p.ScaleQuoteMap)
        .IsOptional();
            builder.Entity<ProductVersion>()
        .Property(p => p.StateCoverge)
        .IsOptional();
            builder.Entity<ProductVersion>()
   .Property(p => p.CoPayment)
   .IsOptional();
            builder.Entity<ProductVersion>()
  .Property(p => p.AccidentWaiver)
  .IsOptional();
            builder.Entity<ProductVersion>()
  .Property(p => p.DaySurgeryWaiver)
  .IsOptional();
            builder.Entity<ProductVersion>()
  .Property(p => p.ChildrenWaiver)
  .IsOptional();
            builder.Entity<ProductVersion>()
  .Property(p => p.StaffSubsidy)
  .IsOptional();

            builder.Entity<Feature>()
.Property(p => p.ClinicalCategoryId)
.IsOptional();



            builder.Entity<ProductLine>()
             .HasKey(q => q.Id)
             .HasMany(q => q.Excesses)
             .WithRequired(q => q.ProductLine)
             .HasForeignKey(q => q.ProductLineId);

            builder.Entity<ProductLine>()
         .HasKey(q => q.Id)
         .HasMany(q => q.RoomRates)
         .WithRequired(q => q.ProductLine)
         .HasForeignKey((q => q.ProductLineId));

            //builder.Entity<ProductLine>()
            // .HasKey(q => q.Id)
            // .HasMany(q => q.RoomRates);

            //builder.Entity<ProductLine>()
            //   .HasRequired(c => c.Code)
            //   .WithOptional(c => c.Code).
            //   WithRequiredDependent()
            //   .Map(m => m.MapKey("CodeId"));

            builder.Entity<ProductCode>()
    .HasKey(q => q.Id)
    .HasMany(q => q.ProductLines)
    .WithRequired(q => q.Code)
    .HasForeignKey((q => q.CodeId));



            //builder.Entity<ProductLine>()
            // .HasRequired(c => c.Version)
            // .WithRequiredDependent()
            // .Map(m => m.MapKey("VersionId"));

            builder.Entity<ProductExcess>()
             .HasKey(q => q.Id);

            //builder.Entity<ProductExcess>()
            //  .HasRequired(c => c.Group)
            //   .WithRequiredDependent()
            //   .Map(m => m.MapKey("GroupId"));


            builder.Entity<ExcessGroup>()
 .HasKey(q => q.Id)
 .HasMany(q => q.ProductExcesses)
 .WithRequired(q => q.Group)
 .HasForeignKey((q => q.GroupId));

            builder.Entity<ExcessType>()
.HasKey(q => q.Id)
.HasMany(q => q.ProductExcesses)
.WithRequired(q => q.Type)
.HasForeignKey((q => q.TypeId));

            //      // builder.Entity<ProductExcess>()
            //      //.HasRequired(c => c.ProductLine)
            //      // .WithRequiredDependent()
            //      // .Map(m => m.MapKey("ProductLineId"));

            //       builder.Entity<ProductExcess>()
            //.HasRequired(c => c.Type)
            // .WithRequiredDependent()
            // .Map(m => m.MapKey("TypeId"));

            builder.Entity<ExcessType>()
             .HasKey(q => q.Id);

            builder.Entity<ExcessGroup>()
            .HasKey(q => q.Id);

            builder.Entity<RoomRate>()
             .HasKey(q => q.Id);

            //       builder.Entity<RoomRate>()
            //         .HasRequired(c => c.AccessType)
            //       .WithRequiredDependent()
            //       .Map(m => m.MapKey("AccessTypeId"));

            //       builder.Entity<RoomRate>()
            //        .HasRequired(c => c.HospitalType)
            //      .WithRequiredDependent()
            //      .Map(m => m.MapKey("HospitalTypeId"));

            //       builder.Entity<RoomRate>()
            //       .HasRequired(c => c.Type)
            //       .WithRequiredDependent()
            //       .Map(m => m.MapKey("TypeId"));

            //       //builder.Entity<RoomRate>()
            //       //.HasRequired(c => c.ProductLine)
            //       //.WithRequiredDependent()
            //       //.Map(m => m.MapKey("ProductLineId"));

            builder.Entity<ProductLine>()
.HasKey(q => q.Id)
.HasMany(q => q.RoomRates)
.WithRequired(q => q.ProductLine)
.HasForeignKey((q => q.ProductLineId));

            builder.Entity<HospitalType>()
             .HasKey(q => q.Id);

            builder.Entity<AccessType>()
            .HasKey(q => q.Id);

            builder.Entity<RoomRateType>()
            .HasKey(q => q.Id);

            //       builder.Entity<ClinicalCategory>()
            //       .HasKey(q => q.Id)
            //    .HasMany(q => q.Features)
            //    .WithRequired(q => q.ClinicalCategory)
            //    .Map(m => m.MapKey("ClinicalCategoryId"));
            //       //.HasMany(q => q.Features);

            // builder.Entity<ClinicalCategory>()
            //   .HasKey(q => q.Id)
            //.HasMany(q => q.Features)
            //.WithOptional(q => q.ClinicalCategory)
            // .HasForeignKey((q => q.ClinicalCategoryId));

            //builder.Entity<Feature>()
            // .HasOptional(x => x.ClinicalCategory)
            //.WithMany()
            //.HasForeignKey(x => x.ClinicalCategoryId).WillCascadeOnDelete(false);

            //    builder.Entity<ClinicalCategory>()
            //.HasOptional(t => t.Features)
            //.(t => t.);

            //builder.Entity<ClinicalCategory>().HasMany(x => x.Features).WithOptional();

            builder.Entity<Feature>().HasOptional(s => s.ClinicalCategory)
    .WithMany(s => s.Features)
    .HasForeignKey(s => s.ClinicalCategoryId);

            // builder.Entity<Feature>()
            //.HasKey(q => q.Id)
            //.HasOptional(q => q.ClinicalCategory);                             


            //       builder.Entity<Feature>()
            //               .HasRequired(c => c.Group)
            //               .WithRequiredDependent()
            //           .Map(m => m.MapKey("GroupId"));

            builder.Entity<FeatureGroup>()
             .HasKey(q => q.Id)
          .HasMany(q => q.Features)
          .WithRequired(q => q.Group)
           .HasForeignKey((q => q.GroupId));

            //       builder.Entity<Feature>()
            //               .HasRequired(c => c.Type)
            //               .WithRequiredDependent()
            //           .Map(m => m.MapKey("TypeId"));


            builder.Entity<FeatureType>()
             .HasKey(q => q.Id)
          .HasMany(q => q.Features)
          .WithRequired(q => q.Type)
           .HasForeignKey((q => q.TypeId));

            //       builder.Entity<Feature>()
            //            .HasRequired(c => c.Item)
            //            .WithRequiredDependent()
            //        .Map(m => m.MapKey("ItemId"));

            builder.Entity<Feature>()
           .HasKey(q => q.Id)
        .HasMany(q => q.Items)
        .WithRequired(q => q.Feature)
         .HasForeignKey((q => q.FeatureId))
  .WillCascadeOnDelete(true);

            //     //  builder.Entity<Feature>()
            //     //.HasRequired(c => c.ClinicalCategory)
            //     //.WithRequiredDependent()
            //     //  .Map(m => m.MapKey("ClinicalCategoryId"));

            builder.Entity<Item>()
    .HasKey(q => q.Id)
 .HasMany(q => q.Features)
 .WithRequired(q => q.Item)
  .HasForeignKey((q => q.ItemId))
  .WillCascadeOnDelete(true);

            builder.Entity<FeatureType>()
           .HasKey(q => q.Id);

            builder.Entity<FeatureGroup>()
           .HasKey(q => q.Id);

            builder.Entity<Limit>()
           .HasKey(q => q.Id);

            builder.Entity<LimitType>()
           .HasKey(q => q.Id);

            builder.Entity<Item>()
           .HasKey(q => q.Id);

            //       builder.Entity<Item>()
            // .HasMany(q => q.Ancillaries)
            // .WithRequired(q => q.Item)
            // .Map(m => m.MapKey("ItemId"));

            builder.Entity<Item>()
    .HasKey(q => q.Id)
 .HasMany(q => q.Ancillaries)
 .WithRequired(q => q.Item)
  .HasForeignKey((q => q.ItemId));

            //       builder.Entity<Item>()
            //                       .HasRequired(c => c.FeatureItem)
            //            .WithRequiredDependent()
            //        .Map(m => m.MapKey("FeatureItemId"));

            //       //builder.Entity<Ancillary>()
            //       //               .HasRequired(c => c.Item)
            //       //    .WithRequiredDependent()
            //       //.Map(m => m.MapKey("ItemId"));

            //       builder.Entity<Ancillary>()
            //                     .HasRequired(c => c.ProdutCode)
            //          .WithRequiredDependent()
            //      .Map(m => m.MapKey("ProdutCodeId"));

            builder.Entity<ProductCode>()
.HasKey(q => q.Id)
.HasMany(q => q.Ancillaries)
.WithRequired(q => q.ProdutCode)
.HasForeignKey((q => q.ProdutCodeId));

            builder.Entity<FeatureItem>()
           .HasKey(q => q.Id);

           // builder.Entity<FeatureItem>()
           //  .HasRequired(c => c.Feature)
           //    .WithRequiredDependent().WillCascadeOnDelete(false);

           // builder.Entity<FeatureItem>()
           //.HasRequired(c => c.Item)
           //  .WithRequiredDependent()
           // .WillCascadeOnDelete(false);

        }
    }
}
