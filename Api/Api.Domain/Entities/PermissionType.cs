using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class PermissionType
    {
        public short Id { get; set; }
        public string Description { get; set; }

        public ICollection<Permission> Permissions { get; private set; } = new List<Permission>();
    }
}
