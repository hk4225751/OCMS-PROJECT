using Microsoft.EntityFrameworkCore;
using OCMS_project.Areas.Visitors.Data;
using OCMS_project.DTO_s.Complaint;
using OCMS_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS_project.Repositories
{
    public class ComplaintRepo
    {

        public void AddComplaint(Complaints complaint)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Complaints.Add(complaint);
                context.SaveChanges();
            }
        }

        public Complaints GetByTrackingId(int trackingId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Complaints.AsNoTracking().
                    Include(x => x.Category)
                    .FirstOrDefault(c => c.TrackingId == trackingId);

            }
        }


        public List<Complaints> GetAllComplaints(Guid UserId)
        {
            using (var context = new ApplicationDbContext())
            {

                var list = context.Complaints.AsNoTracking().Include(x => x.Category).Where(c => c.User_Id == UserId).ToList();

                return list;
            }
        }
    }

}