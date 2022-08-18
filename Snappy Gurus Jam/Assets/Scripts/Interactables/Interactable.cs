using UnityEngine;

namespace SB
{
    public class Interactable : MonoBehaviour
    {
        private void OnTriggerStay(Collider _collider)
        {
            if (InputManager.InteractButton)
                gameObject.SetActive(false);
        }
    }
}