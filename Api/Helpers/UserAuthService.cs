using Api.Models;
using Api.Utils;
using Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class UserAuthService : IUserAuthService
    {
        private readonly gamdroidContext _context;

        public UserAuthService(gamdroidContext context)
        {
            _context = context;
        }

        public bool GetUserAuthorization(LoginModel login)
        {
            var user = _context.Client.FirstOrDefault(x => x.ClientCode == login.ClientCode);

            if (user != null)
                if (RngCryptoService.GetPasswordHash(user.Password, login.Password))
                    return true;

            return false;
        }

    }
}
