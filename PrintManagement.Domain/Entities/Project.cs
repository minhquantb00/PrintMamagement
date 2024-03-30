using PrintManagement.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public Guid LeaderId { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public double? Progress { get; set; } = 0;
        public ProjectStatusEnum? ProjectStatus { get; set; } = ProjectStatusEnum.Initialization;
        public virtual ICollection<Delivery>? Deliveries { get; set; }
        public virtual ICollection<CustomerFeedback>? CustomerFeedbacks { get; set; }
        public virtual ICollection<Design>? Designs { get; set; }
    }
}
