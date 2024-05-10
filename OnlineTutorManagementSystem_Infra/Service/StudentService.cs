using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.IRepos;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;

namespace OnlineTutorManagementSystem_Infra.Service
{
    public class StudentService : IStudentServiceInterface
    {
        private readonly IStudentReposeInterface _repos;

        public StudentService(IStudentReposeInterface repos)
        {
            _repos = repos;
        }
        public Task<ResponseMessage> DeleteAccount(int StudentId)
        {
            return _repos.DeleteAccount(StudentId);
        }

        public Task<ResponseMessage> GetAllCertificates(int StudentId)
        {
            return _repos.GetAllCertificates(StudentId);
        }

        public Task<ResponseMessage> GetCertificateById(int CertificateId)
        {
            return _repos.GetCertificateById(CertificateId);
        }

        public Task<ResponseMessage> GetStudentInvoices(int StudentId)
        {
            return _repos.GetStudentInvoices(StudentId);
        }

        public Task<ResponseMessage> LeaveClass(int StudentId, int ClassId)
        {
            return _repos.LeaveClass(StudentId, ClassId);
        }

        public Task<ResponseMessage> RegisterToClass(int ClassId, int StudentId)
        {
            return _repos.RegisterToClass(ClassId, StudentId);
        }

        public Task<ResponseMessage> UpdateProfile(UpdateProfileDTO dto)
        {
            return _repos.UpdateProfile(dto);
        }

        public Task<ResponseMessage> ViewEvaluation(int EvaluationId)
        {
            return _repos.ViewEvaluation(EvaluationId);
        }

        public Task<ResponseMessage> ViewSchedule(int StudnetId)
        {
            return _repos.ViewSchedule(StudnetId);
        }

        public Task<ResponseMessage> ViewInvoiceById(int StudnetId)
        {
            return _repos.ViewInvoiceById(StudnetId);
        }

        // Other Servies
        public async Task<Student> Login(LoginReqDTO dto)
        {
            try
            {
                return await _repos.Login(dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
        public async Task<ResponseMessage> CreateAccount(RegistrationDTO dto)
        {
            try
            {
                return await _repos.CreateAccount(dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> PayInvoices(int InvoiceId, double Amount, string PaymentMethod)
        {
            try
            {
                return await _repos.PayInvoices(InvoiceId, Amount, PaymentMethod);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> ResetPassword(ResetPasswordDTO dto)
        {
            try
            {
                return await _repos.ResetPassword(dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
    }
}
