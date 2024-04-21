using PrintManagement.Application.Payloads.ResponseModels.DataProject;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.Mappers
{
    public class ProjectConverter
    {
        private readonly IBaseReposiroty<Project> _baseProjectRepository;
        private readonly CustomerConverter _customerConverter;
        private readonly UserConverter _userConverter;
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IBaseReposiroty<Customer> _baseCustomerRepository;
        private readonly IBaseReposiroty<Design> _baseDesignRepository;
        private readonly DesignConverter _designConverter;
        public ProjectConverter(IBaseReposiroty<Project> baseProjectRepository, CustomerConverter customerConverter, UserConverter userConverter, IBaseReposiroty<Customer> baseCustomerRepository, IBaseReposiroty<Design> baseDesignRepository, IBaseReposiroty<User> baseUserRepository, DesignConverter designConverter)
        {
            _baseProjectRepository = baseProjectRepository;
            _customerConverter = customerConverter;
            _userConverter = userConverter;
            _baseUserRepository = baseUserRepository;
            _baseCustomerRepository = baseCustomerRepository;
            _baseDesignRepository = baseDesignRepository;
            _designConverter = designConverter;
        }
        public  DataResponseProject EntityToDTOForProject(Project project)
        {
            var customer = _baseCustomerRepository.GetByIDAsync(project.CustomerId);
            var leader = _baseUserRepository.GetByIDAsync(project.LeaderId);
            return new DataResponseProject
            {
                ActualEndDate = project.ActualEndDate,
                Customer = _customerConverter.EntityToDTOForCustomer(customer.Result),
                Description = project.Description,
                ExpectedEndDate = project.ExpectedEndDate,
                Id = project.Id,
                Leader = _userConverter.EntityToDTOForUser(leader.Result),
                Progress = project.Progress,
                ProjectName = project.ProjectName,
                ProjectStatus = project.ProjectStatus.ToString(),
                RequestDescriptionFromCustomer = project.RequestDescriptionFromCustomer,
                StartDate = project.StartDate,
                StartingPrice = project.StartingPrice,
                ImageDescription = project.ImageDescription,
                EmployeeCreateName = _baseUserRepository.GetAsync(x => x.Id == project.EmployeeCreateId).Result.FullName,
                Designs = _baseDesignRepository.GetAllAsync(x => x.IsActive == true).Result.Select(x => _designConverter.EntityToDTOForDesign(x))
            };
        }
    }
}
