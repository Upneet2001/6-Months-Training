using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Attendee
{
        [Key]
    public int Attendee_id { get; set; }


    [StringLength(200)]
    public string? Attendee_name { get; set; }
    public string? Attendee_email { get; set; }
    public int Attendee_contact { get; set; }

    [StringLength(4000)]
    public string? Facebook_id { get; set; }
     public string? Linkedin_id { get; set; }
     public string? git { get; set; }
   
}