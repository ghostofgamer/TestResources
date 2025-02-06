using System;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

namespace FactoryContent
{
    public class StorageFactory : MonoBehaviour
    {
        public int StoneValue { get; private set; }

        public int MetalValue { get; private set; }

        public int WoodValue { get; private set; }

        public event Action ResourceAdded;

        public void AddResource(ResourceType resource)
        {
            switch (resource)
            {
                case ResourceType.Stone:
                    StoneValue++;
                    break;
                case ResourceType.Metal:
                    MetalValue++;
                    break;
                case ResourceType.Wood:
                    WoodValue++;
                    break;
                default:
                    Debug.Log("Unknown resource type");
                    break;
            }

            ResourceAdded?.Invoke();
        }

        public int GetValue(ResourceType resource)
        {
            switch (resource)
            {
                case ResourceType.Stone:
                    return StoneValue;
                    break;
                case ResourceType.Metal:
                    return MetalValue;
                    break;
                case ResourceType.Wood:
                    return WoodValue;
                    break;
                default:
                    return 0;
                    break;
            }
        }
    }
}