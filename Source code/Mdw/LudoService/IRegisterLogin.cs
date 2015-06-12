using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Drawing;

namespace LudoService
{
    [ServiceContract(Namespace = "ludoService")]
    interface IRegisterLogin
    {
        [OperationContract(IsOneWay = false)]
        string Register(string userName, string passWord, string confPassWord);

        [OperationContract(IsOneWay = false)]
        string Login(string userName, string passWord, Color color);
    }
}
