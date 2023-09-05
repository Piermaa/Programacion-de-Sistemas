using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Agent : MonoBehaviour, IAgent
{
    public Transform[] Waypoints => waypoints;
    public int WaypointsIndex => _waypointsIndex;

    [SerializeField] private Transform[] waypoints;
    private int _waypointsIndex;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
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
}
