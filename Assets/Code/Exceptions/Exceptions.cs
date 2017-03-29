using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SpaceShooter.Systems;

namespace SpaceShooter.Exceptions
{
    public class LocalizationNotFoundException : FileNotFoundException
    {
        public LangCode Language { get; private set; }

        public LocalizationNotFoundException(LangCode languageCode)
        {
            Language = languageCode;
        }

        public override string Message
        {
            get
            {
                return "Localization file not found for language " + Language;
            }
        }
    }
}