﻿using PrintManagement.Application.Payloads.ResponseModels.DataCustomer;
using PrintManagement.Application.Payloads.ResponseModels.DataDesign;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.ResponseModels.DataProject
{
    public class DataResponseProject : DataResponseBase
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string RequestDescriptionFromCustomer { get; set; }
        public DateTime StartDate { get; set; }
        public DataResponseUser Leader { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DataResponseCustomer Customer { get; set; }
        public decimal CommissionPercentage { get; set; }
        public string EmployeeCreateName { get; set; }
        public string ImageDescription { get; set; }
        public decimal StartingPrice { get; set; }
        public double? Progress { get; set; }
        public string ProjectStatus { get; set; }
        public IQueryable<DataResponseDesign> Designs { get; set; }
    }
}
