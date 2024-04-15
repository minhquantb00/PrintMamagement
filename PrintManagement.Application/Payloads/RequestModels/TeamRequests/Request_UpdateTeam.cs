﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.RequestModels.TeamRequests
{
    public class Request_UpdateTeam
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ManagerId { get; set; }
    }
}
