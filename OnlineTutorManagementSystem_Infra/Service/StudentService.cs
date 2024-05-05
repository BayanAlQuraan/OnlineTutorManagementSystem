using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;

namespace OnlineTutorManagementSystem_Infra.Service
{
    public class StudentService : IStudentServiceInterface
    {
        private readonly OnlineTutorManagementSystemDbContext _context;

        public StudentService(OnlineTutorManagementSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Student> Login(LoginReqDTO dto)
        {
            try
            {
                Student tStudent = await _context.Students.Where(x => x.Email == dto.Email && x.Password == dto.Password).FirstAsync();
                if(tStudent != null)
                {
                    return tStudent;
                }
                return null;
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
                ResponseMessage responseMessage = new ResponseMessage();
                Student student = new Student();
                student.FirstName = dto.FirstName;
                student.LastName = dto.LastName;
                student.Email = dto.Email;
                student.PhoneNumber = dto.Phone;
                student.Age = dto.Age;
                student.Password = dto.Password;
                await _context.Students.AddAsync(student);
                if (await _context.SaveChangesAsync() >= 0)
                {
                    responseMessage.Result = eResult.Success;
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "Faild to create student account";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }

        public async Task<ResponseMessage> PayInvoices( int InvoiceId, double Amount , string PaymentMethod)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Payment payment = new Payment();
                payment.InvoiceId = InvoiceId;
                payment.Amount = Amount;
                payment.PaymentMethod = PaymentMethod;
                payment.PaymentDate = DateTime.Now;

                var tInvoice = await _context.Invoices.FindAsync(InvoiceId);
                if(tInvoice == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no invoice associated to this invoice id";
                }
                else if(tInvoice.Status == (int)InvoiceStatus.Paid)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "This invoice is already paid";
                }
                else
                {
                    if (tInvoice.Amount <= Amount)
                    {
                        await _context.Payments.AddAsync(payment);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            tInvoice.Status = (int)InvoiceStatus.Paid;
                            _context.Invoices.Update(tInvoice);
                            await _context.SaveChangesAsync();
                            responseMessage.Result = eResult.Success;
                        }
                        else
                        {
                            responseMessage.Result = eResult.Failed;
                            responseMessage.ErrorCode = ErrorCode.GeneralError;
                            responseMessage.ErrorMessage = "Faild to pay invoice";
                        }
                    }
                    else { 
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.InsufficientAmount;
                        responseMessage.ErrorMessage = "Insufficient Amount, Please Pay " + tInvoice.Amount;
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
        public async Task<ResponseMessage> ResetPassword(ResetPasswordDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                if (dto.NewPassword != dto.ConfirmNewPassword)
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode= ErrorCode.PasswordNotMatch;
                    responseMessage.ErrorMessage = "The new password does not match the confirm password";
                    return responseMessage;
                }
                Student student;
                if (dto.Email != null)
                {
                   student = await _context.Students.Where( x => x.Email == dto.Email).FirstAsync();
                }
                else if (dto.Phone != null)
                {
                    student = await _context.Students.Where(x => x.PhoneNumber == dto.Phone).FirstAsync();
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.EmailOrPhoneShouldBeFilled;
                    responseMessage.ErrorMessage = "The fill the email or mobile number";
                    return responseMessage;
                }
                
                student.Password = dto.NewPassword;
                _context.Students.Update(student);
                if(await _context.SaveChangesAsync() > 0)
                {
                    responseMessage.Result= eResult.Success;
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "Faild to reset the password";
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
