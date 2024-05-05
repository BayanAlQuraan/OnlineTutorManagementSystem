using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTutorManagementSystem_Core.Helpers;
using OnlineTutorManagmentSystem_Core.Dtos.Account;
using OnlineTutorManagmentSystem_Core.IRepos;

namespace OnlineTutorManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentReposeController : ControllerBase
    {
        private readonly IStudentReposeInterface _studentRepose;

        public StudentReposeController(IStudentReposeInterface studentRepose)
        {
            _studentRepose = studentRepose;
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
                var tResponse = await _studentRepose.DeleteAccount(StudentId);
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
        public async Task<IActionResult> GetAllCertificates(int StudentId )
        {
            try
            {
                var tResponse = await _studentRepose.GetAllCertificates(StudentId);
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
        public async Task<IActionResult> GetCertificateById(int CertificateId )
        {
            try
            {
                var tResponse = await _studentRepose.GetCertificateById(CertificateId);
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
                var tResponse = await _studentRepose.LeaveClass(StudentId, ClassId);
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
                var tResponse = await _studentRepose.RegisterToClass(ClassId, StudentId);
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
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO dto )
        {
            try
            {
                var tResponse = await _studentRepose.UpdateProfile(dto);
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
        public async Task<IActionResult> ViewEvaluation(int EvaluationId )
        {
            try
            {
                var tResponse = await _studentRepose.ViewEvaluation(EvaluationId);
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
                var tResponse = await _studentRepose.ViewInvoiceById(InvoiceId);
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
                var tResponse = await _studentRepose.ViewSchedule(StudentId);
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
                var tResponse = await _studentRepose.GetStudentInvoices(StudentId);
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
