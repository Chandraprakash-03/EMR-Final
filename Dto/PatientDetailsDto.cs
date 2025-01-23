namespace EMR_Final.Dto
{
    public class PatientDetailsDto
    {
        public string GID { get; set; }
        public string HRN { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public DateTime Dob { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
