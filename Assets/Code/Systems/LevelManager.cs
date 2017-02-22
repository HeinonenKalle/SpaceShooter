using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using System;
using SpaceShooter.Systems.States;

namespace SpaceShooter.Systems
{
    public class LevelManager : SceneManager
    {
        private ConditionBase[] _conditions;

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
			InputManager = GetComponentInChildren<InputManager> ();

            PlayerData playerData = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
				Controller = PlayerData.ControlType.WASD,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3
            };

			PlayerData playerDataTwo = new PlayerData()
            {
				Id = PlayerData.PlayerId.Player2,
				Controller = PlayerData.ControlType.Arrows,
				UnitType = PlayerUnit.UnitType.Fast,
				Lives = 3
			};

            PlayerData playerDataThree = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player3,
                Controller = PlayerData.ControlType.Gamepad1,
                UnitType = PlayerUnit.UnitType.Heavy,
                Lives = 3
            };

            PlayerData playerDataFour = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player4,
                Controller = PlayerData.ControlType.Gamepad2,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3
            };

			PlayerUnits.Init(playerData, playerDataTwo, playerDataThree, playerDataFour);
            EnemyUnits.Init();

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