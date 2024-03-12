﻿namespace ArchivesExplorer.DataContext.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
