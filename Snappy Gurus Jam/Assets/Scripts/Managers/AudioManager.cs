using System.Collections.Generic;
using System.Linq;
using MB.Abstracts;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

namespace SB
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        [SerializeField] private AudioScriptableObject audioSo;
        private AudioSource _audioSource;
        
        private void Awake()
        {
            ApplySingleton(this);

            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayEffect(int effectIndex)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = audioSo.clips[effectIndex];
                _audioSource.Play();                
            }
        }
    }
}