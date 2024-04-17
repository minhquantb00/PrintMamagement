using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.Mappers
{
    public class UserConverter
    {
        private readonly IBaseReposiroty<Team> _baseTeamRepository;
        public UserConverter(IBaseReposiroty<Team> baseTeamRepository)
        {
            _baseTeamRepository = baseTeamRepository;
        }
        public DataResponseUser EntityToDTOForUser(User user)
        {
            return new DataResponseUser
            {
                CreateTime = user.CreateTime,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FullName = user.FullName,
                Avatar = user.Avatar,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                TeamName = _baseTeamRepository.GetAsync(x => x.Id == user.TeamId).Result.Name
            };

            // 200: khi thực hiện yêu cầu thành công
            // 201: khi tạo đối tượng thành công
            // 400: dữ liệu truyền vào bị sai
            // 401: dữ liệu đó cần có xác thực 
            // 403: người dùng không đủ quyền thực hiện chức năng này
            // 404: Không tìm thấy dữ liệu
            // 405: HTTP Method bị sai yêu cầu
            // 415: định dạng của dữ liệu truyền lên bị sai
        }
    }
}
