using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Auth
{
    public interface IAuthBusiness
    {
        Task<LoginModel> CheckLogin(string username, string password);
        Task InsertRefreshToken(LoginModel login);   
    }
}
