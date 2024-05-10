using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Models.Entities;
namespace OnlineTutorManagmentSystem_Core.IService
{
    public interface IStudentServiceInterface
    {

        //Login
        Task<Student> Login(LoginReqDTO dto);
        //CreateAccount
        Task<ResponseMessage> CreateAccount(RegistrationDTO dto);
        //ResetPassword
        Task<ResponseMessage> ResetPassword(ResetPasswordDTO dto);

        //Pay Invoices -- Create Payment and Change the Invoice Status
        Task<ResponseMessage> PayInvoices(int InvoiceId, double Amount, string PaymentMethod);


        // Repos

        //DeleteAccount
        Task<ResponseMessage> DeleteAccount(int StudentId);
        //Get Certificate
        Task<ResponseMessage> GetAllCertificates(int StudentId);
        Task<ResponseMessage> GetCertificateById(int CertificateId);
        //GetStudentInvoices
        Task<ResponseMessage> GetStudentInvoices(int StudentId);
        //Leave class
        Task<ResponseMessage> LeaveClass(int StudentId, int ClassId);
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
