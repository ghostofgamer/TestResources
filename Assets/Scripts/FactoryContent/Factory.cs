using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FactoryContent
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private Resource[] _resourcePrefabs;
        
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private IResourceFactory _resourceFactory;
        private bool _isWorking;
        
        private void Start()
        {
            _resourceFactory = new ResourceFactory();
            _waitForSeconds = new WaitForSeconds(_delay);
            StartWork();
        }

        private void StartWork()
        {
            if(_coroutine!=null)
                StopCoroutine(_coroutine);

            _isWorking = true;
            _coroutine = StartCoroutine(CraftResource());
        }

        private IEnumerator CraftResource()
        {
            while (_isWorking)
            {
                 yield return _waitForSeconds;
                 
                 int randomIndex = Random.Range(0, _resourcePrefabs.Length);
                 _resourceFactory.CreateResource(_resourcePrefabs[randomIndex]);
                 
                /*ResourceType randomResourceType = availableResources[Random.Range(0, availableResources.Length)];
                GameObject resource = resourceFactory.CreateResource(randomResourceType);
                Debug.Log($"Produced: {resource.GetComponent<Resource>().Name}");*/
            }
        }
    }
}