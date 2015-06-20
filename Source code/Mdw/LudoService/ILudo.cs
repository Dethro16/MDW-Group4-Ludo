﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "ludoService", CallbackContract = typeof(ILudoCallback))]
    public interface ILudo
    {
        [OperationContract]
        string RollToClient(string playername);

        [OperationContract]
        void Roll(string playername);

        [OperationContract]
        int NumberToClient();

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void CreatePlayers(string userName, Color color);

        [OperationContract]
        string ChatToClient(string playername, string message);

        [OperationContract]
        void GetPlayerColor(string playername, Color color);

        [OperationContract]
        void StartGame();

        [OperationContract]
        void NextTurn();

        [OperationContract]
        string PutTokenInPlay(Color color, bool remove);

        [OperationContract]
        void PlaceToken(string playername, string tokenname, Color color, string destination);

        [OperationContract]
        string GetPlayer(Color color);

        [OperationContract]
        void Chat(string playername, string message);

        [OperationContract]
        bool Check(string playerName);

        [OperationContract]
        string MoveToken(string field, Color color);

        [OperationContract]
        void MoveToClient(string playername, string tokenname, Color color, string destination);
    }

    public class Player
    {
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public Color Color { get; set; }
        [DataMember]
        public bool HasWon { get; set; }
        [DataMember]
        public bool Loggedin { get; set; }
        [DataMember]
        public bool First { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public bool RolledSix { get; set; }
        [DataMember]
        public List<Token> BaseTokens { get; set; }
        [DataMember]
        public List<Token> FieldTokens { get; set; }

        [DataMember]
        public ILudoCallback callback { get; set; }

        public Player(string name, Color color)
        {

            this.PlayerName = name;
            this.Color = color;
            this.HasWon = false;
            this.Loggedin = true;
            this.BaseTokens = new List<Token>(4);
            this.FieldTokens = new List<Token>();

            for (int i = 0; i < 4; i++)
            {
                BaseTokens.Add(new Token(color));
            }

            foreach (Token item in BaseTokens)
            {
                item.Color = this.Color;
            }

        }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "LudoService.ContractType".

    public interface ILudoCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnChatCallback(string userName, string message);

        [OperationContract(IsOneWay = true)]
        void OnRollCallback(string playername, int diceroll);

        [OperationContract(IsOneWay = true)]
        void OnPlayerLogin(string playername, Color color);

        [OperationContract(IsOneWay = true)]
        void OnPlayerTurn();

        [OperationContract(IsOneWay = true)]
        void OnPlaceToken(string TokenName, Color color, string destination);

        [OperationContract(IsOneWay = true)]
        void OnMoveToken(string TokenName, Color color, string destination);
    }
}
