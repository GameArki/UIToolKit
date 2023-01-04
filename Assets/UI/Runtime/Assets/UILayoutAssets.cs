using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UIRenderer {

    public class UILayoutAssets {

        Dictionary<int, GameObject> all;

        public UILayoutAssets() {
            this.all = new Dictionary<int, GameObject>();
        }

        public async Task LoadAll() {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = UIAssetsCollection.UI_LAYOUT;
            var list = await Addressables.LoadAssetsAsync<GameObject>(labelReference, null).Task;
            foreach (var go in list) {
                var panel = go.GetComponent<IUIPanel>();
                all.Add(panel.TypeID, go);
            }
        }

        public bool TryGet(int typeID, out GameObject go) {
            return all.TryGetValue(typeID, out go);
        }

    }
}