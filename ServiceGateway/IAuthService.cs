using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mappers;
using Mappers.Dto;

namespace ServiceGateway
{
    public interface IAuthService
    {
        Task<Token> GetAuthToken(LoginModel login);
    }
}
