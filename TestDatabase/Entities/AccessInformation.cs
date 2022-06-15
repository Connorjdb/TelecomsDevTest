using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabaseSqlite.Entities
{
    public class AccessInformation
    {
        [Key]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Code { get; set; }
    }
}
