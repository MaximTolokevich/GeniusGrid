namespace CredentialService.Entities
{
    public class User : BaseEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
