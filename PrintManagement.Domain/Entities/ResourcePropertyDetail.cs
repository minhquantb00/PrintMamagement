using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class ResourcePropertyDetail : BaseEntity
    {
        public int PropertyId { get; set; }
        public virtual ResourceProperty? ResourceProperty { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<ImportCoupon>? ImportCoupons { get; set; }
    }
}
