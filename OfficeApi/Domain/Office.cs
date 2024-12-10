namespace OfficeApi.Domain
{
    public class Office
    {
        public Guid Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string OfficeNumber { get; set; }
        public required string RegistryPhoneNumber { get; set; }
        public bool Status { get; set; } //Is Active
    }
}
