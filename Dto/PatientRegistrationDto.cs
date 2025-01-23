namespace EMR_Final.Dto
{
    public class PatientRegistrationDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public DateTime Dob { get; set; }
        public string MobileNumber { get; set; }
        public bool IsNew { get; set; } // True for new patient, false for review
    }
}
