using System;
using Interfaces;
using JetBrains.Annotations;
using SB;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Transform orientation;
    [SerializeField] private float speed;
    [SerializeField] private CinemachineVirtualCamera FPCamera;

    private Pickable _pickable;

    private GameObject selectableObject => GetSelectableObject();
    private bool isCurrentlyHolding;
    private RaycastHit hit;
    private Vector3 initialHoldPosition;

    private void Start()
    {
        initialHoldPosition = holdPosition.position;
    }
    
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
        
        Debug.Log(selectableObject);
        
        if (_pickable != null && _pickable.IsBeingHold)
        {
            AudioManager.Instance.PlayEffect(1);
        }
        
       // CalculateHoldPositionYCoordinate();
    }

    [CanBeNull]
    private GameObject GetSelectableObject()
    {
        if (isCurrentlyHolding == false)
        {
            var ray = mainCamera.ScreenPointToRay(InputManager.MousePosition);
            Physics.Raycast(ray,out hit);
        }


        if (hit.collider != null && hit.transform.gameObject.GetComponent<Pickable>())
        {
            _pickable = hit.transform.gameObject.GetComponent<Pickable>();
            if(_pickable.enabled)
                return hit.transform.gameObject;
        }
        
        return null;
    }
    
    private void CarryObject()
    {
        isCurrentlyHolding = true;
        
        if (selectableObject != null && CheckSelectableObjectInRange())
        {

            _pickable = selectableObject.gameObject.GetComponent<Pickable>();
            _pickable.IsBeingHold = true;

            selectableObject.transform.position = holdPosition.position;
            selectableObject.transform.rotation = Quaternion.Slerp(selectableObject.transform.rotation, orientation.rotation, speed* Time.smoothDeltaTime);

            if(_pickable.ItemType == ItemType.Paper)
            {
                selectableObject.transform.LookAt(transform);
            }
        }
            
    }
    private void ReleaseObject()
    {
        if(selectableObject != null)
            selectableObject.gameObject.GetComponent<Pickable>().IsBeingHold = false;
        isCurrentlyHolding = false;
    }

    private bool CheckSelectableObjectInRange()
    {
        return (transform.position - selectableObject.transform.position).magnitude < selectableObject.GetComponent<Pickable>().AllowDistance;
    }

    private void CalculateHoldPositionYCoordinate() 
    {
        var cameraTransform = FPCamera.transform;
        var distance = Vector3.Distance(holdPosition.position,FPCamera.transform.position);
        var degree = -1 * cameraTransform.rotation.eulerAngles.x;
        var radian =  degree * Mathf.Deg2Rad;
        var tanValue = Mathf.Tan(radian);
        var moveValue = distance * tanValue;
        var targetY = initialHoldPosition.y + moveValue;

        if(targetY > 0.5)
        {
            targetY = 0.5f;
        }
        if(targetY < -2f) 
        {
            targetY = -2f;
        }

        Vector3 targetPosition = new Vector3(holdPosition.position.x, targetY, holdPosition.position.z);
        holdPosition.position = targetPosition;
    }
}
