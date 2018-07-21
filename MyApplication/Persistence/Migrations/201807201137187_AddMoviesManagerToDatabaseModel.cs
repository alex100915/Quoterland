namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesManagerToDatabaseModel : DbMigration
    {
        public override void Up()
        {
            Sql(
                "INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'4b8cdc5e-f4f7-4a68-9b88-d093f33898cf', N'moviesmanager@site.com', 0, N'ADJVrfS2UMP+1LTD5gGXYZNX2N0e69EFCEaYV3OUm+LIIEK0WjILSS5/uPv0UgNLlQ==', N'6393f193-911b-42ae-bef0-6c1fdb67eb14', NULL, 0, 0, NULL, 1, 0, N'moviesmanager@site.com')");
            Sql(
                "INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'67eb022c-4586-44fa-8e38-2c992a26afd3', N'CanManageMovies')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4b8cdc5e-f4f7-4a68-9b88-d093f33898cf', N'67eb022c-4586-44fa-8e38-2c992a26afd3')");


        }

    public override void Down()
        {
            Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id=(N'4b8cdc5e-f4f7-4a68-9b88-d093f33898cf')");
            Sql("DELETE FROM [dbo].[AspNetRoles] WHERE Id=(N'67eb022c-4586-44fa-8e38-2c992a26afd3')");
            Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE Id=(N'4b8cdc5e-f4f7-4a68-9b88-d093f33898cf')");
        }
    }
}
