using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace MemoryMatch.Scripts
{
    public class FieldAnimator : AdvancedMonoBehaviour
    {
        private bool _isPlaying;
        private Action _fireOnComplete;
        private Coroutine _coroutine;
        
        public void TryPlay(List<Element> elements, Action callback)
        {
            if (_isPlaying)
            {
                return;
            }
            
            _isPlaying = true;
            
            _fireOnComplete = null;
            _fireOnComplete = () => callback?.Invoke();
            Play(elements);
            //_coroutine = StartCoroutine(Play(elements));
        }

        public void Play(List<Element> elements)
        {
            Debug.Log("Play Animation ------------------");
            //_elements = elements;
            //SubscribeToAnimationPlayed();
            
            foreach (var element in elements)
            {
                element.SwapAnim.Play();
            }
            
            _isPlaying = false;
            _fireOnComplete?.Invoke();
        }

        /*public IEnumerator Play(List<GameCores.MemoryMatchGame.Element> elements)
        {
            Debug.Log("Play Animation ------------------");
            //_elements = elements;
            //SubscribeToAnimationPlayed();
            
            foreach (var element in elements)
            {
                element.SwapAnim.Play();
            }

            yield return new WaitForSeconds(1);
            
            _isPlaying = false;
            _fireOnComplete?.Invoke();
        }*/

        /*private void SubscribeToAnimationPlayed()
        {
            foreach (var element in _elements)
            {
                element.SwapAnim.Played += OnAnimationPlayed;
            }
        }*/
        
        /*private void UnSubscribeFromAnimationPlayed()
        {
            foreach (var element in _elements)
            {
                element.SwapAnim.Played -= OnAnimationPlayed;
            }
        }*/

        /*private void OnAnimationPlayed()
        {
            _counter++;

            if (_counter == _elements.Count)
            {
                Debug.Log("End Animation ------------------");
                //UnSubscribeFromAnimationPlayed();
                
                _isPlaying = false;
                _counter = 0;
                _elements = null;
                
                _fireOnComplete?.Invoke();
            }
        }*/
    }
}