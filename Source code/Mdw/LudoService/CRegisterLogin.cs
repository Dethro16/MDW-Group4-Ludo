using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegisterLogin" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CRegisterLogin : IRegisterLogin
    {
        DatabaseHelper db = new DatabaseHelper();
        Player player = new Player("", Color.Black);

        public string Register(string userName, string passWord, string confPassWord)
        {
            return db.Register(userName, passWord);
        }

        public string Login(string userName, string passWord, Color color)
        {
            string check = db.Login(userName, passWord);
            if (check.Contains("successfully"))
            {
                player.CreatePlayer(userName, color);
                return check;
            }
            else
            {
                return check;
            }
        }
    }
}
