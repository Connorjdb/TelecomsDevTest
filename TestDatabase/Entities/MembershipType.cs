using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabaseSqlite.Entities
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public int DayFrom { get; set; }
        public int DayTo { get; set; }
    }
}
