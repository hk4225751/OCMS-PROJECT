using OCMS_project.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.DTO_s
{
    public class UseraProfiledto 
    {
        public int TrackingId { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactNum { get; set; } 

        public string ImageUrl { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }  // for image upload

    }
}