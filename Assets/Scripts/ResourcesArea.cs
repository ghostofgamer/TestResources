using ItemsContent;
using UnityEngine;

public class ResourcesArea : MonoBehaviour
{
    [SerializeField]private Transform _spawnPoint;
    
    public bool IsBusy{get;private set;}

    public void PutItem(Resource resource)
    {
        resource.transform.position = _spawnPoint.position;
        IsBusy = true;
    }

    public void TakeItem()
    {
        IsBusy = false;
    }
}