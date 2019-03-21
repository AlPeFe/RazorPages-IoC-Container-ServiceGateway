using Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public interface IUserAuthService
    {
        bool GetUserAuthorization(LoginModel login);
    }
}
