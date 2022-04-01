using Core.CustomTimeline.Implementations.Clips;
using UnityEngine;
using UnityEngine.Timeline;

namespace Core.CustomTimeline.Implementations.Tracks
{
    [TrackBindingType(typeof(RectTransform))]
    [TrackClipType(typeof(RectTransformTranslateClip))] [TrackClipType(typeof(TransformScaleClip))] [TrackClipType(typeof(TransformRotateClip))] 
    public class RectTransformTrack : TrackAsset { }
}