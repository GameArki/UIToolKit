using System.Collections.Generic;
using UnityEngine;

namespace UIRenderer {

    internal class UIContext {

        Dictionary<sbyte, Transform> rootDic;
        public Transform GetRoot(sbyte type) => rootDic[type];

        UILayoutAssets assets;
        internal UILayoutAssets Assets => assets;

        UIRepo repo;
        internal UIRepo Repo => repo;

        internal UIContext() {
            this.rootDic = new Dictionary<sbyte, Transform>();
            this.assets = new UILayoutAssets();
            this.repo = new UIRepo();
        }

        internal void Inject(Canvas canvas) {

            var bgRoot = GetOrCreateRoot(canvas, "BG_ROOT");
            rootDic.Add(UIRootType.BG, bgRoot);

            var worldTipsRoot = GetOrCreateRoot(canvas, "WORLD_TIPS_ROOT");
            rootDic.Add(UIRootType.WORLD_TIPS, worldTipsRoot);

            var pageRoot = GetOrCreateRoot(canvas, "PAGE_ROOT");
            rootDic.Add(UIRootType.PAGE, pageRoot);

            var windowRoot = GetOrCreateRoot(canvas, "WINDOW_ROOT");
            rootDic.Add(UIRootType.WINDOW, windowRoot);

            var uiTipsRoot = GetOrCreateRoot(canvas, "UI_TIPS_ROOT");
            rootDic.Add(UIRootType.UI_TIPS, uiTipsRoot);

        }

        Transform GetOrCreateRoot(Canvas canvas, string rootName) {
            var rootTrans = canvas.transform.Find(rootName);
            if (rootTrans == null) {

                var go = new GameObject(rootName);

                var rt =  go.AddComponent<RectTransform>();
                rt.SetParent(canvas.transform);
                rt.localPosition = Vector3.zero;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;

                go.AddComponent<CanvasRenderer>();

                rootTrans = rt;
                
            }
            return rootTrans;
        }

    }

}