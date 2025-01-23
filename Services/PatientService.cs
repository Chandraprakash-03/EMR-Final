using System;
using System.Linq;
using System.Threading.Tasks;
using EMR_Final.Dto;
using EMR_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace EMR_Final.Services
{
    public class PatientService : IPatientService
    {
        private readonly EMRDbContext _context;

        public PatientService(EMRDbContext context)
        {
            _context = context;
        }

        public async Task<PatientResponseDto> RegisterNewPatientAsync(PatientRegistrationDto patientDto)
        {
            // Generate unique GID and HRN
            string GID = GenerateUniqueGID();  // Correctly invoking the method
            string HRN = GenerateUniqueHRN();  // HRN generation remains the same

            var newPatient = new Patient
            {
                gid = GID,  // Assign the 10-digit string GID
                hrn = HRN,  // Assign the 8-digit string HRN
                name = patientDto.Name,
                age = patientDto.Age,
                gender = patientDto.Gender,
                location = patientDto.Location,
                dob = patientDto.Dob,
                mobile_number = patientDto.MobileNumber,
                is_new = patientDto.IsNew
            };

            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();

            return new PatientResponseDto
            {
                GID = newPatient.gid,  // Returning the generated GID and HRN
                HRN = newPatient.hrn

            };
        }


        private string GenerateUniqueGID()
        {
            // Generate a 10-digit string
            string gid;
            Random rand = new Random();
            do
            {
                gid = rand.Next(1000000000, int.MaxValue).ToString();  // Generate a 10-digit string
            } while (_context.Patients.Any(p => p.gid == gid));  // Ensure uniqueness

            return gid;
        }

        private string GenerateUniqueHRN()
        {
            // Generate an 8-digit string for HRN
            string hrn;
            Random rand = new Random();
            do
            {
                hrn = rand.Next(10000000, 100000000).ToString();  // Generate an 8-digit string
            } while (_context.Patients.Any(p => p.gid == hrn));  // Ensure uniqueness

            return hrn;
        }

        public async Task<PatientDetailsDto> GetPatientDetailsAsync(string gid)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.gid == gid);

            if (patient == null) return null;

            return new PatientDetailsDto
            {
                GID = patient.gid,
                HRN = patient.hrn,
                Name = patient.name,
                Age = patient.age,
                Gender = patient.gender,
                Location = patient.location,
                Dob = patient.dob,
                MobileNumber = patient.mobile_number,
                CreatedAt = patient.created_at
            };
        }
    }
}
