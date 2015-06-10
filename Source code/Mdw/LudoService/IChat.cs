using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LudoService
{

    [ServiceContract(Namespace = "ludoService", CallbackContract = typeof(IReceiveChatService))]
    public interface ISendChatService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, string sender, string receiver);
        [OperationContract(IsOneWay = true)]
        void Start(string name);
        [OperationContract(IsOneWay = true)]
        void Stop(string name);
    }

    public interface IReceiveChatService
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string msg, string receiver);
        [OperationContract(IsOneWay = true)]
        void SendNames(List<string> names);
    }
}