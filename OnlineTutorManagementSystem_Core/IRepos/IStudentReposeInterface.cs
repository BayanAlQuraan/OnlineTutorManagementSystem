using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;

namespace OnlineTutorManagmentSystem_Core.IRepos
{
    public interface IStudentReposeInterface
    {

            //DeleteAccount
            Task<ResponseMessage> DeleteAccount(int StudentId);
            //Get Certificate
            Task<ResponseMessage> GetAllCertificates(int StudentId);
            Task<ResponseMessage> GetCertificateById(int CertificateId);
            //GetStudentInvoices
            Task<ResponseMessage> GetStudentInvoices(int StudentId);
            //Leave class
            Task<ResponseMessage>LeaveClass(int StudentId, int ClassId);
            //Register to class
            Task<ResponseMessage> RegisterToClass(int ClassId, int StudentId);
            //UpdateProfile
            Task<ResponseMessage> UpdateProfile(UpdateProfileDTO dto);
            // View Evaluation
            Task<ResponseMessage> ViewEvaluation(int EvaluationId);
            // View Schedule
            Task<ResponseMessage> ViewSchedule(int StudnetId);
            //view invoices
            Task<ResponseMessage> ViewInvoiceById(int StudnetId);
    }

}

