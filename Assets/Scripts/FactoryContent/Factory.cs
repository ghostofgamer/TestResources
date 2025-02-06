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
        
        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_delay);
            StartWork();
        }

        public void CreateResource(ResourceType resource)
        {
            _storageFactory.AddResource(resource);
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
    }
}