using Business.Model;
using Data.SqlConnect;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Auth
{
    public class AuthBusiness:IAuthBusiness
    {
        private readonly IDataConnection conn;
        public AuthBusiness(IDataConnection conn)
        {
            this.conn = conn;
        }
        public async Task<LoginModel> CheckLogin(string username,string password)
        {
            var response = await conn.GetData("Login_Verification", new { UserName = username,Password = password});
            ResponseModel<LoginModel> res = await response.ReadAsync<ResponseModel<LoginModel>>();
            if(res.Status == 400)
            {
                throw new Exception("Not found");
            }
            LoginModel loginModel = await response.ReadAsync<LoginModel>();
            res.data = loginModel;
            return loginModel;
        }
        public async Task InsertRefreshToken(LoginModel login)
        {
            var response = await conn.InsertData<Object>("insert_token", login);
            if(response.status == 400)
            {
                throw new Exception();
            }
        }
    }
}
