namespace PDS.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.Migrations.Sql;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PDS.Data.PDSDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
            SetSqlGenerator("MySql.Data.MySqlClient", new SqlGenerator());
        }

        public class SqlGenerator : MySql.Data.Entity.MySqlMigrationSqlGenerator
        {
            public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
            {
                IEnumerable<MigrationStatement> res = base.Generate(migrationOperations, providerManifestToken);
                foreach (MigrationStatement ms in res)
                {
                    ms.Sql = ms.Sql.Replace("dbo.", "");
                }
                return res;
            }
        }

        protected override void Seed(PDS.Data.PDSDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
