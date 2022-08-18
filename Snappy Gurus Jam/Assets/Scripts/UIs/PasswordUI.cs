using TMPro;
using UnityEngine;

namespace SB
{
    public class PasswordUI : MonoBehaviour
    {
        [SerializeField] private string password = "PASSWORD";
        
        private string _inputText;  
        private TMP_InputField _inputField;

        public bool IsPasswordTrue => _inputField.text.Equals(password);
        
        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Update()
        {
            if(IsPasswordTrue) Debug.Log("TRUE");
        }

        public void ReadInput(string value)
        {
            Debug.Log(value);
            _inputText = value;
        }
    }
}