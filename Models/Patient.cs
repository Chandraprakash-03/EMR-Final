using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("patient_details")]
public class Patient
{
    [Key]
    [MaxLength(10)]  // GID is now a 10-character string
    public string gid { get; set; } // Global ID (10-character string)

    [Required]
    [MaxLength(8)]  // HRN is now an 8-character string
    public string hrn { get; set; } // Health Record Number (8-character string)

    [Required]
    [MaxLength(100)]
    public string name { get; set; }

    [Required]
    public int age { get; set; }

    [Required]
    [MaxLength(10)]
    public string gender { get; set; }

    [MaxLength(150)]
    public string location { get; set; }

    [Required]
    public DateTime dob { get; set; }

    [Required]
    [MaxLength(15)]
    public string mobile_number { get; set; }

    [Required]
    public bool is_new { get; set; }

    public DateTime created_at { get; set; } = DateTime.UtcNow;
}
