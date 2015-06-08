using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegisterLogin" in both code and config file together.
    [ServiceContract(Namespace = "ludoService")]
    public interface IRegisterLogin
    {
        [OperationContract]
        string Register(string userName, string passWord, string confPWord);

        [OperationContract]
        string Login(string userName, string passWord, Color color);
    }
}
