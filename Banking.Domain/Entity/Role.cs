using Banking.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Entity
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public RoleName Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }  
    }
}
