using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using System;

namespace SpaceShooter.Systems
{
    public class LevelManager : SceneManager
    {
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        public override GameStateType StateType
        {
            get
            {
                return GameStateType.InGameState;
            }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();

            PlayerData playerData = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3
            };

            PlayerUnits.Init(playerData);
            EnemyUnits.Init();
        }
    }
}