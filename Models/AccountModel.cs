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
            Account user = context.Accounts.Where(c => c.UserName == userName && c.Password == pwd).FirstOrDefault();
            if(user == null)
            {
                return false;
            }
            return true;
        }
    }
}
