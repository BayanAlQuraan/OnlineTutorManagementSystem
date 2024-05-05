using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagmentSystem_Core.Dtos.Invoice;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;

namespace OnlineTutorManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherServiceController : ControllerBase
    {
        private readonly ITeacherServiceInterface _teacherservice;

        public TeacherServiceController(ITeacherServiceInterface teacherservice)
        {
            _teacherservice = teacherservice;
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
                Teacher tTeacher = await _teacherservice.Login(dto);
                if (tTeacher != null)
                {
                    //Generate Token
                    string token = AuthenticationService.GenerateJWTToken(tTeacher.Id.ToString(),"Teacher");
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
                var tResponse = await _teacherservice.GenerateStudentInvoice(dto);
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
                var tResponse = await _teacherservice.GrantStudentToGetCetificate(StudentId, SubjectId);
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
