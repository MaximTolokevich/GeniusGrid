using DAL.Entities.Interfaces;

namespace DAL.Entities
{
    public class UserDbEntry : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
