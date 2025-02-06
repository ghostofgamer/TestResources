using System.Collections.Generic;
using System.Linq;
using Enums;
using ItemsContent;
using UnityEngine;

public class ResourcesGuardian : MonoBehaviour
{
    [SerializeField] private Resource[] _resources;
    [SerializeField] private int _initialPoolSize = 1;
    [SerializeField] private Transform _container;

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

    public void TryGetResource(ResourceType type)
    {
        Debug.Log("TEPEC " + type);

        if (_resourcePools.TryGetValue(type, out var pool))
        {
            if (pool.TryGetObject(out Resource resource, _resources.First(r => r.Type == type)))
                resource.gameObject.SetActive(true);
            else
                Debug.Log("Continue");
        }
    }

    /*
    public bool TryGetResource(ResourceType type)
    {
        if (_resourcePools.TryGetValue(type, out var pool))
        {
            return pool.TryGetObject(out Resource resource,_resources.First(r => r.Type == type));
        }


        return false;
    }*/


    /*private Dictionary<ResourceType, ObjectPool<Resource>> _resourcePools;

    private void Start()
    {
        _resourcePools = new Dictionary<ResourceType, ObjectPool<Resource>>();

        foreach (var resource in _resources)
        {
            var pool = new ObjectPool<Resource>(resource, _initialPoolSize, _container);
            pool.EnableAutoExpand();
            _resourcePools[resource.Type] = pool;
        }
    }

    public bool TryGetAndActivateResourceObject(ResourceType type)
    {
        if (_resourcePools.TryGetValue(type, out var pool))
        {
            if (pool.TryGetObject(out Resource resourceObject, _resources.First(r => r.Type == type)))
            {
                resourceObject.gameObject.SetActive(true);
                return true;
            }
        }

        return false;
    }*/
}