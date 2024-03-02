namespace CRMCloud.Models
{
    public class CreateContact
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BusinessRole { get; set; }
        public List<string>? Category { get; set; }
    }
}
