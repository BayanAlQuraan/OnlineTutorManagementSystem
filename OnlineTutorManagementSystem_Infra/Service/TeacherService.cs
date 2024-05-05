using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Payment;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;
namespace OnlineTutorManagementSystem_Infra.Service
{
    public class TeacherService : ITeacherServiceInterface
    {
        private readonly OnlineTutorManagementSystemDbContext _context;

        public TeacherService(OnlineTutorManagementSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseMessage> GenerateStudentInvoice(InvoiceInfoDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Invoice invoice = new Invoice();
                invoice.Amount = dto.Amount;
                invoice.Details = dto.Details;
                invoice.CreationDate = DateTime.Now;
                invoice.Status = (int)InvoiceStatus.UnPaid;
                invoice.Student = await _context.Students.FindAsync(dto.StudentId);
                if(invoice.Student != null)
                {
                    await _context.Invoices.AddAsync(invoice);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to generate student invoice";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student found associated to this student id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }

        public async Task<ResponseMessage> GrantStudentToGetCetificate(int StudentId, int SubjectId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Certificate certificate = new Certificate();
                certificate.Student = await _context.Students.FindAsync(StudentId);
                certificate.Subject = await _context.Subjects.FindAsync(SubjectId);
                if(certificate.Student != null)
                {
                    certificate.Name = certificate.Subject.Name + "-" + SubjectId;
                    certificate.Description = certificate.Subject.Description;
                    await _context.Certificates.AddAsync(certificate);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to grant student to get certificate";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student associated to this student id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }

        public async Task<Teacher> Login(LoginReqDTO dto)
        {
            try
            {
                var tTeacher = await _context.Teachers.Where(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password)).FirstAsync();
                if (tTeacher != null)
                {
                    return tTeacher;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
