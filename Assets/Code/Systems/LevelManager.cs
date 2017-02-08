using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Systems
{
    public class LevelManager : SceneManager
    {
        [SerializeField]
        private PlayerUnits _playerUnits;

        public PlayerUnits PlayerUnits { get { return _playerUnits; } }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {

        }
    }
}