using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.Data.Repository;
using PDS.Domain;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PDS.Data.Tests.Int
{
    [TestClass]
    public class UnitTestFeatureRepo
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var repo = new FeatureRepo();
                var uow = new PDSDBUnitOfWork();
                var feature = new Feature
                {
                    Id = 0,
                    //ClinicalCategoryId = 0,
                    GroupId = 1,
                    TypeId = 1,
                    Name = "feature 3",
                    Description = "F 3",
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    Items = new List<FeatureItem>
                         {
                             //new FeatureItem { ItemId = 2,
                             //                    UpdatedOn = DateTime.Now,
                             //                    CreatedOn = DateTime.Now
                             //}
                         }

                };
                repo.Add(feature);
                uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                var context = new PDSDBContext();

                var c = context.ClinicalCategories.Include(x => x.Features).Where(y => y.Id == 1).ToList();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                var repo = new ClinicalCategoryRepo();
                var uow = new PDSDBUnitOfWork();
                //var cc = new ClinicalCategory
                //{
                //    Id = 1,
                //    //ClinicalCategoryId = 0,
                //   // GroupId = 1,
                //   // TypeId = 1,
                //    Name = "feature 3",
                //   // Description = "F 3",
                //    UpdatedOn = DateTime.Now,
                //    CreatedOn = DateTime.Now,
                //    Features = new List<Feature>
                //    {
                //        new Feature { Id
                //        = 2,
                //        //                    UpdatedOn = DateTime.Now,
                //        //                    CreatedOn = DateTime.Now
                //        //}
                //    }

                //};
                //repo.Add(cc);
                uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}



