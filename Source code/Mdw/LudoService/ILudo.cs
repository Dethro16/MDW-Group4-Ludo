using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "ludoService", SessionMode = SessionMode.Required, CallbackContract = typeof(ILudoCallback))]
    public interface ILudo
    {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract(IsOneWay = false)]
        int GetDiceRoll();

        [OperationContract(IsOneWay = true)]
        void Roll(string userName);

        [OperationContract(IsOneWay = true)]
        void StartGame();

        [OperationContract(IsOneWay = true)]
        void CreatePlayer(string playerName, Color color);

        [OperationContract(IsOneWay = false)]
        string GetPlayer(Color color);

        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Unsubscribe();
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "LudoService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    public interface ILudoCallback
    {
        [OperationContract(IsOneWay = true)]
        void showDiceRoll(string userName, int diceNumber);


    }
}
