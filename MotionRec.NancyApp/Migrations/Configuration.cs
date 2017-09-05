namespace MotionRec.NancyApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MotionRec.NancyApp.DAL.NancyAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MotionRec.NancyApp.DAL.NancyAppContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.User.AddOrUpdate(
                           u => u.Id,
                           new Models.User { Email = "mbrady@bbunch.com", FirstName = "Mike", LastName = "Brady", Id = 1 },
                           new Models.User { Email = "cbrady@bbunch.com", FirstName = "Carol", LastName = "Brady", Id = 2 },
                           new Models.User { Email = "anelson@bbunch.com", FirstName = "Alice", LastName = "Nelson", Id = 3 },
                           new Models.User { Email = "gbrady@bbunch.com", FirstName = "Greg", LastName = "Brady", Id = 4 },
                           new Models.User { Email = "marcia.brady@bbunch.com", FirstName = "Marcia", LastName = "Brady", Id = 5 },
                           new Models.User { Email = "pbrady@bbunch.com", FirstName = "Peter", LastName = "Brady", Id = 6 },
                           new Models.User { Email = "jbrady@bbunch.com", FirstName = "Jan", LastName = "Brady", Id = 7 },
                           new Models.User { Email = "bbrady@bbunch.com", FirstName = "Bobby", LastName = "Brady", Id = 8 },
                           new Models.User { Email = "cindy.brady@bbunch.com", FirstName = "Cindy", LastName = "Brady", Id = 9 },
                           new Models.User { Email = "cousin.oliver@bbunch.com", FirstName = "Cousin", LastName = "Oliver", Id = 10 }
                           );
        }
    }
}
