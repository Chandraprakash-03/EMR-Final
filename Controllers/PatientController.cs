using Microsoft.AspNetCore.Mvc;
using EMR_Final.Dto;
using EMR_Final.Services;
using System.Threading.Tasks;

namespace EMR_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // New Patient Registration
        [HttpPost("register")]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientRegistrationDto patientDto)
        {
            var result = await _patientService.RegisterNewPatientAsync(patientDto);

            if (result == null)
                return BadRequest(new { message = "Failed to register patient." });

            return Ok(result); // Returns GID and HRN
        }

        // Follow-Up (Review)
        [HttpGet("details/{gid}")]
        public async Task<IActionResult> GetPatientDetails(string gid)
        {
            var patientDetails = await _patientService.GetPatientDetailsAsync(gid);

            if (patientDetails == null)
                return NotFound(new { message = "Patient not found." });

            return Ok(patientDetails); // Returns all patient details
        }
    }
}
