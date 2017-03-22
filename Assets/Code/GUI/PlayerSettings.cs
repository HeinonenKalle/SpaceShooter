using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Systems;

namespace SpaceShooter.GUI
{
    public class PlayerSettings : Window
    {
        [SerializeField] private Dropdown _playerCountDropdown;
        [SerializeField] private PlayerSettingsItem[] _playerSettingsItems;

        private MenuManager _menuManager;
        
        public void Init(MenuManager menuManager)
        {
            _menuManager = menuManager;

            foreach (PlayerSettingsItem item in _playerSettingsItems)
            {
                item.Init();
            }
        }
    }
}
