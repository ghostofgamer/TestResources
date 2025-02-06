using ItemsContent;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    [SerializeField] private ResourcesArea _resourcesArea;
    [SerializeField] private Transform _table;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform[] _targets;

    private Resource _resource;
    private NavMeshAgent _agent;
    private int _currentTargetIndex = -1;
    private bool _hasItem = false;
    private bool _isGoToItem = false;
    private bool isActive = false;
    private bool isReturning = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_table.position);
    }

    private void Update()
    {
        if (isActive)
        {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                if (!_hasItem && !isReturning)
                {
                    PickUpItem();
                    _agent.SetDestination(_targets[_currentTargetIndex].position);
                }
                else if (!isReturning)
                {
                    DropItem();
                }
                else if (isReturning && _agent.remainingDistance < 0.5f)
                {
                    isActive = false;
                    isReturning = false;
                }
            }
        }
    }


    public void Init(int indexTarget)
    {
        gameObject.SetActive(true);
        _currentTargetIndex = indexTarget;
        _agent.SetDestination(_table.position);
        isActive = true;
        isReturning = false;
        _hasItem = false;
    }

    private void PickUpItem()
    {
        _resource = _resourcesArea.TakeItem();
        _resource.transform.parent = transform;
        _resource.transform.localPosition = new Vector3(0, 3, 1);
        _hasItem = true;
    }

    private void DropItem()
    {
        _resource.transform.parent = null;
        _resource.transform.position = _targets[0].position;
        _hasItem = false;
        GoToDefaultPosition();
    }

    private void GoToDefaultPosition()
    {
        _agent.SetDestination(_startPosition.position);
        isReturning = true;
    }
}