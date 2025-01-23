using EMR_Final.Dto;
using System.Threading.Tasks;

namespace EMR_Final.Services
{
    public interface IPatientService
    {
        Task<PatientResponseDto> RegisterNewPatientAsync(PatientRegistrationDto patientDto);
        Task<PatientDetailsDto> GetPatientDetailsAsync(string gid);
    }
}
