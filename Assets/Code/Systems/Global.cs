using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Utility;
using SpaceShooter.Data;
using SpaceShooter.SaveLoad;

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

        [SerializeField] private Prefabs _prefabs;
        [SerializeField] private Pools _pools;

        public Prefabs Prefabs { get { return _prefabs; } }
        public Pools Pools { get { return _pools; } }
        public GameManager GameManager { get; private set; }
        public GameData CurrentGameData { get; set; }
        public SaveManager SaveManager { get; private set; }

		public Vector3 PlayerOneSpawnPoint = new Vector3(-9f, 0f, -5f);
		public Vector3 PlayerTwoSpawnPoint = new Vector3(-3f, 0f, -5f);
		public Vector3 PlayerThreeSpawnPoint = new Vector3(3f, 0f, -5f);
		public Vector3 PlayerFourSpawnPoint = new Vector3(9f, 0f, -5f);

        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            if (_instance == this)
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
            DontDestroyOnLoad(gameObject);

            Localization.LoadLanguage(SaveManager.Language);

            //Initialize
            if (_prefabs == null)
            {
                _prefabs = GetComponentInChildren<Prefabs>();
            }

            if (_pools == null)
            {
                _pools = GetComponentInChildren<Pools>();
            }

            //SaveManager = new SaveManager(new BinaryFormatterSaveLoad<GameData>());
            SaveManager = new SaveManager(new JsonSaveLoad<GameData>());


            GameManager = gameObject.GetOrAddComponent<GameManager>();
            GameManager.Init();
        }
    }
}