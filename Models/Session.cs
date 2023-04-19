using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Session
{
    [Key]
    public int Session_id { get; set; }
      public int Session_date { get; set; }

   
    [StringLength(200)]
    public string? Topic { get; set; }

    [StringLength(4000)]
    public string? Description { get; set; }

   public int Speaker_id { get; set; }
    public string? Location { get; set; }
}