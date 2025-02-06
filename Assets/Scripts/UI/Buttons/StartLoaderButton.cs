using UnityEngine;

namespace UI.Buttons
{
    public class StartLoaderButton : AbstractButton
    {
        [SerializeField] private int _index;
        [SerializeField] private AgentController _agentController;
        [SerializeField]private ResourcesArea _resourcesArea;
    
        protected override void OnButtonClicked()
        {
            if (!_resourcesArea.IsBusy) return;
        
            _agentController.Init(_index);
        }
    }
}
