using System.ComponentModel.DataAnnotations;

public class Customer {

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set;}
}