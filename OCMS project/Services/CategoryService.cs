using OCMS_project.Areas.Visitors.Data;
using OCMS_project.Models;
using OCMS_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Services
{
    public class CategoryService
    {
        public static List<Category> GetAllCategories()
        {
           
                return CategoryRepo.GetAllCategories();
               
          
        }
    }
}