using System;
using System.Collections;
using Enums;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FactoryContent
{
    public class Factory : MonoBehaviour, IResourceFactory
    {
        [SerializeField] private float _delay;
        [SerializeField] private ResourceType[] _resourceTypes;
        [SerializeField]private StorageFactory _storageFactory;

        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private bool _isWorking;
        private int _randomIndex;
        
        // public event Action ResourceCreated;
        
        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_delay);
            StartWork();
        }

        private void StartWork()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _isWorking = true;
            _coroutine = StartCoroutine(CraftResource());
        }

        private IEnumerator CraftResource()
        {
            while (_isWorking)
            {
                yield return _waitForSeconds;
                _randomIndex = Random.Range(0, _resourceTypes.Length);
                CreateResource(_resourceTypes[_randomIndex]);
            }
        }

        public void CreateResource(ResourceType resource)
        {
            _storageFactory.AddResource(resource);
            // ResourceCreated?.Invoke();
        }
        
        /*public void CreateResource(ResourceType resource)
        {
            switch (resource)
            {
                case ResourceType.Stone:
                  
                    break;
                case ResourceType.Metal:
                    
                    break;
                case ResourceType.Wood:
                    
                    break;
                default:
                    Debug.Log("Unknown resource type");
                    break;
            }
            
            ResourceCreated?.Invoke();
        }*/
    }
}