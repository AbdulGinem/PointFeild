using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

namespace BNG {
    public class ControllerOffsetHelper : MonoBehaviour {

        public ControllerHand ControllerHand = ControllerHand.Right;

        [Header("Shown for Debug :")]
        [Tooltip("The model of controller found")]
        [SerializeField]
        private string thisControllerModel;

        [SerializeField]
        private ControllerOffset thisOffset;

        public List<ControllerOffset> ControllerOffsets;

        void Start() {
            if(ControllerOffsets == null) {
                ControllerOffsets = new List<ControllerOffset>();
            }

            StartCoroutine(checkForController());
        }

        IEnumerator checkForController() {

            while(string.IsNullOrEmpty(thisControllerModel)) {

                thisControllerModel = InputBridge.Instance.GetControllerName();

                yield return new WaitForEndOfFrame();
            }

            OnControllerFound();
        }

        public virtual void OnControllerFound() {
            // Debug.Log("Controller found : " + thisControllerModel);

            DefineControllerOffsets();

            thisOffset = GetControllerOffset(thisControllerModel);

            if(thisOffset != null) {
                if(ControllerHand == ControllerHand.Left) {
                    transform.localPosition += thisOffset.LeftControllerPositionOffset;
                    transform.localEulerAngles += thisOffset.LeftControllerRotationOffset;
                }
                else if (ControllerHand == ControllerHand.Right) {
                    transform.localPosition += thisOffset.RightControllerPositionOffset;
                    transform.localEulerAngles += thisOffset.RightControlleRotationOffset;
                }
            }
        }

        public virtual ControllerOffset GetControllerOffset(string controllerName) {
            return ControllerOffsets.FirstOrDefault(x => thisControllerModel.StartsWith(x.ControllerName));
        }

        public virtual void DefineControllerOffsets() {
            ControllerOffsets = new List<ControllerOffset>();

            // Oculus Touch on Oculus SDK is at correct orientation
            // Example  : "Oculus Touch Controller - Right"
            ControllerOffsets.Add(new ControllerOffset() { 
                ControllerName = "Oculus Touch Controller",
            });

            // Oculus Touch OpenVR
            // Example :  "OpenVR Controller(Oculus Quest (Right Controller)) - Right"
            ControllerOffsets.Add(new ControllerOffset() {
                ControllerName = "OpenVR Controller(Oculus Quest", 
                LeftControllerPositionOffset = new Vector3(0.0075f, -0.005f, -0.0525f),
                RightControllerPositionOffset = new Vector3(-0.0075f, -0.005f, -0.0525f),
                LeftControllerRotationOffset = new Vector3(40.0f, 0.0f, 0.0f),
                RightControlleRotationOffset = new Vector3(40.0f, 0.0f, 0.0f)
            });

            // Valve Knuckles OpenVR
            // Example :  "OpenVR Controller(Knuckles Right) -Right"
            ControllerOffsets.Add(new ControllerOffset() {
                ControllerName = "OpenVR Controller(Knuckles",
                LeftControllerPositionOffset = new Vector3(0.0075f, -0.005f, -0.0525f),
                RightControllerPositionOffset = new Vector3(-0.0075f, -0.005f, -0.0525f),
                LeftControllerRotationOffset = new Vector3(40.0f, 0.0f, 0.0f),
                RightControlleRotationOffset = new Vector3(40.0f, 0.0f, 0.0f)
            });

            // Windows WMR - HP 1440 - VR 1000
            // Example : "OpenVR Controller(WindowsMR: 0x045E/0x065B/0/2) - Right"
            ControllerOffsets.Add(new ControllerOffset() {
                ControllerName = "OpenVR Controller(WindowsMR",
                //LeftControllerPositionOffset = new Vector3(0.0075f, -0.005f, -0.0525f),
                //RightControllerPositionOffset = new Vector3(-0.0075f, -0.005f, -0.0525f),
                //LeftControllerRotationOffset = new Vector3(40.0f, 0.0f, 0.0f),
                //RightControlleRotationOffset = new Vector3(40.0f, 0.0f, 0.0f)
            });
        }
    }

    public class ControllerOffset {
        public string ControllerName { get; set; }
        public Vector3 LeftControllerPositionOffset { get; set; }
        public Vector3 RightControllerPositionOffset { get; set; }
        public Vector3 LeftControllerRotationOffset { get; set; }
        public Vector3 RightControlleRotationOffset { get; set; }
    }
}

