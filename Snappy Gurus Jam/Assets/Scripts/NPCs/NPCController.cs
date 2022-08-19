using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace SB
{
    public class NPCController : MonoBehaviour
    {
        private PlayerCharacterController _player;
        private NavMeshAgent _navMesh;
        private GameCameraController _gameCamera;
        
        private IDecision _decisions;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
            _navMesh = GetComponent<NavMeshAgent>();
            _decisions = new NPCDecisionStates(_navMesh, _player);

            //just for test
            _gameCamera = FindObjectOfType<GameCameraController>();
        }

        private void Update()
        {
            if (_gameCamera.Detected)
            {
                _decisions.PlayerCatchConditions[0].Invoke();
            }
        }
    }
}