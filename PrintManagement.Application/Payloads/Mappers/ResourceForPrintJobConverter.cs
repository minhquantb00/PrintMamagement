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
    public class ResourceForPrintJobConverter
    {
        private readonly IBaseReposiroty<Resource> _repository;
        private readonly ResourceConverter _converter;
        public ResourceForPrintJobConverter(IBaseReposiroty<Resource> repository, ResourceConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public DataResponseResourceForPrintJob EntityToDTO(ResourceForPrintJob resourceForPrintJob)
        {
            return new DataResponseResourceForPrintJob
            {
                Id = resourceForPrintJob.Id,
                Resource = _converter.EntityToDTO(_repository.GetAsync(x => x.Id == resourceForPrintJob.ResourceId).Result),
            };
        }
    }
}
