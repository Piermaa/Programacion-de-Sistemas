using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Agent : MonoBehaviour, IAgent
{
    public bool IsCurrentAgent => _isCurrentAgent;
    public Transform[] Waypoints => waypoints;
    public int WaypointsIndex => _waypointsIndex;
    [SerializeField] private ActorStats _enemyStats;
    [SerializeField] private Transform[] waypoints;
    private int _waypointsIndex;
    private NavMeshAgent _agent;
    protected bool _isCurrentAgent=false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _enemyStats.MovementSpeed;
    }
    
    public void NextWaypoint()
    {
        if (_waypointsIndex + 1 < waypoints.Length)
        {
            _waypointsIndex++;
        }
        else
        {
            _waypointsIndex = 0;
        }
        _agent.SetDestination(waypoints[_waypointsIndex].position);
    }

    public bool CheckDistanceToWaypoint()
    {
        return Vector3.Distance(transform.position, waypoints[_waypointsIndex].position) < 1;
    }

    //todo que esto este en el controller
    public void CanMove(bool canMove)
    {
        _agent.speed = canMove ? _enemyStats.MovementSpeed : 0;
    }

    public void SetCurrentAgent(bool isCurrentAgent)
    {
        _isCurrentAgent = isCurrentAgent;
    }
}
