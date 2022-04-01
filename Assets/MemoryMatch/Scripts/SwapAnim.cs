using System;
using Core;
using DG.Tweening;
using UnityEngine;

namespace MemoryMatch.Scripts
{
    public class SwapAnim : BaseSimpleAnimation
    {
        [SerializeField] private Element _element;
        private Sequence _sequence;
        
        public override event Action Played;
        
        public override void Play()
        {
            Debug.Log($"Play Time {Time.realtimeSinceStartup}");

            ChangeState();
            Played?.Invoke();
            /*DOTween.Sequence()
                .Insert(0,ScaleElement(Vector2.up, 0.15f).OnComplete(ChangeState))
                .Insert(0.15f,ScaleElement(Vector2.one, 0.15f))
                .OnComplete(OnPlayed)
                .OnKill(OnKill)
                .Play();*/

        }

        /*private void OnKill()
        {
            Debug.Log($"Killing Time {Time.realtimeSinceStartup} ----------");
        }

        private TweenerCore<Vector3, Vector3, VectorOptions> ScaleElement(Vector2 vector2, float duration)
        {
            return _element.transform.DOScale(vector2, duration);
        }*/

        private void ChangeState()
        {
            Debug.Log($"ChangeState Time {Time.realtimeSinceStartup}");
            if (_element.IsMatched)
            {
                return;
            }
            else if (_element.IsShown)
            {
                _element.Hide();
            }
            else
            {
                _element.Show();
            }
        }

        public override void Stop()
        {
            /*_sequence.Complete();
            _sequence.Kill();

            Played = null;*/
        }
    }
}