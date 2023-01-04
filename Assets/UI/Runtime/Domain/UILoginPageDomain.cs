using System;

namespace UIRenderer {

    internal class UILoginPageDomain {

        UIContext ctx;

        internal UILoginPageDomain() { }

        internal void Inject(UIContext ctx) {
            this.ctx = ctx;
        }

        internal void Open() {
            bool has = UIFactory.Open<LoginPage>(ctx, UITypeID.LOGIN_PAGE, out var page);
            if (has) {
                page.Ctor();
            }
        }

        internal void Binding_StartGame(Action action) {
            bool has = ctx.Repo.TryGetUnique<LoginPage>(UITypeID.LOGIN_PAGE, out var page);
            if (has) {
                page.OnStartGameHandle += action;
            }
        }

        internal void Close() {
            bool has = ctx.Repo.TryGetUnique<LoginPage>(UITypeID.LOGIN_PAGE, out var page);
            if (has) {
                UIFactory.Close(ctx, page);
            }
        }

    }

}