namespace storeworkingapi.Models
{
    public class AddEmployeeRequestDTO
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public string Address { get; set; }
    }
}
