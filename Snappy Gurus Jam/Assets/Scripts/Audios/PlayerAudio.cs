using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SB
{
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private Vector2 pitchVector;
        [SerializeField] private float runSoundTime = .4f;
        
        private PlayerMovementController _playerMovement;
        private AudioSource _audioSource;

        private int _randomFootstep;
        private float _currentTime;
        
        private void Awake()
        {
            _playerMovement = GetComponentInParent<PlayerMovementController>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            PlayFootStepSound();
            Timer();
        }

        private void PlayFootStepSound()
        {
            if (_playerMovement.CanMove && (InputManager.Move != Vector2.zero) && !_audioSource.isPlaying)
            {
                PrepareFootstepSound();
                _audioSource.Play();
            }    
            
            if (InputManager.Run && Math.Abs(_currentTime - runSoundTime) < 0.001f)
            {
                PrepareFootstepSound();
                _currentTime = 0;
            }
        }

        private void PrepareFootstepSound()
        {
            _randomFootstep = Random.Range(0, audioClips.Count);
            _audioSource.clip = audioClips[_randomFootstep];
            _audioSource.pitch = Random.Range(pitchVector.x, pitchVector.y);
            _audioSource.Play();
        }

        private void Timer()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= runSoundTime) _currentTime = runSoundTime;
        }
    }
}