namespace UIRenderer {

    internal class UIGetterAPI : IUIGetterAPI {

        UIContext ctx;
        UIDomain domain;

        internal UIGetterAPI() { }

        internal void Inject(UIContext ctx, UIDomain domain) {
            this.ctx = ctx;
            this.domain = domain;
        }

    }

}