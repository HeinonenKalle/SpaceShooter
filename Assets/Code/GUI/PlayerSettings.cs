using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Systems;
using SpaceShooter.Data;
using SpaceShooter.Configs;

namespace SpaceShooter.GUI
{
    public class PlayerSettings : Window
    {
        [SerializeField] private Dropdown _playerCountDropdown;
        [SerializeField] private PlayerSettingsItem[] _playerSettingsItems;

        private MenuManager _menuManager;
        
        public int PlayerCount { get; private set; }

        public void Init(MenuManager menuManager)
        {
            _playerCountDropdown.onValueChanged.AddListener(OnValueChanged);
            _playerCountDropdown.value = 0;
            OnValueChanged(0);

            _menuManager = menuManager;

            foreach (PlayerSettingsItem item in _playerSettingsItems)
            {
                item.Init();
            }
        }

        public void StartGame()
        {
            List<PlayerData> playerDatas = new List<PlayerData>();
            
            for (int i = 0; i < PlayerCount; ++i)
            {
                var settingsItem = _playerSettingsItems[i];

                var playerData = new PlayerData()
                {
                    Controller = settingsItem.Controller,
                    UnitType = settingsItem.UnitType,
                    Id = settingsItem.PlayerId,
                    Lives = Config.Lives
                };

                playerDatas.Add(playerData);
            }

            _menuManager.StartGame(playerDatas);
        }

        private void OnValueChanged(int index)
        {
            int playerCount;
            if (int.TryParse(_playerCountDropdown.options[index].text, out playerCount))
            {
                PlayerCount = playerCount;
                for (int i = 0; i < _playerSettingsItems.Length; i++)
                {
                    _playerSettingsItems[i].gameObject.SetActive(PlayerCount > i);
                }
            }
        }
    }
}
