using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SpaceShooter.Data;

namespace SpaceShooter.Systems
{
    public class MenuManager : SceneManager
    {
        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        // Use this for initialization
        public void StartGame()
        {
            Global.Instance.CurrentGameData = new GameData()
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

            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        // Update is called once per frame
        public void LoadGame()
        {

        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
