using Core.CustomTimeline.Implementations.Clips;
using TMPro;
using UnityEngine.Timeline;

namespace Core.CustomTimeline.Implementations.Tracks
{
    [TrackBindingType(typeof(TextMeshProUGUI))]
    [TrackClipType(typeof(AlphaTextClip))]
    public class TextTrack : TrackAsset { }
}