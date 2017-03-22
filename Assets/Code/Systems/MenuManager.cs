using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SpaceShooter.Data;
using SpaceShooter.GUI;

namespace SpaceShooter.Systems
{
    public class MenuManager : SceneManager
    {
        private LoadWindow _loadWindow;
        private PlayerSettings _playerSettings;

        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        private void Awake()
        {
            _loadWindow = GetComponentInChildren<LoadWindow>(true);
            _loadWindow.Init(this);
            _loadWindow.Close();

            _playerSettings = GetComponentInChildren<PlayerSettings>(true);
            _playerSettings.Init(this);
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
        public void OpenLoadWindow()
        {
            _loadWindow.Open();
        }

        public void LoadGame(string saveFileName)
        {
            _loadWindow.Close();

            GameData loadData = Global.Instance.SaveManager.Load(saveFileName);
            Global.Instance.CurrentGameData = loadData;
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
