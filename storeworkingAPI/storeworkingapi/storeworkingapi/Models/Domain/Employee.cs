namespace storeworkingapi.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public string Address { get; set; }
    }
}
