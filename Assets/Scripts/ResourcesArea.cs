using ItemsContent;
using UnityEngine;

public class ResourcesArea : MonoBehaviour
{
    [SerializeField]private Transform _spawnPoint;
    
    private Resource _resource;
    
    public bool IsBusy{get;private set;}

    public void PutItem(Resource resource)
    {
        _resource = resource;
        _resource.transform.position = _spawnPoint.position;
        IsBusy = true;
    }

    public Resource TakeItem()
    {
        IsBusy = false;
        Resource tempResource = _resource; 
        _resource = null; 
        return tempResource;
    }
}