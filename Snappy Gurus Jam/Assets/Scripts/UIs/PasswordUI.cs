using System;
using TMPro;
using UnityEngine;

namespace SB
{
    public class PasswordUI : MonoBehaviour
    {
        [SerializeField] private string password = "PASSWORD";
        
        private GameCameraController _gameCameraController;
        private NPCController _npc;
        
        private string _inputText;  
        private TMP_InputField _inputField;
        
        public bool IsPasswordTrue => _inputField.text.Equals(password);
        
        private void Awake()
        {
            _gameCameraController = FindObjectOfType<GameCameraController>();
            _npc = FindObjectOfType<NPCController>();
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Update()
        {
            if (IsPasswordTrue)
            {
                _gameCameraController.enabled = false;
                _npc.enabled = false;
            }
        }

        public void ReadInput(string value)
        {
            Debug.Log(value);
            _inputText = value;
        }
    }
}