
using System;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    private IAgent[] _agents;
    private IAgent _currentAgent;
    
    private void Awake()
    {
        _agents = GetComponents<Agent>();
        print(_agents.Length);
        _currentAgent = _agents[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetAgent(1);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetAgent(0);
        }
    }

    private void FixedUpdate()
    {
        if (_currentAgent.CheckDistanceToWaypoint())
        {
            _currentAgent.NextWaypoint();
            print("arrived");
        }
    }

    private void SetAgent(int index)
    {
        _currentAgent=_agents[index];
        _currentAgent.NextWaypoint();
    }
}
