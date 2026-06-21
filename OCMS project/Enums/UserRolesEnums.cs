using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Enums
{
    public enum UserRolesEnums
    {
        Admin,
        User 
    }


    public enum AccountStatusEnums
    {
       Active,
       Pending,
       Warning,
       Suspended
    }


    public enum ComplaintStatusEnums
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }
}