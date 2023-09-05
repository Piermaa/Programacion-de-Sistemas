using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListener
{
    void OnEventDispach();
}


public class EventsManager
{
    /// <summary>
    /// LAZY SINGLETON
    /// </summary>
    public static EventsManager Instance
    {
        get
        {
            if (Instance==null)
                instance = new EventsManager();

            return instance;
        }
    }

    private static EventsManager instance;
}
