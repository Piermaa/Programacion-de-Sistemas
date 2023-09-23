using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListener
{
    string EventID { get; }
    void OnEventDispatch();
}

