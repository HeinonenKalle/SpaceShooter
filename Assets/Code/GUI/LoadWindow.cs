using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Systems;

namespace SpaceShooter.GUI
{
    public class LoadWindow : Window
    {
        [SerializeField] private LoadItem _loadItemPrefab;

        private VerticalLayoutGroup _contentParent;

        private MenuManager _menuManager;

        public void Init(MenuManager menuManager)
        {
            _menuManager = menuManager;
            List<string> saveNames = Global.Instance.SaveManager.GetAllSaveNames();

            foreach (string saveName in saveNames)
            {
                LoadItem loadItem = Instantiate(_loadItemPrefab, _contentParent.transform, true);
                loadItem.Init(this, saveName);
            }
        }

        public void LoadGame(string saveFileName)
        {
            _menuManager.LoadGame(saveFileName);
        }
    }
}
