using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_currentWaypointIndex < _waypoints.Length)
        {
            Vector3 wayPos = _waypoints[_currentWaypointIndex].position;
            navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex++;
            }
        }
    }
}