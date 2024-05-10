using Microsoft.EntityFrameworkCore;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.Dtos.Class;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Payment;
using OnlineTutorManagmentSystem_Core.Dtos.Student;
using OnlineTutorManagmentSystem_Core.Dtos.Subject;
using OnlineTutorManagmentSystem_Core.IRepos;
using OnlineTutorManagmentSystem_Core.IService;
using static OnlineTutorManagmentSystem_Core.Enums.OnlineTutorManagmentSystemLookups;
namespace OnlineTutorManagementSystem_Infra.Service
{
    public class TeacherService : ITeacherServiceInterface
    {
        private readonly ITeacherReposeInterface _repose;

        public TeacherService(ITeacherReposeInterface repose)
        {
            _repose = repose;
        }

        // Manage Class
        public Task<ResponseMessage> GetAllClasses()
        {
            return _repose.GetAllClasses();
        }
        public Task<ResponseMessage> GetClassById(int ClassId)
        {
            return _repose.GetClassById(ClassId);
        }
        public Task<ResponseMessage> CreateClass(CreateClassDTO dto)
        {
            return _repose.CreateClass(dto);
        }
        public Task<ResponseMessage> DeleteClass(int ClassId)
        {
            return _repose.DeleteClass(ClassId);
        }
        public Task<ResponseMessage> UpdateClass(UpdateClassDTO dto)
        {
            return _repose.UpdateClass(dto);
        }

        // Manage Evaluation
        public Task<ResponseMessage> GetAllEvaluations()
        {
            return _repose.GetAllEvaluations();
        }
        public Task<ResponseMessage> GetEvaluationById(int EvaluationId)
        {
            return _repose.GetEvaluationById(EvaluationId);
        }
        public Task<ResponseMessage> CreateEvaluation(CreateEvaluationDTO dto)
        {
            return _repose.CreateEvaluation(dto);
        }
        public Task<ResponseMessage> DeleteEvaluation(int EvaluationId)
        {
            return _repose.DeleteEvaluation(EvaluationId);
        }
        public Task<ResponseMessage> UpdateEvaluation(UpdateEvaluationDTO dto)
        {
            return _repose.UpdateEvaluation(dto);
        }

        // Manage Subject
        public Task<ResponseMessage> GetAllSubjects()
        {
            return _repose.GetAllSubjects();
        }
        public Task<ResponseMessage> GetSubjectById(int SubjectId)
        {
            return _repose.GetSubjectById(SubjectId);
        }
        public Task<ResponseMessage> CreateSubject(CreateSubjectDTO dto)
        {
            return _repose.CreateSubject(dto);
        }
        public Task<ResponseMessage> DeleteSubject(int SubjectId)
        {
            return _repose.DeleteSubject(SubjectId);
        }
        public Task<ResponseMessage> UpdateSubject(UpdateSubjectDTO dto)
        {
            return _repose.UpdateSubject(dto);
        }

        // Manage Student
        public Task<ResponseMessage> GetAllStudents()
        {
            return _repose.GetAllStudents();
        }
        public Task<ResponseMessage> GetStudentById(int StudentId)
        {
            return _repose.GetStudentById(StudentId);
        }
        public Task<ResponseMessage> DeleteStudent(int StudentId)
        {
            return _repose.DeleteStudent(StudentId);
        }
        public Task<ResponseMessage> UpdateStudent(UpdateStudentDTO dto)
        {
            return _repose.UpdateStudent(dto);
        }

        // View Studnet Cert
        public Task<ResponseMessage> ViewStudnetCertificate(int StudentId, int SubjectId)
        {
            return _repose.ViewStudnetCertificate(StudentId, SubjectId);
        }


        // Other Services ( need to rename )
        public async Task<ResponseMessage> GenerateStudentInvoice(InvoiceInfoDTO dto)
        {
            try
            {
                return await _repose.GenerateStudentInvoice(dto);
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
                return await _repose.GrantStudentToGetCetificate(StudentId, SubjectId);
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
                return await _repose.Login(dto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
    }
}
