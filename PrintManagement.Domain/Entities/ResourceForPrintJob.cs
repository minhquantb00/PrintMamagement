using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class ResourceForPrintJob : BaseEntity
    {
        public Guid ResourceId { get; set; }
        public virtual Resource? Resource { get; set; }
        public Guid PrintJobId { get; set; }
        public virtual PrintJob? PrintJob { get; set; }
    }
}
