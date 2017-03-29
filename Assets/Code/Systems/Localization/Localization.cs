using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using SpaceShooter.Exceptions;
using SpaceShooter.SaveLoad;

namespace SpaceShooter.Systems
{
    public enum LangCode
    {
        NA = 0,
        EN = 1,
        FI = 2,
        JP = 3
    }

    public static class Localization
    {
        public const string localizationFolderName = "Localizations";
        public const string fileExtension = ".json";

        public static event Action LanguageLoaded;

        public static string LocalizationPath
        {
            get { return Path.Combine(Application.dataPath, localizationFolderName); }
        }
        
        public static Language CurrentLanguage { get; private set; }

        public static void LoadLanguage(LangCode languageCode)
        {
            if (Application.isPlaying)
            {
                SaveManager.Language = languageCode;
            }

            var path = GetLocalizationFilePath(languageCode);

            if (File.Exists(path))
            {
                string JsonLocalization = File.ReadAllText(path);
                CurrentLanguage = JsonUtility.FromJson<Language>(JsonLocalization);
                CurrentLanguage.LanguageCode = languageCode;

                if (LanguageLoaded != null)
                {
                    LanguageLoaded();
                }
            }
            else
            {
                throw new LocalizationNotFoundException(languageCode);
            }
        }

        public static string GetLocalizationFilePath(LangCode languageCode)
        {
            return Path.Combine(LocalizationPath, languageCode.ToString()) + fileExtension;
        }

        public static void CreateNewLanguage(LangCode languageCode)
        {
            CurrentLanguage = new Language(languageCode);
        }

        public static void SaveCurrentLanguage()
        {
            if (CurrentLanguage.LanguageCode == LangCode.NA)
            {
                return;
            }

            if (!Directory.Exists(LocalizationPath))
            {
                Directory.CreateDirectory(LocalizationPath);
            }

            string path = GetLocalizationFilePath(CurrentLanguage.LanguageCode);
            string jsonLanguage = JsonUtility.ToJson(CurrentLanguage);
            File.WriteAllText(path, jsonLanguage);
        }
    }

    [Serializable]
    public class Language
    {
        [SerializeField] private List<string> _keys = new List<string>();
        [SerializeField] private List<string> _values = new List<string>();

        private bool _isInitialized = false;

        private LangCode _langCode;

        public LangCode LanguageCode
        {
            get { return _langCode; }
            set
            {
                _langCode = value;
                _isInitialized = true;
            }
        }

        public Language()
        {
            Debug.Log("Language created but not initialized");
        }

        public Language(LangCode langCode)
        {
            LanguageCode = langCode;
            Debug.Log("Language created and initialized");
        }

        public string GetTranslation(string key)
        {
            string result = null;

            int index = _keys.IndexOf(key);

            if (index >= 0)
            {
                result = _values[index];
            }

            return result;
        }

#if UNITY_EDITOR
        public void SetValues(Dictionary<string, string> values)
        {
            foreach(var kvp in values)
            {
                if(_keys.Contains(kvp.Key))
                {
                    int index = _keys.IndexOf(kvp.Key);
                    _values[index] = kvp.Value;
                }
                else
                {
                    _keys.Add(kvp.Key);
                    _values.Add(kvp.Value);
                }
            }
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < _keys.Count; ++i)
            {
                result.Add(_keys[i], _values[i]);
            }

            return result;
        }
#endif
    }
}
