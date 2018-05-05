using System.Collections.Generic;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialReviewsReferenceData : DbMigration
    {
        private readonly List<Review> _reviews = new List<Review>()
        {
            new Review() {Description = "'It was interesting'"},
            new Review() {Description = "'Could be room for improvement'"},
            new Review() {Description = "'Convenient location'"}
        };

        public override void Up()
        {
            var rand = new Random();

            for (var rId = 1; rId <= 10; rId++)
            {
                foreach (var rev in _reviews)
                {
                    if (rId % 2 == 0)
                    {
                        Sql($"INSERT INTO Reviews" +
                            $"(Description, Rating, RestaurantId, UserId)" +
                            $"VALUES ({rev.Description}, {rand.Next(1, 10)}, {rId}, N'817deb78-45fc-4b63-8eb0-b7fde8d627f4')");
                    }
                    else
                    {
                        Sql($"INSERT INTO Reviews" +
                            $"(Description, Rating, RestaurantId, UserId)" +
                            $"VALUES ({rev.Description}, {rand.Next(1, 10)}, {rId}, N'ebf4ef97-e26b-48c2-9421-df4d1fa4ac68')");
                    }
                }
            }
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Reviews WHERE Id BETWEEN 1 AND 30");
        }
    }
}
