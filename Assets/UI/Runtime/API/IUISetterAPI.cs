using System;

namespace UIRenderer {

    public interface IUISetterAPI {

        void LoginPage_Open();
        void LoginPage_Binding_StartGame(Action action);
        void LoginPage_Close();

    }

}