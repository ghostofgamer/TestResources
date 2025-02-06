using System;
using Enums;
using UnityEngine;

namespace FactoryContent
{
    public class StorageFactory : MonoBehaviour
    {
        public int StoneValue { get; private set; }

        public int MetalValue { get; private set; }

        public int WoodValue { get; private set; }

        public event Action ResourceValueChanged;

        public void AddResource(ResourceType resource)
        {
            ChangeResource(resource, 1);
        }

        public void DecreaseResources(ResourceType resource)
        {
            ChangeResource(resource, -1);
        }

        public int GetValue(ResourceType resource)
        {
            switch (resource)
            {
                case ResourceType.Stone:
                    return StoneValue;

                case ResourceType.Metal:
                    return MetalValue;

                case ResourceType.Wood:
                    return WoodValue;

                default:
                    return 0;
            }
        }

        private void ChangeResource(ResourceType resource, int amount)
        {
            switch (resource)
            {
                case ResourceType.Stone:
                    StoneValue += amount;
                    break;
                case ResourceType.Metal:
                    MetalValue += amount;
                    break;
                case ResourceType.Wood:
                    WoodValue += amount;
                    break;
                default:
                    Debug.Log("Unknown resource type");
                    break;
            }

            ResourceValueChanged?.Invoke();
        }
    }
}