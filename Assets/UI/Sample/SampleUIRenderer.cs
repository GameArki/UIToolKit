using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIRenderer.Sample {

    public class SampleUIRenderer : MonoBehaviour {

        UICore core;

        // Start is called before the first frame update
        void Start() {

            core = new UICore();
            core.Inject(GetComponentInChildren<Canvas>());

            Action action = async () => {
                await core.Init();
                core.Setter.LoginPage_Open();
                core.Setter.LoginPage_Binding_StartGame(() => {
                    Debug.Log("Start Game");
                });
            };
            action.Invoke();

        }

        // Update is called once per frame
        void Update() {

        }

    }

}
