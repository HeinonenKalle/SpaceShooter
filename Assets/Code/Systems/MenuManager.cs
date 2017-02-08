using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Data
{
    public class MenuManager : MonoBehaviour
    {

        // Use this for initialization
        public void StartGame()
        {
            Debug.Log("Start");
        }

        // Update is called once per frame
        public void LoadGame()
        {
            Debug.Log("Load");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
