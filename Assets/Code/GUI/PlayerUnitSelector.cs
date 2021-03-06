﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Data;

namespace SpaceShooter.GUI
{
    public class PlayerUnitSelector : MonoBehaviour
    {
        private Dropdown _dropdown;

        public PlayerUnit.UnitType SelectedUnitType { get; private set; }
        public PlayerData.PlayerId PlayerId { get; private set; }

        public void Init(PlayerData.PlayerId playerId)
        {
            _dropdown = GetComponentInChildren<Dropdown>();
            _dropdown.ClearOptions();

            var optionDataList = new List<Dropdown.OptionData>();

            foreach (var value in Enum.GetValues(typeof(PlayerUnit.UnitType)))
            {
                if ((PlayerUnit.UnitType)value != PlayerUnit.UnitType.None)
                {
                    optionDataList.Add(new Dropdown.OptionData(value.ToString()));
                }
            }

            _dropdown.AddOptions(optionDataList);
            _dropdown.onValueChanged.AddListener(OnValueChanged);

            _dropdown.value = 0;
            OnValueChanged(0);
        }

        private void OnValueChanged(int index)
        {
            string selectionText = _dropdown.options[index].text;
            SelectedUnitType = (PlayerUnit.UnitType) Enum.Parse(typeof(PlayerUnit.UnitType), selectionText);
        }
    }
}
