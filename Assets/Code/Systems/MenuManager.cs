using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceShooter.Systems
{
    public class MenuManager : SceneManager
    {
        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        // Use this for initialization
        public void StartGame()
        {
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        // Update is called once per frame
        public void LoadGame()
        {

        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
