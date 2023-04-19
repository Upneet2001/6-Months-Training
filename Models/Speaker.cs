using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class Speaker
{
        [Key]
    public int Speaker_id { get; set; }
    [StringLength(200)]
    public string? Speaker_name { get; set; }

    [StringLength(4000)]
    public string? Facebook_id { get; set; }
     public string? Linkedin_id { get; set; }
     public string? git { get; set; }
      public string? twitter { get; set; }
      
      public string? bio { get; set; }
      
      public string? About_Experience { get; set; }
      
      public string? Interest { get; set; }

    [StringLength(1000)]
    public virtual string? WebSite { get; set; }
}