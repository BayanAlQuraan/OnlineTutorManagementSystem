using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;
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
        Task<ResponseMessage> PayInvoices(int InvoiceId, double Amount , string PaymentMethod);



    }
}
