using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsKeys
{
    public const string PlayerDetection = "PlayerDetection";
}

public class EventsManager
{
    #region SingleTon

    public static EventsManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EventsManager();

            return instance;
        }
    }

    private static EventsManager instance;

    #endregion
   
    private Dictionary<string, List<IListener>> _simpleEvents = new();

    public void AddListener(string eventID, IListener p_listener)
    {
        if (_simpleEvents.TryGetValue(eventID, out var listeners) && !listeners.Contains(p_listener))
        {
            listeners.Add(p_listener);
        }
    }

    public void RemoveListener(string eventID, IListener p_listener)
    {
        if (_simpleEvents.TryGetValue(eventID, out var listeners) && listeners.Contains(p_listener))
        {
            listeners.Remove(p_listener);
        }
    }

    public void DispatchSimpleEvent(string eventID)
    {
        if (_simpleEvents.TryGetValue(eventID, out var listeners))
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventDispatch();
            }
        }
        else
        {
            Debug.LogWarning($"Key {eventID} not found on Dictionary");
        }
    }

    public void RegisterEvent(string eventID)
    {
        if (!_simpleEvents.ContainsKey(eventID))
        {
            _simpleEvents[eventID] = new List<IListener>();
        }
    }

    public void ClearEvents()
    {
        _simpleEvents = new();
    }
}
