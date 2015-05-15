using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Mdw;


namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract=typeof (IChatClient))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void Login(string user);
        [OperationContract(IsOneWay = true)]
        void Logout();
        [OperationContract(IsOneWay = true)]
        void Send(string message);

    }

    public interface IChatReceive
    {
        [OperationContract(IsOneWay=true)]
        void ReceiveMessage(string message, string sender);

        [OperationContract(IsOneWay=true)]
        void SendUsers(List<string> users);
    }


    [DataContract]
    public class ChatUser
    {
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public DateTime LoginTime { get; set; }
    }



}
