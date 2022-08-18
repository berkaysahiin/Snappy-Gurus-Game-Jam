using System;
using Interfaces;
using JetBrains.Annotations;
using SB;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Transform orientation;
    [SerializeField] private float range;
    [SerializeField] private float speed;

    private bool isCurrentlyHolding;
    [CanBeNull] private GameObject selectableObject => GetSelectableObject();
    
    private RaycastHit hit;
    
    private void Update()
    {
        if (InputManager.InteractButton)
        {
            CarryObject();
        }
        else
        {
            ReleaseObject();
        }
    }


    [CanBeNull]
    private GameObject GetSelectableObject()
    {
        if (isCurrentlyHolding == false)
        {
            var ray = mainCamera.ScreenPointToRay(InputManager.MousePosition);
            Physics.Raycast(ray,out hit);
        }

        if (hit.collider != null && hit.transform.gameObject.GetComponent<Pickable>() != null)
        {
            return hit.transform.gameObject;
        }
        
        return null;
    }
    
    private void CarryObject()
    {
        isCurrentlyHolding = true;
        if (selectableObject != null && (transform.position - selectableObject.transform.position).magnitude < range)
        {
            selectableObject.transform.position = holdPosition.position;
            selectableObject.transform.rotation = Quaternion.Slerp(selectableObject.transform.rotation, orientation.rotation, speed* Time.smoothDeltaTime);
        }
            
    }
    private void ReleaseObject()
    {
        isCurrentlyHolding = false;
    }
}
