namespace ApiRegistry.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiRegistry.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApiRegistry.Data.DataContext context)
        {
            UserConfiguration.Seed(context);
            RoleConfiguration.Seed(context);
            ApiInfoConfiguration.Seed(context);

        }
    }
}
