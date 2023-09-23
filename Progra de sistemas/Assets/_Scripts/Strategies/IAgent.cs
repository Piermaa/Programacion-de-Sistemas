using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgent
{
    bool IsCurrentAgent { get; }
    Transform[] Waypoints { get; }
    int WaypointsIndex { get; }
    void NextWaypoint();
    bool CheckDistanceToWaypoint();
    void CanMove(bool canMove);
    void SetCurrentAgent(bool isCurrentAgent);
}
