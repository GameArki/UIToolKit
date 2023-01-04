using UnityEngine;

namespace UIRenderer {

    internal static class UIFactory {

        internal static bool Open<T>(UIContext ctx, int typeID, out T panel) where T : IUIPanel {

            var repo = ctx.Repo;
            var assets = ctx.Assets;
            bool has = assets.TryGet(typeID, out var go);
            if (!has) {
                Debug.LogWarning("Can't find ui prefab by typeID: " + typeID);
                panel = default;
                return false;
            }

            panel = (T)go.GetComponent<IUIPanel>();
            if (panel == null) {
                Debug.LogWarning("Can't find ui panel component by typeID: " + typeID);
                return false;
            }

            var root = ctx.GetRoot(panel.Root);
            panel = (T)GameObject.Instantiate(go, root).GetComponent<IUIPanel>();
            repo.AddUnique(panel);
            return true;
        }

        internal static void Close(UIContext ctx, IUIPanel panel) {
            if (panel == null) {
                return;
            }
            var repo = ctx.Repo;
            bool has = repo.RemoveUnique(panel.TypeID);
            if (has) {
                panel.Close();
            }
        }

    }

}