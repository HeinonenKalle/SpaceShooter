using System;
using UnityEngine;

namespace SpaceShooter.WaypointSystem
{
    public enum Direction
    {
        Forward,
        Backward
    }

    public enum PathType
    {
        Loop,
        PingPong,
        OneWay
    }

    interface IPathUser
    {
        Waypoint CurrentWaypoint { get; }
        Direction Direction { get; set; }
        Vector3 Position { get; set; }

        void Init(IMover mover, Path path);
    }
}
