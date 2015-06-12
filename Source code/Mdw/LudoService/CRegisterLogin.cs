using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
    class CRegisterLogin : IRegisterLogin
    {
        DatabaseHelper db = new DatabaseHelper();

        public string Register(string userName, string passWord, string confPassWord)
        {
            return db.Register(userName, passWord);
        }


        public string Login(string userName, string passWord, Color color)
        {
            string check = db.Login(userName, passWord);

            return check;
        }
    }
}
