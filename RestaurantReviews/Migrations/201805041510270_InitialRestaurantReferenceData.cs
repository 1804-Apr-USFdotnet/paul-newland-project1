using Microsoft.Owin.BuilderProperties;
using RestaurantReviews.Core.Domain;

namespace RestaurantReviews.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRestaurantReferenceData : DbMigration
    {
        private readonly List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant() {Name = "'Taco Bell'", Street = "'12345 123rd ST SW'", City = "'Seattle'", Zip = "'98765'", State = "'WA'", Phone = "'1234565849'", },
            new Restaurant() {Name = "'McDonalds'", Street = "'12346 123rd ST SE'", City = "'Miami'", Zip = "'12351'", State = "'FL'", Phone = "'1237565849'" },
            new Restaurant() {Name = "'Chic-fil-a'", Street = "'12347 123rd ST NW'", City = "'New York City'", Zip = "'26649'", State = "'NY'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Chipotle'", Street = "'12348 123rd ST NE'", City = "'Los Angeles'", Zip = "'88573'", State = "'CA'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Subway'", Street = "'12349 123rd ST SW'", City = "'Houston'", Zip = "'66091'", State = "'TX'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Jimmy Johns'", Street = "'12340 123rd ST SE'", City = "'Chicago'", Zip = "'55534'", State = "'IL'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Starbucks'", Street = "'12341 123rd ST NW'", City = "'Portland'", Zip = "'83700'", State = "'OR'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Panda Express'", Street = "'12342 123rd ST NE'", City = "'Atlanta'", Zip = "'09812'", State = "'GA'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'In-and-Out'", Street = "'12343 123rd ST SE'", City = "'San Francisco'", Zip = "'33537'", State = "'CA'", Phone = "'1234565849'" },
            new Restaurant() {Name = "'Dunkin Donuts'", Street = "'12344 123rd ST NW'", City = "'Dallas'", Zip = "'65482'", State = "'TX'", Phone = "'1234565849'" },
        };
        public override void Up()
        {
            foreach (var r in _restaurants)
            {
                Sql($"INSERT INTO Restaurants" +
                    $"(Name, Street, City, Zip, State, Phone)" +
                    $"VALUES ({r.Name}, {r.Street}, {r.City}, {r.Zip}, {r.State}, {r.Phone})");
            }
        }
        
        public override void Down()
        {
            foreach (var r in _restaurants)
            {
                Sql($"DELETE FROM Restaurants WHERE Street = {r.Street} AND Name = {r.Name}");
            }
        }
    }
}
