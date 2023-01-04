using System;

namespace UIRenderer {

    internal class UISetterAPI : IUISetterAPI {

        UIContext ctx;
        UIDomain domain;

        internal UISetterAPI() { }

        internal void Inject(UIContext ctx, UIDomain domain) {
            this.ctx = ctx;
            this.domain = domain;
        }

        void IUISetterAPI.LoginPage_Open() {
            var loginDomain = domain.LoginPageDomain;
            loginDomain.Open();
        }

        void IUISetterAPI.LoginPage_Binding_StartGame(Action action) {
            var loginDomain = domain.LoginPageDomain;
            loginDomain.Binding_StartGame(action);
        }

        void IUISetterAPI.LoginPage_Close() {
            var loginDomain = domain.LoginPageDomain;
            loginDomain.Close();
        }
        
    }

}