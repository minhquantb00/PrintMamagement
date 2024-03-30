using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class ResourceForPrintJob : BaseEntity
    {
        public int ResourceId { get; set; }
        public virtual Resource? Resource { get; set; }
        public int PrintJobId { get; set; }
        public virtual PrintJob? PrintJob { get; set; }
    }
}
