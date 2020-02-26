using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace NucleusShowcase {
    [CustomEditor(typeof(TextAnim)), CanEditMultipleObjects]
    public class TextAnimEditor : Editor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            if (this.targets != null && this.targets.Length <= 1) {
                TextAnim textAnim = (TextAnim)target;

                if (GUILayout.Button("Reload Anim")) {
                    textAnim.ReLoad();
                }
            }
        }
    }
}
