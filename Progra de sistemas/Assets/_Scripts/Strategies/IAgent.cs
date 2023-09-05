using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgent
{
    Transform[] Waypoints { get; }
    int WaypointsIndex { get; }
    void NextWaypoint();
    bool CheckDistanceToWaypoint();
}
