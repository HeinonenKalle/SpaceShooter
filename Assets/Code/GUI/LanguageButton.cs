using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Systems;

namespace SpaceShooter.GUI
{
    public class LanguageButton : MonoBehaviour
    {
        [SerializeField] private LangCode _language;
        
        public void OnClick()
        {
            Localization.LoadLanguage(_language);
        }
    }
}
