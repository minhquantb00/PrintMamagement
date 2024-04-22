using Microsoft.AspNetCore.Http;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.StatisticRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataStatistics;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.ImplementServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IBaseReposiroty<Bill> _billRepository;
        private readonly IBaseReposiroty<User> _userRepository;
        private readonly IBaseReposiroty<Team> _teamRepository;
        private readonly IBaseReposiroty<Customer> _customerRepository;
        private readonly IBaseReposiroty<Project> _projectRepository;
        public readonly UserConverter _userConverter;
        private readonly TeamConverter _teamConverter;
        private readonly IHttpContextAccessor _contextAccessor;
        public StatisticService(IBaseReposiroty<Bill> billRepository, IBaseReposiroty<User> userRepository, IBaseReposiroty<Team> teamRepository, IBaseReposiroty<Customer> customerRepository, IBaseReposiroty<Project> projectRepository, UserConverter userConverter, TeamConverter teamConverter, IHttpContextAccessor contextAccessor)
        {
            _billRepository = billRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _customerRepository = customerRepository;
            _projectRepository = projectRepository;
            _userConverter = userConverter;
            _teamConverter = teamConverter;
            _contextAccessor = contextAccessor;
        }

        //public async Task<IQueryable<DataResponseStatisticSalary>> GetStatisticSalary(Guid userId)
        //{
        //    var user = await _userRepository.GetByIDAsync(userId);
        //    try
        //    {
        //        var listProject = await _projectRepository.GetAllAsync(x => x.EmployeeCreateId == userId && x.Progress == 100);
        //        if (listProject == null)
        //        {
        //            throw new ArgumentNullException(nameof(listProject));
        //        }
        //        List<DataResponseStatisticSalary> result = new List<DataResponseStatisticSalary>();
        //        foreach (var item in listProject)
        //        {
        //            var listBill = await _billRepository.GetAllAsync(x => x.ProjectId == item.Id && x.BillStatus.ToString().Equals("Paid"));
        //            if(listBill == null)
        //            {
        //                throw new ArgumentNullException(nameof(listBill));
        //            }
        //            decimal salary = 0;
        //            var month = 0;
        //            for(int i = 0; i < listBill.ToList().Count; i++)
        //            {
        //                for(int j = 0; j < listBill.ToList().Count; j++)
        //                {
        //                    if (listBill.ToList()[i].CreateTime.Month == listBill.ToList()[j].CreateTime.Month)
        //                    {
        //                        month = listBill.ToList()[i].CreateTime.Month;
        //                        salary += listBill.ToList()[i].TotalMoney - (listBill.ToList()[i].TotalMoney * item.CommissionPercentage);
        //                    }
        //                    else
        //                    {
        //                        month = listBill.ToList()[i].CreateTime.Month;
        //                        salary = listBill.ToList()[i].TotalMoney - (listBill.ToList()[i].TotalMoney * item.CommissionPercentage);
        //                    }
        //                }
        //            }
        //            DataResponseStatisticSalary data = new DataResponseStatisticSalary
        //            {
        //                Month = month,
        //                Salary = salary,
        //                User = _userConverter.EntityToDTOForUser(user),
        //            };
        //            result.Add(data);
        //        }
        //        return result.AsQueryable();
        //    }catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<IQueryable<DataResponseStatisticSalary>> GetStatisticSalary(Guid userId)
        {
            var user = await _userRepository.GetByIDAsync(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var listProject = await _projectRepository.GetAllAsync(x => x.EmployeeCreateId == userId && x.Progress == 100);
            if (listProject == null || !listProject.Any())
            {
                return Enumerable.Empty<DataResponseStatisticSalary>().AsQueryable();
            }

            List<DataResponseStatisticSalary> result = new List<DataResponseStatisticSalary>();

            foreach (var project in listProject)
            {
                var listBill = await _billRepository.GetAllAsync(x => x.ProjectId == project.Id);
                if (listBill == null || !listBill.Any())
                {
                    continue;
                }

                var groupedByMonth = listBill
                    .GroupBy(b => b.CreateTime.Month)
                    .Select(g => new {
                        Month = g.Key,
                        Salary = g.Sum(b => b.TotalMoney * (1 - project.CommissionPercentage))
                    });

                foreach (var group in groupedByMonth)
                {
                    result.Add(new DataResponseStatisticSalary
                    {
                        Month = group.Month,
                        Salary = group.Salary,
                        User = _userConverter.EntityToDTOForUser(user)
                    });
                }
            }

            return result.AsQueryable();
        }


        public Task<IQueryable<DataResponseStatisticSales>> GetStatisticSales(Request_StatisticSales request)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DataResponseStatisticSalesOfUser>> GetStatisticSalesOfUserAsync(Guid userId, Request_StatisticSalesOfUser request)
        {
            throw new NotImplementedException();
        }
    }
}
