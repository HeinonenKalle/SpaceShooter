using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Configs;

namespace SpaceShooter.Systems.States
{
    public class GameState : GameStateBase
    {
        public int CurrentLevelIndex { get; private set; }

        public override string SceneName
        {
            get
            {
                try
                {
                    return Config.LevelNames[CurrentLevelIndex];
                }
                catch(KeyNotFoundException exception)
                {
                    Debug.LogException(exception);
                    return null;
                }
            }
        }
        
        public GameState(int levelIndex) : base()
        {
            CurrentLevelIndex = levelIndex;
            State = GameStateType.InGameState;
            AddTransition(GameStateTransitionType.InGameToGameOver, GameStateType.GameOverState);
            AddTransition(GameStateTransitionType.InGameToMenu, GameStateType.MenuState);
            AddTransition(GameStateTransitionType.InGameToInGame, GameStateType.InGameState);
        }

        public GameState() : this ( 1 )
        {

        }

        public void LevelCompleted()
        {
            CurrentLevelIndex++;
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.InGameToInGame);
        }
    }
}
