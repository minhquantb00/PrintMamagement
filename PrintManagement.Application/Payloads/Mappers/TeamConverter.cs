using PrintManagement.Application.Payloads.ResponseModels.DataTeam;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.Mappers
{
    public class TeamConverter
    {
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly UserConverter _userConverter;
        public TeamConverter(IBaseReposiroty<User> baseUserRepository, UserConverter userConverter)
        {
            _baseUserRepository = baseUserRepository;
            _userConverter = userConverter;
        }
        public DataResponseTeam EntityToDTO(Team entity)
        {
            return new DataResponseTeam
            {
                CreateTime = entity.CreateTime,
                Description = entity.Description,
                Id = entity.Id,
                ManagerName = entity.ManagerId != null ? _baseUserRepository.GetByIDAsync(entity.ManagerId).Result.FullName : "",
                Name = entity.Name,
                NumberOfMember = entity.NumberOfMember,
                UpdateTime = entity.UpdateTime,
                Users = _baseUserRepository.GetAllAsync(x => x.TeamId == entity.Id).Result.Select(x => _userConverter.EntityToDTOForUser(x))
            };
        }
    }
}
