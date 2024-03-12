﻿namespace ArchivesExplorer.DataContext.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
