using System;

namespace EMR_Final.Models
{
    public class User
    {
        public int userid { get; set; }                // Primary Key
        public string username { get; set; }      // Username
        public string passwordhash { get; set; }      // Hashed Password
        public string email { get; set; }         // Email
        public string role { get; set; }          // Role (e.g., Admin, Doctor, Nurse, Patient)
        public bool isadmin { get; set; }         // Is the user an admin?
        public DateTime createdat { get; set; }   // Timestamp of creation
        public bool isactive { get; set; }        // Is the account active?
    }
}
