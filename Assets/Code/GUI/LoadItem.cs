using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.GUI
{
    public class LoadItem : MonoBehaviour
    {
        private Text _loadButtonLabel;
        private LoadWindow _loadWindow;

        public void Init(LoadWindow loadWindow, string saveFileName)
        {
            _loadWindow = loadWindow;

            _loadButtonLabel = GetComponentInChildren<Text>(true);
            _loadButtonLabel.text = saveFileName;
        }

        public void OnClick()
        {
            _loadWindow.LoadGame(_loadButtonLabel.text);
        }
    }
}
