using UnityEngine;

namespace Core.Audio
{
     public abstract class AudioController : MonoBehaviour
     {
          private const string VolumePrefs = "Volume";
          protected abstract string ControllerName { get; }
     
          private float _volume;
     
          public float Volume
          {
               get => _volume;
               set
               {
                    _volume = value;
                    SaveVolume();
                    OnVolumeChanged();
               }
          }

          protected virtual void Awake()
          {
               LoadVolume();
          }

          private void SaveVolume()
          {
               Debug.Log($"{ControllerName} {nameof(SaveVolume)} Volume={_volume}");
               PlayerPrefs.SetFloat(ControllerName + VolumePrefs, _volume);
          }
     
          private void LoadVolume()
          {
               _volume = PlayerPrefs.GetFloat(ControllerName + VolumePrefs, 1f);
               Debug.Log($"{ControllerName} {nameof(LoadVolume)} Volume={_volume}");
          }

          protected virtual void OnVolumeChanged()
          {
          
          }
     }
}