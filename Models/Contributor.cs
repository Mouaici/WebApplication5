namespace WebApplication4.Models;

public class Contributor
{
    public int Id { get; set; }

    public string FullName { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public string Address { get; set; } = "";

    public decimal HourlyRate { get; set; } = 750;
}
