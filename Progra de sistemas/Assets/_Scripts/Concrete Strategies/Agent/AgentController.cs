using System;
using System.Collections;
using UnityEngine;

public class AgentController : MonoBehaviour, IListener
{
    #region IListener Properties

    public string EventID => _eventID;
    [SerializeField] private string _eventID;

    #endregion

    #region Class Properties

    private IAgent[] _agents;
    private IAgent _currentAgent;
    private bool _canMove;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _agents = GetComponents<Agent>();
    }

    private void Start()
    {
        SetAgent(0);
        if (_eventID!=null)
        {
            EventsManager.Instance.AddListener(_eventID,this);
        }
    }

    private void Update()
    {
        //====DEBUGGING===================
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
        //Totry:
        //ESTO PODRIA ESTAR SOLO EN PATROL HACIENDO INNECESARIO CHECKEAR si es el agente current en chase
        if (_currentAgent.CheckDistanceToWaypoint())
        {
            _currentAgent.NextWaypoint();
        }
    }

    #endregion

    #region IListener Methods

    public void OnEventDispatch()
    {
        SetAgent(1);
        print("observed");
        EventsManager.Instance.RemoveListener(_eventID,this);
    }

    #endregion

    #region Class Methods

    public void SetAgent(int index)
    {   
        _currentAgent?.SetCurrentAgent(false);
        
        _currentAgent=_agents[index];
        _currentAgent.SetCurrentAgent(true);
        
        _currentAgent.NextWaypoint();
    }

    public void SetAgent(Agent newAgent)
    {
        _currentAgent?.SetCurrentAgent(false);
        
        _currentAgent= newAgent;
        _currentAgent.SetCurrentAgent(true);
        
        _currentAgent.NextWaypoint();
    }

    //totry: (se me ocurrio y me olvide)
    public void CanMove()
    {
        _currentAgent.CanMove(true);
    }

    public void CantMove()
    {
        _currentAgent.CanMove(false);
    }

    private IEnumerator StoppingTime(float time)
    {
        CantMove();
        yield return new WaitForSeconds(time);
        CanMove();
    }
    
    public void StopTime(float time)
    {
        StartCoroutine(StoppingTime(time));
    }

    #endregion
    
}
