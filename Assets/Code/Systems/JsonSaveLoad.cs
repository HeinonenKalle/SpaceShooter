using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SpaceShooter.Data;
using System.Text;

namespace SpaceShooter.SaveLoad
{
    public class JsonSaveLoad<T> : ISaveLoad<T>
        where T : class
    {
        public string FileExtension
        {
            get
            {
                return ".json";
            }
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }

        public string GetSaveFilePath(string saveFileName)
        {
            return Path.Combine(Application.persistentDataPath, saveFileName) + FileExtension;
        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                string jsonObject = File.ReadAllText(GetSaveFilePath(fileName), Encoding.UTF8);
                return JsonUtility.FromJson<T>(jsonObject);
            }

            return default (T);
        }

        public void Save(T objectToSave, string fileName)
        {
            string jsonObject = JsonUtility.ToJson(objectToSave, true);
            File.WriteAllText(GetSaveFilePath(fileName), jsonObject, Encoding.UTF8);
        }
    }
}
