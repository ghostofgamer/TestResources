using Enums;
using UnityEngine;

namespace UI.Buttons
{
    public class ResourceCollectButton : AbstractButton
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField]private ResourcesGuardian resourcesGuardian;
        
        protected override void OnButtonClicked()
        {
            resourcesGuardian.ActivateResource(_resourceType);
        }
    }
}
