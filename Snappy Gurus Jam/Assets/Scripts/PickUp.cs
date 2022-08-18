using System;
using SB;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private RaycastHit hit;
    private void Update()
    {
        var ray = mainCamera.ScreenPointToRay(InputManager.MousePosition);
        
        if (!Physics.Raycast(ray, out hit)) return;
        var selection = hit.transform;
        Debug.Log(selection);
    }
}