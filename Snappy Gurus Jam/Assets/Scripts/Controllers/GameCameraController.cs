using UnityEngine;

namespace SB
{
    public class GameCameraController : MonoBehaviour
    {
        [SerializeField] private float distance;
        [SerializeField] private float camLookRadius;
        [SerializeField] private float angleValue = 180;
        [SerializeField] private float additionalAngle = 90;
        [SerializeField] private float camRotateSpeed = 60;
        [SerializeField] private Vector2 xzRotVal;

        [SerializeField] private GameObject player;
        
        private Ray _ray;
        private RaycastHit _hit;
        private bool _detected = false;

        public bool Detected => _detected;

        private void Update()
        {
            CameraLook();
            var dist = Vector3.Distance(player.transform.position, _hit.point);

            if (dist < camLookRadius)
            {
                Debug.Log("IM IN!");
                _detected = true;
                transform.LookAt(player.transform);
                transform.localEulerAngles += new Vector3(-45, 180, 0);
            }
            else
            {
                Debug.Log("IM OUT!");
            }

            transform.localEulerAngles = new Vector3(xzRotVal.x, 
                Mathf.PingPong(Time.time * camRotateSpeed, angleValue) + additionalAngle, xzRotVal.y);
        }

        private void CameraLook()
        {
            Debug.DrawLine(transform.position , transform.forward  * -distance, Color.red);
            
            if (Physics.Raycast(transform.position, transform.forward * -1, out _hit, distance))
            {
                // Debug.Log(_hit.collider.gameObject.name);
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_hit.point, camLookRadius);
        }
    }
}