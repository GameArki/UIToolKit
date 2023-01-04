namespace UIRenderer {

    internal class UIDomain {

        UILoginPageDomain loginPageDomain;
        internal UILoginPageDomain LoginPageDomain => loginPageDomain;

        internal UIDomain() {
            loginPageDomain = new UILoginPageDomain();
        }

        internal void Inject(UIContext ctx) {
            loginPageDomain.Inject(ctx);
        }

    }

}