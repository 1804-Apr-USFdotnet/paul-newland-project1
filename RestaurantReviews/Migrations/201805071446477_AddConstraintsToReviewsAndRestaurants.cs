namespace RestaurantReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintsToReviewsAndRestaurants : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Restaurants", "Street", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Restaurants", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Restaurants", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Restaurants", "Zip", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Restaurants", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Description", c => c.String());
            AlterColumn("dbo.Restaurants", "Phone", c => c.String());
            AlterColumn("dbo.Restaurants", "Zip", c => c.String());
            AlterColumn("dbo.Restaurants", "State", c => c.String());
            AlterColumn("dbo.Restaurants", "City", c => c.String());
            AlterColumn("dbo.Restaurants", "Street", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}
