using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.WaypointSystem
{
    public class PathUser : MonoBehaviour, IPathUser
    {
        #region Unity fields
        [SerializeField] private Direction _direction;
        [SerializeField] private float _arriveDistance = 0.1f;
        #endregion

        private IMover _mover;
        private Path _path;
        private bool _isInitialized = false;
        private float _sqrArriveDistance;

        public Waypoint CurrentWaypoint { get; private set; }

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public void Init(IMover mover, Path path)
        {
            _sqrArriveDistance = _arriveDistance * _arriveDistance;
            _mover = mover;
            _path = path;

            if (_path != null)
            {
                CurrentWaypoint = _path.GetClosestWaypoint(Position);
                _isInitialized = true;
            }
        }

        private Waypoint GetWaypoint()
        {
            Waypoint result = null;

            if (CurrentWaypoint != null)
            {
                Vector3 toWaypointVector = CurrentWaypoint.Position - Position;
                float waypointVectorSqrMagnitude = toWaypointVector.sqrMagnitude;

                if (waypointVectorSqrMagnitude <= _sqrArriveDistance)
                {
                    result = _path.GetNextWaypoint(CurrentWaypoint, ref _direction);
                }
                else
                {
                    result = CurrentWaypoint;
                }
            }

            return result;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!_isInitialized)
            {
                return;
            }

            CurrentWaypoint = GetWaypoint();

            if (CurrentWaypoint != null)
            {
                Vector3 direction = CurrentWaypoint.Position - Position;
                _mover.MoveToDirection(direction);
                _mover.RotateTowardPosition(CurrentWaypoint.Position);
            }
        }
    }
}
