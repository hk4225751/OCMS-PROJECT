using OCMS_project.Enums;
using OCMS_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OCMS_project.DTO_s
{
    public class UserComplaintsdto
    {

        public int TrackingId { get; set; }



        public string Complaint_Title { get; set; }

       

        public string Complaint_Description { get; set; }

        public string ComplaintImageURL { get; set; }

        public DateTime ComplaintDate { get; set; }


        [ForeignKey("Cat_Id")]
        public virtual Category Category { get; set; }

        public ComplaintStatusEnums status { get; set; }
    }
}