using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace SB
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private GameCameraController[] _gameCamera;
        private PlayerCharacterController _player;
        private NavMeshAgent _navMesh;
        
        private IDecision _decisions;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerCharacterController>();
            _navMesh = GetComponent<NavMeshAgent>();
            _decisions = new NPCDecisionStates(_navMesh, _player);
        }

        private void Update()
        {
            if (GetCameraDetected() == true)
            {
                CatchCondition(0);   
            }
        }

        public void CatchCondition(int catchIndex)
        {
            Debug.Log("DETEXTEDDDDDDD");
            _decisions.PlayerCatchConditions[catchIndex].Invoke();
        }

        private bool GetCameraDetected() 
        {
            foreach(var camera in _gameCamera)
            {
                if(camera.Detected == true) return true;
            }

            return false;
        }
    }
}