﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegisterLoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CRegisterLogin : IRegisterLogin
    {
        DatabaseHelper db = new DatabaseHelper();

        public string Register(string userName, string passWord, string confPassWord)
        {
           return db.Register(userName, passWord);
        }

        public string Login(string userName, string passWord)
        {
            return db.Login(userName, passWord);
        }


    }
}
