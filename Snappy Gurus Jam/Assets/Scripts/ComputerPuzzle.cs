using System;
using System.Collections;
using System.Collections.Generic;
using SB;
using UnityEngine;
using Cinemachine;

public class ComputerPuzzle : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera FPCamera;
   [SerializeField] private CinemachineVirtualCamera computerCamera; 

   private void Start()
   {
      computerCamera.gameObject.SetActive(false);
      FPCamera.gameObject.SetActive(true);
   }

   private void OnTriggerStay(Collider other)
   {
      if (!InputManager.InteractButton) return;
         EnterComputerPuzzleMode();
   }

   private void OnTriggerExit(Collider other)
   {
      ExitComputerPuzzleMode();
   }

   private void EnterComputerPuzzleMode()
   {
      FPCamera.gameObject.SetActive(false);
      computerCamera.gameObject.SetActive(true);
      Cursor.lockState = CursorLockMode.None;
   }

   private void ExitComputerPuzzleMode()
   {
      FPCamera.gameObject.SetActive(true);
      computerCamera.gameObject.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;
   }
}
