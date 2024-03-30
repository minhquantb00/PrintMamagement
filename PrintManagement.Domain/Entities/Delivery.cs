﻿using PrintManagement.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class Delivery : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public Guid ShippingMethodId { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime EstimateDeliveryTime { get; set; }
        public DateTime? ActualDeliveryTime { get; set; }
        public DeliveryStatusEnum? DeliveryStatus { get; set; }
    }
}
