using OCMS_project.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OCMS_project.Models
{
    public class Complaints  
    {

       
        [Key]
        public Guid Complaint_Id { get; set; }

        public Guid User_Id { get; set; }

        public string Complaint_Title { get; set; }

        public Guid Cat_Id { get; set; }
        
      public string Complaint_Description { get; set; }

        public string ComplaintImageURL { get; set; }

        public int TrackingId { get; set; }

        [ForeignKey("Cat_Id")]
        public virtual Category Category { get; set; }   // ✅ navigation property

        public DateTime ComplaintDate { get; set; }

        public ComplaintStatusEnums status { get; set; }



    }
}


