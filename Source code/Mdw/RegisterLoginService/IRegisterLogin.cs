using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegisterLoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "RegisterLoginService")]
    public interface IRegisterLogin
    {
        [OperationContract]
        string Register(string userName, string passWord, string confPWord);

        [OperationContract]
        string Login(string userName, string passWord);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "RegisterLoginService.ContractType".
    [DataContract]
    public class User
    {
        string userName;
        string passWord;
        string confPassWord;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        [DataMember]
        public string ConfPassWord
        {
            get { return confPassWord; }
            set { confPassWord = value; }
        }
    }
}
