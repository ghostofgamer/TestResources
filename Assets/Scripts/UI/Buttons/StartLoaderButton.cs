using UI.Buttons;
using UnityEngine;

public class StartLoaderButton : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private AgentController _agentController;
    
    protected override void OnButtonClicked()
    {
        _agentController.Init(_index);
    }
}
