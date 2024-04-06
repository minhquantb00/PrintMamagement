using PrintManagement.Application.Payloads.ResponseModels.DataResource;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.Mappers
{
    public class ResourceConverter
    {
        private readonly IBaseReposiroty<ResourceProperty> _reposiroty;
        private readonly ResourcePropertyConverter _propertyConverter;
        public ResourceConverter(IBaseReposiroty<ResourceProperty> reposiroty, ResourcePropertyConverter propertyConverter)
        {
            _reposiroty = reposiroty;
            _propertyConverter = propertyConverter;
        }
        public DataResponseResource EntityToDTO(Resource entity)
        {
            return new DataResponseResource
            {
                AvailableQuantity = entity.AvailableQuantity,
                Id = entity.Id,
                Image = entity.Image,
                ResourceName = entity.ResourceName,
                ResourceStatus = entity.ResourceStatus.ToString(),
                ResourceProperties = _reposiroty.GetAllAsync(x => x.ResourceId == entity.Id).Result.Select(x => _propertyConverter.EntityToDTO(x))
            };
        }
    }
}
