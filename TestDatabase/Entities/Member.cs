using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabaseSqlite.Entities
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }
        public int MembershipNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int MembershipTypeId { get; set; }
        public int AccessInformationId { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual AccessInformation AccessInformation { get; set; }
    }
}
