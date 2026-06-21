using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS_project.DTO_s.Complaint
{
    public class ComplaintDto
    {
      

        public Guid Complaint_Id { get; set; }

        public Guid User_Id { get; set; }

        public string Complaint_Title { get; set; }

        public Guid Cat_Id { get; set; }

        public string Complaint_Description { get; set; }

        public string ImageURL { get; set; }

        public HttpPostedFileBase File { get; set; }

        public DateTime ComplaintDate { get; set; }

       



    }
}