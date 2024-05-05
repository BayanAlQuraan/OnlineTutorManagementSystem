using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Payment;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;
namespace OnlineTutorManagmentSystem_Core.IService
{
    public interface ITeacherServiceInterface
    {
        Task<Teacher> Login(LoginReqDTO dto);
        //GenerateStudentInvoice
        Task<ResponseMessage> GenerateStudentInvoice(InvoiceInfoDTO dto);
        // Grant Student To Get Cert
        Task<ResponseMessage> GrantStudentToGetCetificate(int StudentId, int SubjectId);

    }
}
