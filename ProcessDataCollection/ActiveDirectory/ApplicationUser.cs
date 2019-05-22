using System;

namespace KittingApplication.ActiveDirectory
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string SocketName { get; set; }
        public string Theme { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
        public string OperatorId { get; set; }
        public UserPreferences UserPreferences { get; set; }
    }
}