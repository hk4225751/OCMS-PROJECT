using OCMS_project.DTO_s;
using OCMS_project.DTO_s.Complaint;
using OCMS_project.Enums;
using OCMS_project.Models;
using OCMS_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace OCMS_project.Services
{
    public class ComplaintService
    {

        private readonly ComplaintRepo _complaintRepo = new ComplaintRepo();
        private readonly UserService _userService = new UserService();
        private readonly UserRepo _userrepo = new UserRepo();

        public int AddComplaint(ComplaintDto request)
        {
            var user = _userService.GetById(request.User_Id);
            if (user != null)
            {

                AccountStatusEnums useraccount = user.AccountStatus;
                if (AccountStatusEnums.Suspended == useraccount || AccountStatusEnums.Pending == useraccount)
                {
                    return 2;
                }


                var complaint = FromDTOToComplaint(request);
                _complaintRepo.AddComplaint(complaint);
                return 1;
            }

            return 3;
        }


        public Complaints FromDTOToComplaint(ComplaintDto request)
        {
            Random random = new Random();
            int trackingId = random.Next(0000, 9999);
            return new Complaints
            {
                Complaint_Id = Guid.NewGuid(),
                User_Id = request.User_Id,
                Complaint_Title = request.Complaint_Title,
                Cat_Id = request.Cat_Id,
                Complaint_Description = request.Complaint_Description,
                ComplaintImageURL = request.ImageURL,
                ComplaintDate = DateTime.Now,
                TrackingId = trackingId
            };
        }


        public Complaints GetComplaintByTrackingId(int trackingId)
        {
            return _complaintRepo.GetByTrackingId(trackingId);
        }


        public List<UserComplaintsdto> GetAllComplaintsDto(Guid userId)
        {
            var complaints = _complaintRepo.GetAllComplaints(userId);
            if (complaints == null || !complaints.Any())
                return new List<UserComplaintsdto>();

            return complaints.Select(c => new UserComplaintsdto
            {
               
                Complaint_Title = c.Complaint_Title,
                Complaint_Description = c.Complaint_Description,
                ComplaintImageURL = c.ComplaintImageURL,
                ComplaintDate = c.ComplaintDate,
                status = c.status,
                Category = c.Category,
                TrackingId = c.TrackingId   // add this if you have it
            }).ToList();
        }
    }
    
}