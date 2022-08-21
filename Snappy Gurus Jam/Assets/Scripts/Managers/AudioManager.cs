using System.Collections.Generic;
using System.Linq;
using MB.Abstracts;
using Unity.VisualScripting;
using UnityEngine;

namespace SB
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] private AudioScriptableObject audioSo;
        private AudioSource _audioSource;
        private List<EffectAudio> _effects;
        
        private void Awake()
        {
            ApplySingleton(this);

            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _effects = GetComponentsInChildren<EffectAudio>().ToList();

            foreach (var effectAudio in _effects)
            {
                if (effectAudio == null) continue;
                
                effectAudio.AddComponent<AudioSource>();
                effectAudio.GetComponent<AudioSource>().playOnAwake = false;
            }
        }

        public void PlayPanicEffect()
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = audioSo.clips[0];
                _audioSource.Play();                
            }
        }
    }
}