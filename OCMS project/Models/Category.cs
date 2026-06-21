using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS_project.Models
{
    public class Category
    {

        [Key]
        public Guid Cat_Id   { get; set; }

        public string Cat_Name { get; set; } 
    }
}