using System;
using Core;
using NSTools.Core;
using SlotsGame.Scripts.ChipsLib;
using UnityEngine;

namespace SlotsGame.Scripts.Animation
{
    public class ChipsSwapAnim : BaseSimpleAnimation
    {
        [SerializeField] private Chip chip;
        private EZ.EZQueue ez;

        public override event Action Played;

        [ContextMenu("Play Anim")]
        public override void Play()
        {
            ez = EZ.Spawn();
            ez.Loop()
                .Call(() =>
                {
                    if (chip._changer.Amount == 0)
                    {
                        ez.Unloop();
                        ez.Kill();
                        Played?.Invoke();
                    }
                    else
                    {
                        chip.SetNext();
                    }
                })
                .Delay(0.05f);
        }
        
        public override void Stop()
        {
            Played = null;
        }

        private void OnDestroy()
        {
            Stop();
        }
    }
}