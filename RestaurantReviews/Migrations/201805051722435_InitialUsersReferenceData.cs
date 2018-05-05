namespace RestaurantReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUsersReferenceData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'817deb78-45fc-4b63-8eb0-b7fde8d627f4', N'admin@test.com', 0, N'AIigTcA/TAw55fnA8WipQDPGVAen+cT5faxGJrFWmKEUZdJmY7ehePT7MjfvBpf5vQ==', N'aeb7ebe8-fb00-4fe6-a87e-fc52330b2ea5', NULL, 0, 0, NULL, 1, 0, N'admin@test.com');
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ebf4ef97-e26b-48c2-9421-df4d1fa4ac68', N'test@test.com', 0, N'ANO67Pc8QGAsJJKz5MdmlMC95fzziqxNiYCSO5qGgLiANfR0VlYI/md9qu3wcGbCpA==', N'7b0f26e6-baa8-4b05-b0ca-1a6e0a97577e', NULL, 0, 0, NULL, 1, 0, N'test@test.com');
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd1f7e09e-6560-4d64-a5de-5e78fde56406', N'CanManageRestaurants');
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'817deb78-45fc-4b63-8eb0-b7fde8d627f4', N'd1f7e09e-6560-4d64-a5de-5e78fde56406');
            ");
        }
        
        public override void Down()
        {
        }
    }
}
