using System.Collections.Generic;

namespace UIRenderer {

    internal class UIRepo {

        Dictionary<int, IUIPanel> unique;

        internal UIRepo() {
            unique = new Dictionary<int, IUIPanel>();
        }

        internal void AddUnique(IUIPanel panel) {
            int typeID = panel.TypeID;
            if (unique.ContainsKey(typeID)) {
                unique[typeID] = panel;
            } else {
                unique.Add(typeID, panel);
            }
        }

        internal bool TryGetUnique<T>(int typeID, out T panel) where T : IUIPanel {
            bool has = unique.TryGetValue(typeID, out var p);
            if (has) {
                panel = (T)p;
            } else {
                panel = default;
            }
            return has;
        }

        internal bool RemoveUnique(int typeID) {
            return unique.Remove(typeID);
        }

    }

}