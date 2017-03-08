using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.WaypointSystem
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private PathType _pathType;

        private readonly Dictionary<PathType, Color> _pathColors =
            new Dictionary<PathType, Color>
            {
                {PathType.Loop, Color.green },
                {PathType.PingPong, Color.red },
                {PathType.OneWay, Color.blue }
            };

        private List<Waypoint> _waypoints;

        public List<Waypoint> Waypoints
        {
            get
            {
                if (_waypoints == null || _waypoints.Count == 0 || !Application.isPlaying)
                {
                    _waypoints = GetComponentsInChildren<Waypoint>().ToList();
                }

                return _waypoints;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _pathColors[_pathType];

            if(Waypoints.Count > 1)
            {
                for(int i = 1; i < Waypoints.Count; ++i)
                {
                    Gizmos.DrawLine(Waypoints[i - 1].Position, Waypoints[i].Position);
                }

                if (_pathType == PathType.Loop)
                {
                    Gizmos.DrawLine(Waypoints[Waypoints.Count - 1].Position, Waypoints[0].Position);
                }
            }
        }
    }
}
