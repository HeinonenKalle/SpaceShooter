﻿using UnityEngine;
using UE = UnityEditor;
using SpaceShooter.WaypointSystem;

namespace SpaceShooter.Editor
{
    [UE.CustomEditor(typeof(Path))]
    public class PathInspector : UE.Editor
    {
        private const string _buttonText = "Add waypoint";

        private Path _target;

        private void OnEnable()
        {
            _target = target as Path;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button(_buttonText))
            {
                int waypointCount = _target.transform.childCount;
                string waypointName = string.Format("Waypoint{0}", (waypointCount + 1).ToString("D3"));
                GameObject waypoint = new GameObject(waypointName, typeof(Waypoint));
                waypoint.transform.SetParent(_target.transform, true);
                UE.Selection.activeGameObject = waypoint;
            }
        }
    }
}
