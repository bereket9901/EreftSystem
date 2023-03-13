using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Role")]
    public class Role : IdentityRole<int>
    {
        
    }
}