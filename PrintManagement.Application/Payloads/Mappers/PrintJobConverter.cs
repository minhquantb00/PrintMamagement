using PrintManagement.Application.Payloads.ResponseModels.DataPrintJob;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.Mappers
{
    public class PrintJobConverter
    {
        private readonly IBaseReposiroty<Design> _baseDesignRepository;
        private readonly IBaseReposiroty<ResourceForPrintJob> _repository;
        private readonly ResourceForPrintJobConverter _converter;
        private readonly DesignConverter _designConverter;
        public PrintJobConverter(IBaseReposiroty<Design> baseDesignRepository, IBaseReposiroty<ResourceForPrintJob> repository, ResourceForPrintJobConverter converter, DesignConverter designConverter)
        {
            _baseDesignRepository = baseDesignRepository;
            _repository = repository;
            _converter = converter;
            _designConverter = designConverter;
        }

        public DataResponsePrintJob EntityToDTO(PrintJob printJob)
        {
            return new DataResponsePrintJob
            {
                Id = printJob.Id,
                PrintJobStatus = printJob.PrintJobStatus.ToString(),
                Design = _designConverter.EntityToDTOForDesign(_baseDesignRepository.GetAsync(x => x.Id == printJob.DesignId).Result),
                ResourceForPrints = _repository.GetAllAsync(x => x.PrintJobId == printJob.Id).Result.Select(x => _converter.EntityToDTO(x)),
            };
        }
    }
}
