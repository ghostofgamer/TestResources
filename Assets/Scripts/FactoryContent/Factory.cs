using System;
using System.Collections;
using Enums;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace FactoryContent
{
    public class Factory : MonoBehaviour, IResourceFactory
    {
        [SerializeField] private float _delay;

        // [SerializeField] private Resource[] _resourcePrefabs;
        [SerializeField] private ResourceType[] _resourceTypes;

        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private bool _isWorking;
        private int _randomIndex;
        public int StoneValue { get; private set; }
        public int MetalValue { get; private set; }
        public int WoodValue { get; private set; }

        public event Action ResourceCreated;

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
            switch (resource)
            {
                case ResourceType.Stone:
                    StoneValue++;
                    Debug.Log("Stone");
                    break;
                case ResourceType.Metal:
                    MetalValue++;
                    Debug.Log("Metal");
                    break;
                case ResourceType.Wood:
                    WoodValue++;
                    Debug.Log("Wood");
                    break;
                default:
                    Debug.Log("Unknown resource type");
                    break;
            }
            
            ResourceCreated?.Invoke();
        }

    }
}