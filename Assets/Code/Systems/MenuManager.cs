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
        private PlayerSettings _playerSettingsWindow;

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

            _playerSettingsWindow = GetComponentInChildren<PlayerSettings>(true);
            _playerSettingsWindow.Init(this);
            _playerSettingsWindow.Close();
        }

        public void StartGame(List<PlayerData> playerDatas)
        {
            _playerSettingsWindow.Close();

            Global.Instance.CurrentGameData = new GameData()
            {
                Level = 1,
                PlayerDataList = playerDatas
            };

            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void OpenStartGameWindow()
        {
            _playerSettingsWindow.Open();
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
