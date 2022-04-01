using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Core.CustomTimeline.Base
{
    public class GenericClip<T> : PlayableAsset, ITimelineClipAsset where T : class, IPlayableBehaviour, new()
    {
        [SerializeField] private T template;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<T>.Create(graph, template);
        }

        public ClipCaps clipCaps => ClipCaps.None;
    }
}