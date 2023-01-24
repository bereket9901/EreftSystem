using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{

    [Table("User")]
    public class User : BaseEntity
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [ForeignKey("Role")]
        public int? RoleId { get; set; } = null;
        public virtual Role Role { get; set; }



    }
}