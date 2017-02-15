using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Systems.States;

namespace SpaceShooter.Systems
{
    public enum GameStateType
    {
        Error = -1,
        MenuState,
        InGameState,
        GameOverState
    }

    public enum GameStateTransitionType
    {
        Error = 1,
        MenuToInGame,
        InGameToMenu,
        InGameToGameOver,
        GameOverToMenu
    }

    public class GameManager : MonoBehaviour
    {
        public SceneManager CurrentSceneManager { get; private set; }
        public GameStateBase CurrentState { get; private set; }
        public GameStateType CurrentStateType { get { return CurrentState.State; } }

        public event System.Action<GameStateType> GameStateChanging;
        public event System.Action<GameStateType> GameStateChanged;

        private readonly List<GameStateBase> _states = new List<GameStateBase>();

        public void Init()
        {
            MenuState startingState = new MenuState();
            AddState(startingState);
            AddState(new GameState());
            CurrentState = startingState;
        }

        public bool AddState(GameStateBase state)
        {
            bool exists = false;

            foreach (GameStateBase s in _states)
            {
                if (s.State == state.State)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _states.Add(state);
            }

            return !exists;
        }

        public bool RemoveState(GameStateType stateType)
        {
            GameStateBase state = null;

            foreach (GameStateBase s in _states)
            {
                if (s.State == stateType)
                {
                    state = s;
                }
            }

            return state != null && _states.Remove(state);
        }

        public bool PerformTransition(GameStateTransitionType transition)
        {
            GameStateType targetStateType = CurrentState.GetTargetStateType(transition);

            if (targetStateType == GameStateType.Error)
            {
                return false;
            }

            foreach (GameStateBase state in _states)
            {
                if (state.State == targetStateType)
                {
                    CurrentState.StateDeactivating();
                    CurrentState = state;
                    CurrentState.StateActivated();
                    
                    return true;
                }
            }

            return false;
        }

        public void RaiseGameStateChangingEvent(GameStateType stateType)
        {
            if (GameStateChanging != null)
            {
                GameStateChanging(stateType);
            }
        }

        public void RaiseGameStateChangedEvent(GameStateType stateType)
        {
            if (GameStateChanged != null)
            {
                GameStateChanged(stateType);
            }
        }

        public GameStateBase GetStateByStateType(GameStateType stateType)
        {
            GameStateBase state = null;

            foreach (GameStateBase s in _states)
            {
                if (s.State == stateType)
                {
                    state = s;
                }
            }

            return state;
        }
    }
}
