using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Systems
{
    public class Global : MonoBehaviour
    {
        private static Global _instance;

        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject globalObj = new GameObject(typeof(Global).Name);
                    _instance = globalObj.AddComponent<Global>();
                }

                return _instance;
            }
        }

        [SerializeField] private List<Material> _trailMaterials;

        public List<Material> TrailMaterials { get { return _trailMaterials; } }

        [SerializeField]
        private Prefabs _prefabs;

        public Prefabs Prefabs { get { return _prefabs; } }

        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            if (_instance = this)
            {
                Init();
            }
            else
            {
                Destroy(this);
            }
        }

        private void Init()
        {
            //Initialize
            if (_prefabs == null)
            {
                _prefabs = GetComponentInChildren<Prefabs>();
            }
        }
    }
}