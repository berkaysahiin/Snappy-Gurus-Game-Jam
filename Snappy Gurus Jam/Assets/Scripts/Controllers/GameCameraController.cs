using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SB
{
    public class GameCameraController : MonoBehaviour
    {
        [SerializeField] private float distance;
        [SerializeField] private float camLookRadius;
        [SerializeField] private GameObject player;

        [SerializeField] private float camRotateSpeed;
        [SerializeField] private Vector3 rotateVector;
        
        [SerializeField] private Vector2 clampXValues;
        [SerializeField] private Vector2 clampYValues;
        [SerializeField] private Vector2 clampZValues;

        private bool _initialStart;
        
        private Ray _ray;
        private RaycastHit _hit;

        private void Start()
        {
            _initialStart = true;
        }

        private void Update()
        {
            CameraLook();
            // var dist = Vector3.Distance(player.transform.position, transform.position);
            //
            // Debug.Log("DIST: "+ dist);
            // if (dist < camLookRadius)
            // {
            //     Debug.Log("IM IN!");
            //     transform.LookAt(player.transform);
            //     transform.localEulerAngles += new Vector3(-45, 180, 0);
            // }
            // else
            // {
            //     Debug.Log("IM OUT!");
            // }
            
            if (_initialStart)
            {
                transform.Rotate(rotateVector * camRotateSpeed, Space.World);
            }

            if (transform.rotation.y > clampYValues.x)
            {
                transform.Rotate(rotateVector * camRotateSpeed * -1, Space.World);
                _initialStart = false;
            }
            
            if (transform.rotation.y < clampYValues.y)
            {
                transform.Rotate(rotateVector * camRotateSpeed, Space.World);
            }
        }

        private void CameraLook()
        {
            Debug.DrawLine(transform.position, transform.forward * -distance, Color.red);
            
            if (Physics.Raycast(transform.position, transform.forward * -1, out _hit, distance))
            {
                Debug.Log(_hit.collider.gameObject.name);
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_hit.point, camLookRadius);
        }
    }
}