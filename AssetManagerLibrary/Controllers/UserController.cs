using AMModel;
using AMModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMController.Controllers
{
    public class UserController : UserModel
    {

        public UserController()
        {

        }

        public bool authenticate(string name,string pswd)
        {
            UserName = name;
            Select();
            return pswd.Equals(Password) && Group.Length > 0;
        }
    }
}
