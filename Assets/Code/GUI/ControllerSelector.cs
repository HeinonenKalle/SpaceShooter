using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Data;
using SpaceShooter.Systems;

namespace SpaceShooter.GUI
{
    public class ControllerSelector : MonoBehaviour
    {
        public PlayerData.PlayerId Id { get; private set; }
        public PlayerData.ControlType Controller { get; private set; }

        private Dropdown _dropdown;

        public void Init(PlayerData.PlayerId id, PlayerData.ControlType defaultControlType)
        {
            _dropdown = GetComponentInChildren<Dropdown>(true);
            _dropdown.ClearOptions();

            List<Dropdown.OptionData> optionDataList = new List<Dropdown.OptionData>();

            foreach (var value in Enum.GetValues(typeof(PlayerData.ControlType)))
            {
                if ((PlayerData.ControlType)value != PlayerData.ControlType.None)
                {
                    string controllerName = Enum.GetName(typeof(PlayerData.ControlType), value);
                    optionDataList.Add(new Dropdown.OptionData(controllerName));
                }
            }

            _dropdown.AddOptions(optionDataList);
            _dropdown.onValueChanged.AddListener(OnValueChanged);

            Id = id;
            Controller = defaultControlType;
            
        }

        private void OnValueChanged(int index)
        {
            string selectionText = _dropdown.options[index].text;
            Controller = (PlayerData.ControlType)Enum.Parse(typeof(PlayerData.ControlType), selectionText);
        }

        private int GetItemIndex(string controllerName)
        {
            int result = -1;

            for (int i = 0; i < _dropdown.options.Count; i++)
            {
                Dropdown.OptionData item = _dropdown.options[i];

                if (item.text == controllerName)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
