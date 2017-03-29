using System.Collections.Generic;
using SpaceShooter.Data;
using System.IO;
using UnityEngine;
using SpaceShooter.Systems;
using System;

namespace SpaceShooter.SaveLoad
{
    public class SaveManager
    {
        private readonly ISaveLoad<GameData> _saveLoad;

        public string FileExtension { get { return _saveLoad.FileExtension; } }

        private const string LanguageKey = "Language";

        public static LangCode Language
        {
            get { return (LangCode) Enum.Parse( typeof(LangCode), PlayerPrefs.GetString(LanguageKey, LangCode.FI.ToString())); }
            set { PlayerPrefs.SetString(LanguageKey, value.ToString()); }
        }

        public SaveManager(ISaveLoad<GameData> saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void Save(GameData data, string saveFileName)
        {
            _saveLoad.Save(data, saveFileName);
        }
        
        public GameData Load(string saveFileName)
        {
            return _saveLoad.Load(saveFileName);
        }

        public List<string> GetAllSaveNames()
        {
            List<string> saveNames = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
            FileInfo[] files = directoryInfo.GetFiles("*" + FileExtension);

            foreach(var fileInfo in files)
            {
                string fileName = fileInfo.Name;
                fileName = fileName.Replace(FileExtension, " ");
                saveNames.Add(fileName);
            }

            return saveNames;
        }
    }
}
