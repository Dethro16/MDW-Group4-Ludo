using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "ludoService", SessionMode = SessionMode.Required, CallbackContract = typeof(ILudoCallback))]
    public interface ILudo
    {
        [OperationContract(IsOneWay = false)]
        int GetDiceRoll();

        [OperationContract(IsOneWay = true)]
        void Roll(string userName);

        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Unsubscribe();
        // TODO: Add your service operations here
    }

    public interface ILudoCallback
    {
        [OperationContract(IsOneWay = true)]
        void showDiceRoll(string userName, int diceNumber);
    }
}
