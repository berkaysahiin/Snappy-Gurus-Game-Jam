using System;
using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;

namespace SB
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject armTarget;
        [SerializeField] private float respawnTime = 3.0f;
        
        private PlayerMovementController _playerMovement;
        private IHealth _health;
        public PlayerMovementController PlayerMovement => _playerMovement;
        public GameObject ArmTarget => armTarget;
        public IHealth Health => _health;
        
        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
            _playerMovement = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            CheckIsDead();
        }

        private void CheckIsDead()
        {
            if (_health.IsDead)
                StartCoroutine(LoadScene());
        }
        
        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(respawnTime);
            GameManager.Instance.LoadSelfScene();
        }
    }
}