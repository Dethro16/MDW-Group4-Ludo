﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdw.LudoGamePlayServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="ludoService", ConfigurationName="LudoGamePlayServiceReference.ILudo", CallbackContract=typeof(Mdw.LudoGamePlayServiceReference.ILudoCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ILudo {
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetDiceRoll", ReplyAction="ludoService/ILudo/GetDiceRollResponse")]
        int GetDiceRoll();
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetDiceRoll", ReplyAction="ludoService/ILudo/GetDiceRollResponse")]
        System.Threading.Tasks.Task<int> GetDiceRollAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="ludoService/ILudo/Roll")]
        void Roll(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="ludoService/ILudo/Roll")]
        System.Threading.Tasks.Task RollAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Subscribe", ReplyAction="ludoService/ILudo/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Subscribe", ReplyAction="ludoService/ILudo/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, Action="ludoService/ILudo/Unsubscribe")]
        void Unsubscribe();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsTerminating=true, Action="ludoService/ILudo/Unsubscribe")]
        System.Threading.Tasks.Task UnsubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Register", ReplyAction="ludoService/ILudo/RegisterResponse")]
        string Register(string userName, string passWord, string confPassWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Register", ReplyAction="ludoService/ILudo/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string userName, string passWord, string confPassWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Login", ReplyAction="ludoService/ILudo/LoginResponse")]
        string Login(string userName, string passWord, System.Drawing.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/Login", ReplyAction="ludoService/ILudo/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string userName, string passWord, System.Drawing.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetColorPlayer", ReplyAction="ludoService/ILudo/GetColorPlayerResponse")]
        string GetColorPlayer(System.Drawing.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetColorPlayer", ReplyAction="ludoService/ILudo/GetColorPlayerResponse")]
        System.Threading.Tasks.Task<string> GetColorPlayerAsync(System.Drawing.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetPlayerName", ReplyAction="ludoService/ILudo/GetPlayerNameResponse")]
        string GetPlayerName();
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/ILudo/GetPlayerName", ReplyAction="ludoService/ILudo/GetPlayerNameResponse")]
        System.Threading.Tasks.Task<string> GetPlayerNameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILudoCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="ludoService/ILudo/showDiceRoll")]
        void showDiceRoll(string userName, int diceNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILudoChannel : Mdw.LudoGamePlayServiceReference.ILudo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LudoClient : System.ServiceModel.DuplexClientBase<Mdw.LudoGamePlayServiceReference.ILudo>, Mdw.LudoGamePlayServiceReference.ILudo {
        
        public LudoClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public LudoClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public LudoClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LudoClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LudoClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int GetDiceRoll() {
            return base.Channel.GetDiceRoll();
        }
        
        public System.Threading.Tasks.Task<int> GetDiceRollAsync() {
            return base.Channel.GetDiceRollAsync();
        }
        
        public void Roll(string userName) {
            base.Channel.Roll(userName);
        }
        
        public System.Threading.Tasks.Task RollAsync(string userName) {
            return base.Channel.RollAsync(userName);
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe() {
            base.Channel.Unsubscribe();
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync() {
            return base.Channel.UnsubscribeAsync();
        }
        
        public string Register(string userName, string passWord, string confPassWord) {
            return base.Channel.Register(userName, passWord, confPassWord);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string userName, string passWord, string confPassWord) {
            return base.Channel.RegisterAsync(userName, passWord, confPassWord);
        }
        
        public string Login(string userName, string passWord, System.Drawing.Color color) {
            return base.Channel.Login(userName, passWord, color);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string userName, string passWord, System.Drawing.Color color) {
            return base.Channel.LoginAsync(userName, passWord, color);
        }
        
        public string GetColorPlayer(System.Drawing.Color color) {
            return base.Channel.GetColorPlayer(color);
        }
        
        public System.Threading.Tasks.Task<string> GetColorPlayerAsync(System.Drawing.Color color) {
            return base.Channel.GetColorPlayerAsync(color);
        }
        
        public string GetPlayerName() {
            return base.Channel.GetPlayerName();
        }
        
        public System.Threading.Tasks.Task<string> GetPlayerNameAsync() {
            return base.Channel.GetPlayerNameAsync();
        }
    }
}
