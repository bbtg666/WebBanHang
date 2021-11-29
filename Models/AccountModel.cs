using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {
        private WebBanHangDBContext context;
        public AccountModel()
        {
            context = new WebBanHangDBContext();
        }
        public bool Login(string userName, string pwd)
        {
            object[] sqlParams = 
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", pwd)
            };
            var res = context.Database.SqlQuery<bool>("SP_Account_Login @UserName, @Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
