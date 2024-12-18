using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Helper.Entity
{
    public partial class BeAuditLog
    {
        public int Id { get; set; }

        public string? Form { get; set; }

        public short? ErrorLevel { get; set; }

        public short? EventId { get; set; }

        public string? UserEmail { get; set; }

        public string? Ip { get; set; }

        public DateTime? LogTime { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Browser { get; set; }

        public string? TableId { get; set; }
    }
}
