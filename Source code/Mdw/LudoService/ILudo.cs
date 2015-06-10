﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Drawing;

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

        [OperationContract(IsOneWay = false)]
        string Register(string userName, string passWord, string confPassWord);

        [OperationContract(IsOneWay = false)]
        string Login(string userName, string passWord, Color color);

        [OperationContract(IsOneWay = false)]
        string GetColorPlayer(Color color);

        // TODO: Add your service operations here
    }

<<<<<<< HEAD
=======
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "LudoService.ContractType".


>>>>>>> origin/NewCreatePlayers
    public interface ILudoCallback
    {
        [OperationContract(IsOneWay = true)]
        void showDiceRoll(string userName, int diceNumber);
    }
}
