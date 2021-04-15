using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecipesApi.Models
{
    public class Recipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Name")]
        public string _titel { get; set; }
        public string _ingredients { get; set; }
        public string _category { get; set; }
        public string _instructions { get; set; }
        public string _amount { get; set; }
        



        public override string ToString()
        {
            return "Titel: " + _titel + " Ingredients: " + _ingredients + " Category: " + _category + " Instructions: " + _instructions + " ";
        }




    }
}
