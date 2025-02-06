using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButton : MonoBehaviour
    {
        protected Button Button;

        private void Awake()
        {
            Button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClicked); 
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClicked); 
        }
        
        protected abstract void OnButtonClicked();
    }
}