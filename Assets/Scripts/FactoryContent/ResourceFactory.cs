using Enums;
using Interfaces;
using UnityEngine;

namespace FactoryContent
{
    public class ResourceFactory : IResourceFactory
    {
        public GameObject CreateResource(Resource resource)
        {
            Debug.Log($"Produced: {resource.GetComponent<Resource>().name}");
          return Object.Instantiate(resource.gameObject, Vector3.zero, Quaternion.identity);
        }
    }
}