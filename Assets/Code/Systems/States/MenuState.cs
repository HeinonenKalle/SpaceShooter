using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Configs;

namespace SpaceShooter.Systems.States
{
    public class MenuState : GameStateBase
    {
        public override string SceneName
        {
            get
            {
                return Config.MenuSceneName;
            }
        }

       public MenuState() : base()
        {
            State = GameStateType.MenuState;
            AddTransition(GameStateTransitionType.MenuToInGame, GameStateType.InGameState);
        }
    }
}
