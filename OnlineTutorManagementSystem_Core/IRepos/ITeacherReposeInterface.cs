using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagmentSystem_Core.Dtos.Class;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Student;
using OnlineTutorManagmentSystem_Core.Dtos.Subject;

namespace OnlineTutorManagmentSystem_Core.IRepos
{
    public interface ITeacherReposeInterface
    {
        //Class Management
        Task<ResponseMessage> GetAllClasses();
        Task<ResponseMessage> GetClassById(int ClassId);
        Task<ResponseMessage> CreateClass(CreateClassDTO dto);
        Task<ResponseMessage> UpdateClass(UpdateClassDTO dto);
        Task<ResponseMessage> DeleteClass(int ClassId);

        //Student Management
        Task<ResponseMessage> GetAllStudents();
        Task<ResponseMessage> GetStudentById(int StudentId);
        Task<ResponseMessage> UpdateStudent(UpdateStudentDTO dto);
        Task<ResponseMessage> DeleteStudent(int StudentId);

        //Subject Management
        Task<ResponseMessage> GetAllSubjects();
        Task<ResponseMessage> GetSubjectById(int SubjectId);
        Task<ResponseMessage> CreateSubject(CreateSubjectDTO dto);
        Task<ResponseMessage> UpdateSubject(UpdateSubjectDTO dto);
        Task<ResponseMessage> DeleteSubject(int SubjectId);

        //Evaluation Management
        Task<ResponseMessage> GetAllEvaluations();
        Task<ResponseMessage> GetEvaluationById(int EvaluationId);
        Task<ResponseMessage> CreateEvaluation(CreateEvaluationDTO dto);
        Task<ResponseMessage> UpdateEvaluation(UpdateEvaluationDTO dto);
        Task<ResponseMessage> DeleteEvaluation(int EvaluationId);

        // View Studnet Cert
        Task<ResponseMessage> ViewStudnetCertificate(int StudentId, int SubjectId);

        // Other Services
        Task<AdminUser> Login(LoginReqDTO dto);
        //GenerateStudentInvoice
        Task<ResponseMessage> GenerateStudentInvoice(InvoiceInfoDTO dto);
        // Grant Student To Get Cert
        Task<ResponseMessage> GrantStudentToGetCetificate(int StudentId, int SubjectId);

    }

}
