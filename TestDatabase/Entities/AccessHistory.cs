using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabaseSqlite.Entities
{
    public class AccessHistory
    {
        [Key]
        public int Id { get; set; }
        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
        public DateTime? AcccessDateTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}
