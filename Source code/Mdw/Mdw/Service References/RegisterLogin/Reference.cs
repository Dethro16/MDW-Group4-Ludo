﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mdw.RegisterLogin {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="ludoService", ConfigurationName="RegisterLogin.IRegisterLogin")]
    public interface IRegisterLogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/IRegisterLogin/Register", ReplyAction="ludoService/IRegisterLogin/RegisterResponse")]
        string Register(string userName, string passWord, string confPWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/IRegisterLogin/Register", ReplyAction="ludoService/IRegisterLogin/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string userName, string passWord, string confPWord);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/IRegisterLogin/Login", ReplyAction="ludoService/IRegisterLogin/LoginResponse")]
        string Login(string userName, string passWord, System.Drawing.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="ludoService/IRegisterLogin/Login", ReplyAction="ludoService/IRegisterLogin/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string userName, string passWord, System.Drawing.Color color);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegisterLoginChannel : Mdw.RegisterLogin.IRegisterLogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegisterLoginClient : System.ServiceModel.ClientBase<Mdw.RegisterLogin.IRegisterLogin>, Mdw.RegisterLogin.IRegisterLogin {
        
        public RegisterLoginClient() {
        }
        
        public RegisterLoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegisterLoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegisterLoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegisterLoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Register(string userName, string passWord, string confPWord) {
            return base.Channel.Register(userName, passWord, confPWord);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string userName, string passWord, string confPWord) {
            return base.Channel.RegisterAsync(userName, passWord, confPWord);
        }
        
        public string Login(string userName, string passWord, System.Drawing.Color color) {
            return base.Channel.Login(userName, passWord, color);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string userName, string passWord, System.Drawing.Color color) {
            return base.Channel.LoginAsync(userName, passWord, color);
        }
    }
}
