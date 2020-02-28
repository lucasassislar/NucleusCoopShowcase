using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace NucleusShowcase {
    public class VideoScrubber : MonoBehaviour{
        private VideoPlayer videoPlayer;

        private void Start() {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        public void ScrubTime(float fDuration) {
            videoPlayer.frame = (long)(fDuration * videoPlayer.frameRate);
        }
    }
}
