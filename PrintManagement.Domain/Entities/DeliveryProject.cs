using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class DeliveryProject : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public Guid DeliveryId { get; set; }
        public virtual Delivery? Delivery { get; set; }
    }
}
