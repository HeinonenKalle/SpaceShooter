using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using UnityEngine.UI;

namespace SpaceShooter.GUI
{
    public class PlayerSettingsItem : MonoBehaviour
    {
        [SerializeField] private PlayerData.PlayerId _id;
        [SerializeField] private Text _playerIdText;

        private ControllerSelector _controllerSelector;
        private PlayerUnitSelector _playerUnitSelector;

        public void Init()
        {
            _controllerSelector = GetComponentInChildren<ControllerSelector>(true);
            _controllerSelector.Init(_id, PlayerData.ControlType.WASD);

            _playerUnitSelector = GetComponentInChildren<PlayerUnitSelector>(true);
            _playerUnitSelector.Init();

            _playerIdText.text = string.Format("Player {0}", (int)_id);
        }
    }
}
