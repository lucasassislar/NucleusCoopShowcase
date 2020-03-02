using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace NucleusShowcase {
    [ExecuteInEditMode]
    public class TextAnim : MonoBehaviour {
        public bool bAnimateInEditor;
        public float fAnimationTime = 5;
        public string strText;

        private TextMeshProUGUI objTextMesh;
        private float fTimer;
        private float fTimePerChar;
        private int nCurrentChar;
        private int nCharsPerFrame;

        public void ReLoad() {
            objTextMesh = GetComponent<TextMeshProUGUI>();

            nCurrentChar = 0;
            fTimer = 0;

            if (string.IsNullOrEmpty(strText)) {
                strText = objTextMesh.text;
            }
            objTextMesh.text = "";

            fTimePerChar = fAnimationTime / strText.Length;
            nCharsPerFrame = Mathf.Max(1, (int)((1 / 60.0f) / fTimePerChar));
        }

        public void ChangeText(string strNewText) {
            this.enabled = true;

            strText = strNewText;
            ReLoad();
        }

        private void Start() {
            ReLoad();
        }

        private void Update() {
#if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlaying &&
                !bAnimateInEditor) {
                objTextMesh.text = strText;
                return;
            }
#endif
            if (!objTextMesh.enabled ||
                string.IsNullOrEmpty(strText)) {
                return;
            }

            fTimer += Time.deltaTime;

            if (fTimer > fTimePerChar) {
                fTimer = 0;

                for (int i = 0; i < nCharsPerFrame; i++) {
                    char charLoaded = strText[nCurrentChar];
                    objTextMesh.text += charLoaded;
                    if (charLoaded == ' ') {
                        nCurrentChar++;
                        if (nCurrentChar < strText.Length) {
                            objTextMesh.text += strText[nCurrentChar];
                        }
                    }
                    nCurrentChar++;

                    if (nCurrentChar >= strText.Length) {
#if UNITY_EDITOR
                        if (!UnityEditor.EditorApplication.isPlaying) {
                            objTextMesh.text = "";
                            fTimer = 0;
                            nCurrentChar = 0;
                            return;
                        }
#endif
                        this.enabled = false;
                        return;
                    }
                }
            }
        }
    }
}