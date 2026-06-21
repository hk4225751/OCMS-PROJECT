using OCMS_project.Areas.Visitors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Repositories
{
    public class CategoryRepo
    {
        public static List<Models.Category> GetAllCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                var categories = context.Categories.ToList();
                return categories;
            }
        }
    }
}