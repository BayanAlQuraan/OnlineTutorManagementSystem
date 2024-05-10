using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagementSystem_Infra.Repos;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.Dtos.Login;
using OnlineTutorManagmentSystem_Core.IService;
using OnlineTutorManagmentSystem_Core.Models.Entities;

namespace OnlineTutorManagementSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentServiceController : ControllerBase
    {
        private readonly IStudentServiceInterface _studentService;
        public StudentServiceController(IStudentServiceInterface studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// To login into the system by passing the student email and password.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginReqDTO dto)
        {
            try
            {
                //If login usrename and password are correct then proceed to generate token
                Student tStudent = await _studentService.Login(dto);
                if (tStudent != null)
                {
                    string token = AuthenticationService.GenerateJWTToken(tStudent.Id.ToString(), "Student");
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
        /// To create student type account.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAccount(RegistrationDTO dto)
        {
            try
            {
                var tResponse = await _studentService.CreateAccount(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To Pay a specific student invoice by passing the invoice id and the toal amount you need to pay and the payment method.
        /// </summary>
        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> PayInvoices(int InvoiceId, double Amount, string PaymentMethod)
        {
            try
            {
                var tResponse = await _studentService.PayInvoices(InvoiceId, Amount, PaymentMethod);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To reset the student account password.
        /// </summary>
        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            try
            {
                var tResponse = await _studentService.ResetPassword(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To delete student account by passing the student id.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteAccount(int StudentId)
        {
            try
            {
                var tResponse = await _studentService.DeleteAccount(StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To get all student certificates by passing the student id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCertificates(int StudentId)
        {
            try
            {
                var tResponse = await _studentService.GetAllCertificates(StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// To get one certificate by passing the certificate id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCertificateById(int CertificateId)
        {
            try
            {
                var tResponse = await _studentService.GetCertificateById(CertificateId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To leave a specific class by passing the student and class ids.
        /// </summary>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> LeaveClass(int StudentId, int ClassId)
        {
            try
            {
                var tResponse = await _studentService.LeaveClass(StudentId, ClassId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To join into a specific class by passing the student and class ids.
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterToClass(int ClassId, int StudentId)
        {
            try
            {
                var tResponse = await _studentService.RegisterToClass(ClassId, StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To update the student account information.
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO dto)
        {
            try
            {
                var tResponse = await _studentService.UpdateProfile(dto);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To view the student evaluation by passing the evaluation id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ViewEvaluation(int EvaluationId)
        {
            try
            {
                var tResponse = await _studentService.ViewEvaluation(EvaluationId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To view a specific student invocie by passing the invoiceId id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ViewInvoiceById(int InvoiceId)
        {
            try
            {
                var tResponse = await _studentService.ViewInvoiceById(InvoiceId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To view a specific student schedule by passing the student id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ViewSchedule(int StudentId)
        {
            try
            {
                var tResponse = await _studentService.ViewSchedule(StudentId);
                return Ok(tResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// To view a specific student invocies by passing the student id.
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetStudentInvoices(int StudentId)
        {
            try
            {
                var tResponse = await _studentService.GetStudentInvoices(StudentId);
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
