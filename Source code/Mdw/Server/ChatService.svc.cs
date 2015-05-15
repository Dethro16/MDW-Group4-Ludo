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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChat
    {

        public void Login(string user)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            var User = new ChatUser { User = user, LoginTime = DateTime.Now };
        }

        public void Logout()
        {

        }

        public void Send(string message)
        {
        


        }


    }
}
