using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagmentSystem_Core.Enums;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;
using OnlineTutorManagementSystem_Core.Models.Shared;
namespace OnlineTutorManagementSystem_Infra.Repos
{
   public class StudentRepos : IStudentReposeInterface
    {
        private readonly OnlineTutorManagementSystemDbContext _context;
        public StudentRepos(OnlineTutorManagementSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseMessage> DeleteAccount(int StudentId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tStudent = await _context.Students.FindAsync(StudentId);
                if (tStudent != null) 
                {
                    if(await _context.Invoices.AnyAsync(x => x.Student.Id == StudentId && x.Status == (int)InvoiceStatus.UnPaid))
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.UnpaidInvoices;
                        responseMessage.ErrorMessage = "Can't Delete Account While there is unpaid invoices";
                        return responseMessage;
                    }
                    else
                    {
                        _context.Students.Remove(tStudent);
                        if(await _context.SaveChangesAsync() > 0)
                        {
                            responseMessage.Result = eResult.Success;
                        }
                        else
                        {
                            responseMessage.Result= eResult.Failed;
                            responseMessage.ErrorCode = ErrorCode.GeneralError;
                            responseMessage.ErrorMessage = "Faild to delete account";
                        }
                    }
                    return responseMessage;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student account associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetAllCertificates(int StudentId)
        {
            
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tCertificates = await _context.Certificates.Where(x => x.Student.Id == StudentId).ToListAsync();
                if(tCertificates.Any())
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tCertificates;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no certificate found";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetCertificateById(int CertificateId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tCertificate = await _context.Certificates.FindAsync(CertificateId);
                if(tCertificate == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no certificate found associated to this id";
                }
                else
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload= tCertificate;
                }
                return responseMessage;
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
                return new ResponseMessage(ex);

            }
        }
        public async Task<ResponseMessage> GetStudentInvoices(int StudentId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tInvoices = await _context.Invoices.Where(x => x.Student.Id == StudentId).ToListAsync();
                if (tInvoices.Any())
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tInvoices;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no invoice found";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> LeaveClass(int StudentId, int ClassId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tStudentClass = await _context.StudentClasses.Where(x => x.Student.Id == StudentId && x.Class.Id == ClassId).FirstOrDefaultAsync();
                if (tStudentClass != null)
                {
                    if (await _context.Invoices.AnyAsync(x => x.Student.Id == StudentId && x.Status == (int)InvoiceStatus.UnPaid))
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.UnpaidInvoices;
                        responseMessage.ErrorMessage = "Can't Leave this class While there is unpaid invoices";
                    }
                    else
                    {
                        _context.StudentClasses.Remove(tStudentClass);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            responseMessage.Result = eResult.Success;
                        }
                        else
                        {
                            responseMessage.Result = eResult.Failed;
                            responseMessage.ErrorCode = ErrorCode.GeneralError;
                            responseMessage.ErrorMessage = "Faild to leave from this class";
                        }
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "The student is not registered to this class";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> RegisterToClass(int ClassId, int StudentId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                StudentClass studentClass = new StudentClass();
                var tClass = await _context.Classes.FindAsync(ClassId);
                studentClass.Student = await _context.Students.FindAsync(StudentId);
                studentClass.Class = tClass;
                if (tClass == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no class associated to this class id";
                }
                else
                {
                    var tStudentClass = await _context.StudentClasses.Where(x => x.Student.Id == StudentId && x.Class.Id == ClassId).FirstOrDefaultAsync();
                    if(tStudentClass == null)
                    {
                        await _context.StudentClasses.AddAsync(studentClass);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            tClass.NumberOfStudents++;
                            _context.Classes.Update(tClass);
                            await _context.SaveChangesAsync();
                            responseMessage.Result = eResult.Success;
                        }
                        else
                        {
                            responseMessage.Result = eResult.Failed;
                            responseMessage.ErrorCode = ErrorCode.GeneralError;
                            responseMessage.ErrorMessage = "Faild to register student to this class";
                        }
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "The student already registered to this class";
                    }
                }

                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> UpdateProfile(UpdateProfileDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var student = await _context.Students.FindAsync(dto.Id);
                if (student != null) 
                {
                    student.FirstName = dto.FirstName == null ? student.FirstName : dto.FirstName;
                    student.LastName = dto.LastName == null ? student.LastName : dto.LastName;
                    student.Email = dto.Email == null ? student.Email : dto.Email;
                    student.Password = dto.Password == null ? student.Password : dto.Password;
                    student.PhoneNumber = dto.Phone == null ? student.PhoneNumber : dto.Phone;
                    _context.Students.Update(student);
                    if(await _context.SaveChangesAsync() >= 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to update student info";
                    }
                    return responseMessage;
                }
                else
                {
                    responseMessage.Result= eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> ViewEvaluation(int EvaluationId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var eval = await _context.Evaluations.FindAsync(EvaluationId);
                if (eval != null)
                {
                    ViewEvaluationDTO tEvaluation = new ViewEvaluationDTO(eval);
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tEvaluation;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no vvaluation associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> ViewSchedule(int StudnetId)
        {

            try
            {
                ResponseMessage responseMessage= new ResponseMessage();
                List<ViewScheduleDTO> tScheduleDTO = new List<ViewScheduleDTO>();
                var studentClasses = await _context.StudentClasses.Where(x => x.Student.Id == StudnetId).ToListAsync();
                if (studentClasses.Any())
                {
                    studentClasses.ForEach(studentClass =>
                    {
                        ViewScheduleDTO viewScheduleDTO = new ViewScheduleDTO(studentClass);
                        tScheduleDTO.Add(viewScheduleDTO);
                    });
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tScheduleDTO;
                }
                else
                {
                    responseMessage.Result= eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no registered classed for this student";
                }

                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> ViewInvoiceById(int InvoiceId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var invoice = await _context.Invoices.FindAsync(InvoiceId);
                if(invoice != null)
                {
                    InvoiceInfoDTO tInvoice = new InvoiceInfoDTO();
                    tInvoice.Amount = invoice.Amount;
                    tInvoice.Details = invoice.Details;
                    tInvoice.StudentId = invoice.Student.Id;
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tInvoice;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no invoice associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
    }
}
