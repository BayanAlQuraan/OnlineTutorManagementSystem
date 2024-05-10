using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Core.Models.Shared;
using OnlineTutorManagementSystem_Infra.Repos;
using OnlineTutorManagmentSystem_Core.Dtos.Class;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.Dtos.Student;
using OnlineTutorManagmentSystem_Core.Dtos.Subject;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;

namespace OnlineTutorManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherServiceController : ControllerBase
    {
        private readonly ITeacherServiceInterface _teacherService;
        public TeacherServiceController(ITeacherServiceInterface teacherservice)
        {
            _teacherService = teacherservice;
        }
        /// <summary>
        /// To login into the system by passing the teacher email and password.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginReqDTO dto)
        {
            try
            {
                //If login usrename and password are correct then proceed to generate token
                AdminUser tUser = await _teacherService.Login(dto);
                if (tUser != null)
                {
                    //Generate Token
                    string token = AuthenticationService.GenerateJWTToken(tUser.Id.ToString(),"Teacher");
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Invalid Username Or Password");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To create new invoice for specific students.
        /// </summary>
        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GenerateStudentInvoice(InvoiceInfoDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.GenerateStudentInvoice(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To allow a specific student to get a subject certificate.
        /// </summary>
        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GrantStudentToGetCetificate(int StudentId, int SubjectId)
        {
            try
            {
                var tResponse = await _teacherService.GrantStudentToGetCetificate(StudentId, SubjectId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// To get all classes.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                var tResponse = await _teacherService.GetAllClasses();
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// To get a specific class by passing class id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetClassById(int ClassId)
        {
            try
            {
                var tResponse = await _teacherService.GetClassById(ClassId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To create a new class for specific subject.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateClass(CreateClassDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.CreateClass(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update a specific class.
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateClass(UpdateClassDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.UpdateClass(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To delete a specific class by passing class id.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteClass(int ClassId)
        {
            try
            {
                var tResponse = await _teacherService.DeleteClass(ClassId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get all students.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var tResponse = await _teacherService.GetAllStudents();
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get a specific student info by passing student id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetStudentById(int StudentId)
        {
            try
            {
                var tResponse = await _teacherService.GetStudentById(StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update a specific student info.
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.UpdateStudent(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update a specific student from the system by passing student id.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            try
            {
                var tResponse = await _teacherService.DeleteStudent(StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get all subjects.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var tResponse = await _teacherService.GetAllSubjects();
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get a specific subject info by passing subject id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetSubjectById(int SubjectId)
        {
            try
            {
                var tResponse = await _teacherService.GetSubjectById(SubjectId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To create a new subject.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateSubject(CreateSubjectDTO dto)
        {
            try
            {
                var tRseponse = await _teacherService.CreateSubject(dto);
                return Ok(tRseponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update a specific subject.
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSubject(UpdateSubjectDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.UpdateSubject(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To delete a specific subject from the system by passing subject id.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteSubject(int SubjectId)
        {
            try
            {
                var tResponse = await _teacherService.DeleteSubject(SubjectId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get all evaluations.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEvaluations()
        {
            try
            {
                var tResponse = await _teacherService.GetAllEvaluations();
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get a specific evaluation by passing evaluation id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEvaluationById(int EvaluationId)
        {
            try
            {
                var tResponse = await _teacherService.GetEvaluationById(EvaluationId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To create a new evaluation.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateEvaluation(CreateEvaluationDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.CreateEvaluation(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update a specific evaluation info.
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEvaluation(UpdateEvaluationDTO dto)
        {
            try
            {
                var tResponse = await _teacherService.UpdateEvaluation(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To delete a specific evaluation by passing evaluation id.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEvaluation(int EvaluationId)
        {
            try
            {
                var tResponse = await _teacherService.DeleteEvaluation(EvaluationId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To get a specific studnet certificate on specific subject.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ViewStudnetCertificate(int StudentId, int SubjectId)
        {
            try
            {
                var tResponse = await _teacherService.ViewStudnetCertificate(StudentId, SubjectId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

    }
}
