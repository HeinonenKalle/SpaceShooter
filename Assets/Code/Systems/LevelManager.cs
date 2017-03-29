using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using System;
using SpaceShooter.Systems.States;
using SpaceShooter.Level;

namespace SpaceShooter.Systems
{
    public class LevelManager : SceneManager
    {
        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;

        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }
		public InputManager InputManager { get; private set; }

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
            EnemyUnits.Init();
			InputManager = GetComponentInChildren<InputManager> ();

            _enemySpawners = GetComponentsInChildren<EnemySpawner>();

            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Init(EnemyUnits);
            }

#if UNITY_EDITOR
            if (Global.Instance.CurrentGameData == null)
            {
                GameData loadData = new GameData()
                {
                    Level = 1,
                    PlayerDataList = new List<PlayerData>()
                {
                    new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player1,
                        Controller = PlayerData.ControlType.WASD,
                        UnitType = PlayerUnit.UnitType.Balanced,
                        Lives = 3
                    },
                    new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player2,
                        Controller = PlayerData.ControlType.Arrows,
                        UnitType = PlayerUnit.UnitType.Fast,
                        Lives = 3
                    }
                }
                };

                Global.Instance.CurrentGameData = loadData;
            }
#endif

            PlayerUnits.Init(Global.Instance.CurrentGameData.PlayerDataList.ToArray());

            _conditions = GetComponentsInChildren<ConditionBase>();

            foreach (var condition in _conditions)
            {
                condition.Init(this);
            }
        }

        internal void ConditionMet(ConditionBase condition)
        {
            bool areConditionsMet = true;

            foreach (var c in _conditions)
            {
                if (!c.IsConditionMet)
                {
                    areConditionsMet = false;
                    break;
                }
            }

            if (areConditionsMet)
            {
                (AssociatedState as GameState).LevelCompleted();
            }
        }
    }
}