using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.ResponseModels.DataPrintJob;
using PrintManagement.Application.Payloads.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.ImplementServices
{
    public class PrintJobService : IPrintJobService
    {
        public Task<ResponseObject<DataResponsePrintJob>> CreatePrintJob()
        {
            throw new NotImplementedException();
        }
    }
}
