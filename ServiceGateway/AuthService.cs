using Mappers.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateway
{
    public class AuthService : IAuthService
    {
        public async Task<Token> GetAuthToken(LoginModel login)
        {
            var test = JsonConvert.SerializeObject(login);

            var json = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            var response = await ServiceClient.Instance.PostAsync("/api/Auth/Login", json);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Token>(content);
            }
         
            return new Token {  JwtToken = "" };
        }
    }
}
