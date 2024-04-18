using PrintManagement.Application.Payloads.ResponseModels.DataDesign;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.ResponseModels.DataPrintJob
{
    public class DataResponsePrintJob : DataResponseBase
    {
        public DataResponseDesign Design { get; set; }
        public string PrintJobStatus { get; set; }
        public IQueryable<DataResponseResourceForPrintJob> ResourceForPrints { get; set; }
    }
}
