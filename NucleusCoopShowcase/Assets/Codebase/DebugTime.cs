using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NucleusShowcase {
    public class DebugTime : MonoBehaviour {
        private GUIStyle guiStyle;

        public void OnGUI() {
            if (guiStyle == null) {
                guiStyle = new GUIStyle();
                guiStyle.fontSize = 32;
            }

            GUI.Label(new Rect(20, 20, 100, 100), Time.time.ToString(), guiStyle);
        }
    }
}
