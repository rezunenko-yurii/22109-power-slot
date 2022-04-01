using Core.CustomTimeline.Implementations.Clips;
using UnityEngine;
using UnityEngine.Timeline;

namespace Core.CustomTimeline.Implementations.Tracks
{
    [TrackBindingType(typeof(Transform))]
    [TrackClipType(typeof(TransformTranslateClip))] [TrackClipType(typeof(TransformScaleClip))] [TrackClipType(typeof(TransformRotateClip))]
    public class TransformTrack : TrackAsset { }
}
