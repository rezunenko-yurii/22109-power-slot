using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Core.CustomTimeline.Base
{
    public static class TimelineExtensions
    {
        private static readonly WaitForEndOfFrame _frameWait = new();

        public static void Reset(this PlayableDirector timeline)
        {
            timeline.time = 0;
            timeline.Evaluate();
        }
        
        public static IEnumerator Reverse(this PlayableDirector timeline)
        {
            DirectorUpdateMode defaultUpdateMode = timeline.timeUpdateMode;
            timeline.timeUpdateMode = DirectorUpdateMode.Manual;

            if (timeline.time.ApproxEquals(timeline.duration) || timeline.time.ApproxEquals(0))
            {
                timeline.time = timeline.duration;
            }
            
            timeline.Evaluate();

            yield return _frameWait;

            float dt = (float)timeline.duration;
            while (dt > 0)
            {
                dt -= Time.deltaTime;
                timeline.time = Mathf.Max(dt, 0);
                timeline.Evaluate();
                
                yield return _frameWait;
            }

            timeline.Reset();
            timeline.timeUpdateMode = defaultUpdateMode;
            timeline.Stop();
        }

        public static bool ApproxEquals(this double num, float other)
        {
            return Mathf.Approximately((float)num, other);
        }
        
        public static bool ApproxEquals(this double num, double other)
        {
            return Mathf.Approximately((float)num, (float)other);
        }
    }
}