using System.Data.Entity.Migrations;
using System.Linq;
using MyApplication.Persistence;
using NUnit.Framework;
using Microsoft.AspNet.Identity;
using MyApplication.Core.Models;

namespace MyApplication.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        [SetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();

            Seed();
        }

        private static void MigrateDbToLatestVersion()
        {
            var configuration = new MyApplication.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (context.Users.Any())
                return;

            context.Users.Add(new ApplicationUser() {UserName = "user1", Email = "-", PasswordHash = "-"});
            context.Users.Add(new ApplicationUser() { UserName = "user2", Email = "-", PasswordHash = "-"});
            context.SaveChanges();
        }
    }
}
