using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SpaceShooter.SaveLoad
{
    public class BinaryFormatterSaveLoad<T> : ISaveLoad<T>
        where T : class
    {
        public string FileExtension { get { return ".dat"; } }

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
                byte[] data = File.ReadAllBytes(GetSaveFilePath(fileName));

                BinaryFormatter formatter = new BinaryFormatter();

                using (MemoryStream stream = new MemoryStream(data))
                {
                    return (T) formatter.Deserialize(stream);
                }
            }

            return default(T);
        }

        public void Save(T objectToSave, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objectToSave);

                File.WriteAllBytes(GetSaveFilePath(fileName), stream.GetBuffer());
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
