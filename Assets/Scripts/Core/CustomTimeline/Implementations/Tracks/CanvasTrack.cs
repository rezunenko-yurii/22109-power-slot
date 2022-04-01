using Core.CustomTimeline.Implementations.Clips;
using UnityEngine;
using UnityEngine.Timeline;

namespace Core.CustomTimeline.Implementations.Tracks
{
    [TrackBindingType(typeof(CanvasGroup))]
    [TrackClipType(typeof(CanvasTransparencyClip))]
    public class CanvasTrack : TrackAsset { }
}