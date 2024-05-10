using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.Dtos.Certificate;
using OnlineTutorManagmentSystem_Core.Dtos.Class;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Student;
using OnlineTutorManagmentSystem_Core.Dtos.Subject;
using OnlineTutorManagmentSystem_Core.IRepos;
using OnlineTutorManagmentSystem_Core.Models.Entities;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;

namespace OnlineTutorManagementSystem_Infra.Repos
{
    public class TeacherRepos : ITeacherReposeInterface
    {
        private readonly OnlineTutorManagementSystemDbContext _context;
        public TeacherRepos(OnlineTutorManagementSystemDbContext context)
        {
            _context = context;
        }
        //Class Management
        public async Task<ResponseMessage> GetAllClasses()
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tClasses = await _context.Classes.ToListAsync();
                if (tClasses.Any())
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tClasses;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no classes found";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetClassById(int ClassId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tClass = await _context.Classes.FindAsync(ClassId);
                if (tClass == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no class associated to this id";
                }
                else
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tClass;
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> CreateClass(CreateClassDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Class tClass = new Class();
                tClass.Name = dto.Name;
                tClass.StartTime = dto.StartTime;
                tClass.EndTime = dto.EndTime;
                tClass.Address = dto.Address;
                tClass.Capacity = dto.Capacity;
                tClass.Subject = await _context.Subjects.FindAsync(dto.SubjectId);
                if (tClass.Subject == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no subject associated to this id";

                }
                tClass.NumberOfStudents = dto.NumberOfStudents;
                await _context.AddAsync(tClass);
                if (await _context.SaveChangesAsync() > 0)
                {
                    responseMessage.Result = eResult.Success;
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "Faild to create class";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> UpdateClass(UpdateClassDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tClass = await _context.Classes.FindAsync(dto.Id);
                if (tClass != null)
                {
                    tClass.Name = dto.Name == null ? tClass.Name: dto.Name;
                    tClass.StartTime = (TimeOnly)(dto.StartTime == null ? tClass.StartTime : dto.StartTime);
                    tClass.EndTime = (TimeOnly)(dto.EndTime == null ? tClass.EndTime : dto.EndTime);
                    tClass.Address = dto.Address == null ? tClass.Address : dto.Address;
                    tClass.Capacity = (int)(dto.Capacity == null ? tClass.Capacity : dto.Capacity);
                    tClass.NumberOfStudents = (int)(dto.NumberOfStudents == null ? tClass.NumberOfStudents : dto.NumberOfStudents);
                    _context.Update(tClass);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;

                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to update class info";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "There is no class found associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> DeleteClass(int ClassId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tClass = await _context.Classes.FindAsync(ClassId);
                if (tClass != null)
                {
                    _context.Classes.Remove(tClass);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to delete this class";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no class found associated to this id";
                }
                return responseMessage;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        //Student Management
        public async Task<ResponseMessage> GetAllStudents()
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tStudents = await _context.Students.ToListAsync();
                if (tStudents.Any())
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tStudents;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no students found";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetStudentById(int StudentId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tStudent = await _context.Students.FindAsync(StudentId);
                if (tStudent == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student found associated to this id";
                }
                else
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tStudent;
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> UpdateStudent(UpdateStudentDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var student = await _context.Students.FindAsync(dto.Id);
                if (student == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student associated to this id";
                }
                else
                {
                    student.FirstName = dto.FirstName == null ? student.FirstName:dto.FirstName;
                    student.LastName = dto.LastName == null ? student.LastName : dto.LastName;
                    student.Email = dto.Email == null ? student.Email : dto.Email;
                    student.PhoneNumber = dto.PhoneNumber == null ? student.PhoneNumber : dto.PhoneNumber;
                    student.Age = (int)(dto.Age == null ? student.Age : dto.Age);
                    student.Password = dto.Password == null ? student.Password : dto.Password;
                    _context.Update(student);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to update this student info";
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
        public async Task<ResponseMessage> DeleteStudent(int StudentId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var student = await _context.Students.FindAsync(StudentId);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to delete student";
                    }
                    return responseMessage;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no student id associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        //Subject Management
        public async Task<ResponseMessage> GetAllSubjects()
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tSubjects = await _context.Subjects.ToListAsync();
                if (tSubjects != null)
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tSubjects;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetSubjectById(int SubjectId)
        {
            try
            {

                ResponseMessage responseMessage = new ResponseMessage();
                var tStudnet = await _context.Subjects.FindAsync(SubjectId);
                if (tStudnet != null)
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tStudnet;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no subject associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> CreateSubject(CreateSubjectDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Subject subject = new Subject();
                subject.Name = dto.Name;
                subject.Number = dto.Number;
                subject.Description = dto.Description;
                _context.Subjects.Add(subject);
                if (await _context.SaveChangesAsync() > 0)
                {
                    responseMessage.Result = eResult.Success;
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "Faild to create subject";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> UpdateSubject(UpdateSubjectDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var subject = await _context.Subjects.FindAsync(dto.Id);
                if (subject == null)
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no subject associated to this id";
                }
                else
                {
                    subject.Name = dto.Name == null ? subject.Name:dto.Name;
                    subject.Number = dto.Number == null ? subject.Number : dto.Number;
                    subject.Description = dto.Description == null ? subject.Description : dto.Description;
                    _context.Update(subject);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to update this subject info";
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
        public async Task<ResponseMessage> DeleteSubject(int SubjectId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var subject = await _context.Subjects.FindAsync(SubjectId);
                if (subject != null)
                {
                    _context.Subjects.Remove(subject);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to delete this subject";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no subject found associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        //Evaluation Management
        public async Task<ResponseMessage> GetAllEvaluations()
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tEvaluations = await _context.Evaluations.ToListAsync();
                if (tEvaluations != null)
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tEvaluations;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no evaluation found";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> GetEvaluationById(int EvaluationId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var tEvaluation = await _context.Evaluations.FindAsync(EvaluationId);
                if (tEvaluation != null)
                {
                    responseMessage.Result = eResult.Success;
                    responseMessage.Payload = tEvaluation;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no evaluation found associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> CreateEvaluation(CreateEvaluationDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Evaluation evaluation = new Evaluation();
                evaluation.EvaluationDate = dto.EvaluationDate;
                evaluation.Feedback = dto.Feedback;
                evaluation.QuzziesMark = dto.QuzziesMark;
                evaluation.AttendanceMark = dto.AttendanceMark;
                evaluation.ParticipantsMark = dto.ParticipantsMark;
                evaluation.AssignmentsMark = dto.AssignmentsMark;
                evaluation.Score = dto.QuzziesMark + dto.AttendanceMark + dto.ParticipantsMark + dto.AssignmentsMark;
                var tStudent = await _context.Students.FindAsync(dto.StudentId);

                if(tStudent == null)
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode= ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "There is no student associated to this student id";
                    return responseMessage;
                }
                evaluation.Student = tStudent;
                _context.Evaluations.Add(evaluation);
                if (await _context.SaveChangesAsync() > 0)
                {
                    responseMessage.Result = eResult.Success;
                }
                else
                {
                    responseMessage.Result = eResult.Failed;
                    responseMessage.ErrorCode = ErrorCode.GeneralError;
                    responseMessage.ErrorMessage = "Faild to create evaluation";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> UpdateEvaluation(UpdateEvaluationDTO dto)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var evaluation = await _context.Evaluations.FindAsync(dto.Id);
                if (evaluation != null)
                {
                    evaluation.EvaluationDate = (DateTime)(dto.EvaluationDate == null ? evaluation.EvaluationDate : dto.EvaluationDate);
                    evaluation.Feedback = dto.Feedback == null ? evaluation.Feedback:evaluation.Feedback;
                    evaluation.QuzziesMark = (double)(dto.QuzziesMark == null ? evaluation.QuzziesMark: dto.QuzziesMark);
                    evaluation.AttendanceMark = (double)(dto.AttendanceMark == null ? evaluation.AttendanceMark:dto.AttendanceMark);
                    evaluation.ParticipantsMark = (double)(dto.ParticipantsMark == null ? evaluation.ParticipantsMark : dto.ParticipantsMark);
                    evaluation.AssignmentsMark = (double)(dto.AssignmentsMark == null ? evaluation.AssignmentsMark : dto.AssignmentsMark);
                    evaluation.Score = evaluation.QuzziesMark + evaluation.AttendanceMark + evaluation.ParticipantsMark + evaluation.AssignmentsMark;
                    _context.Update(evaluation);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to update this evaluation info";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no evaluation found associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> DeleteEvaluation(int EvaluationId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var evaluation = await _context.Evaluations.FindAsync(EvaluationId);
                if (evaluation != null)
                {
                    _context.Evaluations.Remove(evaluation);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        responseMessage.Result = eResult.Success;
                    }
                    else
                    {
                        responseMessage.Result = eResult.Failed;
                        responseMessage.ErrorCode = ErrorCode.GeneralError;
                        responseMessage.ErrorMessage = "Faild to delete this evaluation info";
                    }
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no evaluation found associated to this id";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }
        public async Task<ResponseMessage> ViewStudnetCertificate(int StudentId, int SubjectId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                var certificate = await _context.Certificates.Where(x => x.Student.Id == StudentId && x.Subject.Id == SubjectId).FirstOrDefaultAsync();
                if (certificate != null)
                {
                    responseMessage.Result = eResult.Success;
                    CertificateDetailsDTO certificateDto = new CertificateDetailsDTO();
                    certificateDto.Name = certificate.Name;
                    certificateDto.Description = certificate.Description;
                    responseMessage.Payload = certificateDto;
                }
                else
                {
                    responseMessage.Result = eResult.NotFound;
                    responseMessage.ErrorCode = ErrorCode.NotFound;
                    responseMessage.ErrorMessage = "There is no certificate associated to this student with this class";
                }
                return responseMessage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return new ResponseMessage(ex);
            }
        }

        // Other Services ( need to rename )
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
                if (invoice.Student != null)
                {
                    await _context.Invoices.AddAsync(invoice);
                    if (await _context.SaveChangesAsync() > 0)
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
                if (certificate.Student != null)
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
        public async Task<AdminUser> Login(LoginReqDTO dto)
        {
            try
            {
                // TODO::
                if(dto.Email.ToLowerInvariant().Equals("admin") && dto.Password.Equals("123"))
                {
                    AdminUser adminUser = new AdminUser();
                    adminUser.Id = 1;
                    adminUser.Email = dto.Email;
                    adminUser.Password = dto.Password;
                    return adminUser;
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