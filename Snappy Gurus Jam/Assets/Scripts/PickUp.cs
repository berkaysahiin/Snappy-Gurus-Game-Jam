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
        
        print(selectableObject);
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
        if (selectableObject != null)
        {
            selectableObject.transform.position = holdPosition.position;
            selectableObject.transform.rotation = orientation.rotation;
        }
            
    }
    private void ReleaseObject()
    {
        isCurrentlyHolding = false;
    }
}
