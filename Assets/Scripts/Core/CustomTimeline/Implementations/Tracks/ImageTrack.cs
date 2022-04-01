using Core.CustomTimeline.Implementations.Clips;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace Core.CustomTimeline.Implementations.Tracks
{
    [TrackBindingType(typeof(Image))]
    [TrackClipType(typeof(ImageColorClip))]
    public class ImageTrack : TrackAsset
    {
    }
}