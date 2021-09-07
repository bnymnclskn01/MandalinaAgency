using Mandalina.DAL.Repository;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.LoginManager
{
    public class LoginManager
    {
        public bool Login(string userName, string Password)
        {
            Repository<Member> repoMember = new Repository<Member>();
            var logincontrol = repoMember.GetById(x => x.UserName == userName && x.Password == Password);
            if (logincontrol != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
