using PrintManagement.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class Design : BaseEntity
    {
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int DesignerId { get; set; }
        public string FilePath { get; set; }
        public DateTime DesignTime { get; set; }
        public DesignStatusEnum? DesignStatus { get; set; }
        public int ApproverId { get; set; } // Người duyệt thiết kế
        public virtual ICollection<PrintJob>? PrintJobs { get; set; }
    }
}
