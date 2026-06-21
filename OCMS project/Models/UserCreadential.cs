using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS_project.Models
{
    public class UserCreadential
    {

        [Key]
        public Guid CreadId { get; set; }

        public Guid UserId { get; set; }

        public string Password { get; set; } = string.Empty;

    }
}