using System.Threading.Tasks;
using UnityEngine;

namespace UIRenderer {

    public class UICore {

        UIContext ctx;
        UIDomain domain;

        UISetterAPI setter;
        public IUISetterAPI Setter => setter;

        UIGetterAPI getter;
        public IUIGetterAPI Getter => getter;

        public UICore() {

            this.ctx = new UIContext();
            this.domain = new UIDomain();

            this.setter = new UISetterAPI();
            this.getter = new UIGetterAPI();

            domain.Inject(ctx);

            setter.Inject(ctx, domain);
            getter.Inject(ctx, domain);

        }

        public void Inject(Canvas canvas) {
            ctx.Inject(canvas);
        }

        public async Task Init() {
            await ctx.Assets.LoadAll();
        }

    }

}