using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIRenderer {

    // 登录页
    public class LoginPage : MonoBehaviour, IUIPanel {

        int IUIPanel.ID => 0;
        int IUIPanel.TypeID => UITypeID.LOGIN_PAGE;
        short IUIPanel.Weight => 0;
        sbyte IUIPanel.Root => UIRootType.PAGE;
        bool IUIPanel.IsUnique => true;

        Button startGameButton;

        // 给外部提供的回调
        public event Action OnStartGameHandle;

        public void Ctor() {

            startGameButton = transform.Find("btn_startgame").GetComponent<Button>();
            startGameButton.onClick.AddListener(() => {
                OnStartGameHandle?.Invoke();
            });

        }

        void IUIPanel.Close() {
            Destroy(gameObject);
            OnStartGameHandle = null;
        }

    }

}