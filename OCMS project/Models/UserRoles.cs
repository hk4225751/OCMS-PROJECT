using OCMS_project.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS_project.Models
{
    public class UserRoles
    {
        [Key]
        public Guid UserRoleId { get; set; }

        public Guid UserId    { get; set; }

       public UserRolesEnums UserRole { get; set; } = UserRolesEnums.User;
    }
}