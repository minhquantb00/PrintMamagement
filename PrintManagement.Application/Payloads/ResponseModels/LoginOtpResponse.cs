using PrintManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Payloads.ResponseModels
{
    public class LoginOtpResponse
    {
        public string Token { get; set; } = string.Empty;
        public bool IsTwoFactorEnable { get; set; }
        public DataResponseUser User { get; set; } = null!;
    }
}
