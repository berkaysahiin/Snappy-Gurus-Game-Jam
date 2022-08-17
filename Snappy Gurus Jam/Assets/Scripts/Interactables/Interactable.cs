using UnityEngine;

namespace SB
{
    public class Interactable : MonoBehaviour
    {
        private InputManager _inputManager;

        private void Awake()
        {
            _inputManager = FindObjectOfType<InputManager>();
        }

        private void OnTriggerStay(Collider collider)
        {
            if (_inputManager.InteractButton)
                gameObject.SetActive(false);
        }
    }
}