using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Enemy[] _enemy;

    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private bool _enemyIsKill;
    private int _wayPointIndex;

    private void Start()
    {
        _navMeshAgent.SetDestination(_wayPoints[_wayPointIndex].transform.position);
    }

    private void Update()
    {
        MoveToWayPoint();

    }

    private void MoveToWayPoint()
    {
        
        if (_wayPointIndex < _wayPoints.Length)
        {
            if (_enemyIsKill == true)
            {
                _anim.SetBool("Running", true);
                _navMeshAgent.SetDestination(_wayPoints[_wayPointIndex + 1].transform.position);    
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WayPoint wayPoint))
        {
            _enemyIsKill = false;
            _anim.SetBool("Running", false);
            
            foreach (Enemy enemy in _enemy)
            {
                if (enemy.TryGetComponent<Enemy>(out Enemy enemy1))
                {
                    _enemyIsKill = true;
                }
                Debug.Log("Нашел");
            }
            if (_wayPointIndex < _wayPoints.Length - 1)
            {   
                _wayPointIndex += 1;
            }
            //_wayPoints[_wayPointIndex - 1].gameObject.SetActive(false);
            transform.LookAt(_wayPoints[_wayPointIndex + 1].transform.position);
        }
    }
}
