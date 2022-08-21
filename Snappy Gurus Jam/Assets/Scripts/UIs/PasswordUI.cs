using System;
using TMPro;
using UnityEngine;

namespace SB
{
    public class PasswordUI : MonoBehaviour
    {
        public bool IsPasswordTrue => _inputField.text.Equals(password);

        [SerializeField] private string password = "PASSWORD";
        [SerializeField] private GameCameraController[] _gameCameraController;
        [SerializeField] private NPCController _npcController; 
        [SerializeField] private TextMeshProUGUI finalText;
        private NPCController _npc;
        private string _inputText;  
        private TMP_InputField _inputField;
        
        
        private void Awake()
        {
            _npc = FindObjectOfType<NPCController>();
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Update()
        {
            
                if(InputManager.Enter) 
                {
                    if (IsPasswordTrue)
                    {
                        _inputField.enabled = false;
                        finalText.text = "Access Granted"; 
                        
                        foreach(var camera in _gameCameraController) 
                        {
                            camera.enabled = false;
                        }
                        _npc.enabled = false;
                    }
                    else
                    {
                        _inputField.enabled = false;
                        finalText.text = "Access Denied"; 
                        _npcController.CatchCondition(2);
                    }
                }
            
        }

        public void ReadInput(string value)
        {
            Debug.Log(value);
            _inputText = value;
        }
    }
}