using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagmentSystem_Core.Dtos.Class;
using OnlineTutorManagmentSystem_Core.Dtos.Evaluation;
using OnlineTutorManagmentSystem_Core.Dtos.Student;
using OnlineTutorManagmentSystem_Core.Dtos.Subject;
using OnlineTutorManagmentSystem_Core.IRepos;

namespace OnlineTutorManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherReposController : ControllerBase
    {
        private readonly ITeacherReposeInterface _teacherRepose;

        public TeacherReposController(ITeacherReposeInterface teacherRepose)
        {
            _teacherRepose = teacherRepose;
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
                var tResponse = await _teacherRepose.GetAllClasses();
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
                var tResponse = await _teacherRepose.GetClassById(ClassId);
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
                var tResponse = await _teacherRepose.CreateClass(dto);
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
                var tResponse = await _teacherRepose.UpdateClass(dto);
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
                var tResponse = await _teacherRepose.DeleteClass(ClassId);
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
                var tResponse = await _teacherRepose.GetAllStudents();
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
                var tResponse = await _teacherRepose.GetStudentById(StudentId);
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
                var tResponse = await _teacherRepose.UpdateStudent(dto);
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
                var tResponse = await _teacherRepose.DeleteStudent(StudentId);
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
                var tResponse = await _teacherRepose.GetAllSubjects();
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
                var tResponse = await _teacherRepose.GetSubjectById(SubjectId);
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
                var tRseponse = await _teacherRepose.CreateSubject(dto);
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
                var tResponse = await _teacherRepose.UpdateSubject(dto);
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
                var tResponse = await _teacherRepose.DeleteSubject(SubjectId);
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
                var tResponse = await _teacherRepose.GetAllEvaluations();
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
                var tResponse = await _teacherRepose.GetEvaluationById(EvaluationId);
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
                var tResponse = await _teacherRepose.CreateEvaluation(dto);
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
                var tResponse = await _teacherRepose.UpdateEvaluation(dto);
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
                var tResponse = await _teacherRepose.DeleteEvaluation(EvaluationId);
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
                var tResponse = await _teacherRepose.ViewStudnetCertificate(StudentId, SubjectId);
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

