using System.Collections.Generic;
using System.Linq;
using Enums;
using FactoryContent;
using ItemsContent;
using UnityEngine;

public class ResourcesGuardian : MonoBehaviour
{
    [SerializeField] private Resource[] _resources;
    [SerializeField] private int _initialPoolSize = 1;
    [SerializeField] private Transform _container;
    [SerializeField] private StorageFactory _storageFactory;
    [SerializeField] private ResourcesArea _resourcesArea;

    private Dictionary<ResourceType, ObjectPool<Resource>> _resourcePools;

    private void Start()
    {
        _resourcePools = new Dictionary<ResourceType, ObjectPool<Resource>>();

        foreach (var resource in _resources)
        {
            if (!_resourcePools.ContainsKey(resource.Type))
            {
                _resourcePools[resource.Type] = new ObjectPool<Resource>(resource, _initialPoolSize, _container);
                _resourcePools[resource.Type].EnableAutoExpand();
            }
        }
    }

    public void ActivateResource(ResourceType type)
    {
        if (FindQuantity(type) <= 0) return;
        if (_resourcesArea.IsBusy) return;

        if (_resourcePools.TryGetValue(type, out var pool))
        {
            if (pool.TryGetObject(out Resource resource, _resources.First(r => r.Type == type)))
            {
                _resourcesArea.PutItem(resource);
                resource.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Continue");
            }
        }
    }

    private int FindQuantity(ResourceType type)
    {
        return _storageFactory.GetValue(type);
    }
}