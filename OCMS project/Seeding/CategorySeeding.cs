using OCMS_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Seeding
{
    public  static class CategorySeeding
    {

        public static List<Models.Category> SeedData()
        {
            List<Category> categories = new List<Category>();

            var obj1 = new Category
            {
                Cat_Id = Guid.Parse("7FBED69C-E942-456A-82BB-FDB9457DD30E"),
                Cat_Name = "Water Leakage"
            };

            categories.Add(obj1);

            var obj2 = new Category
            {
                Cat_Id = Guid.Parse("0E0625D6-D7F9-4C1B-B26C-E5DC239E5938"),
                Cat_Name = "Eelectricity"
            };

            categories.Add(obj2);


            var obj3 = new Category
            {
                Cat_Id = Guid.Parse("7A659B16-BCB1-4E9F-BC74-A7ED6E5C0CB7"),
                Cat_Name = "Air Conditioner"
            };

            categories.Add(obj3);

            var obj4 = new Category
            {
                Cat_Id = Guid.Parse("5D1EAD8F-BB23-489E-B09A-35380986B92B"),
                Cat_Name = "Office Kitchen"
            };

            categories.Add(obj4);


            return categories;
        }
    }
}