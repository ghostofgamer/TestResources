using System;
using Enums;
using UnityEngine;

namespace StorageTableContent
{
    public class StorageTable : MonoBehaviour
    {
        [SerializeField] private Transform _transformPoint;
        [SerializeField] private Transform _resourcePoint;
        [SerializeField]private ResourceType _resourceType;

        public event Action ValueChanged;
        
        public int ValueResource { get; private set; }
    
        public ResourceType ResourceType => _resourceType;
        
        public Transform TransformPoint => _transformPoint;
        
        public Transform ResourcePoint => _resourcePoint;

        public void AddResource()
        {
            ValueResource++;
            ValueChanged?.Invoke();
        }
    }
}