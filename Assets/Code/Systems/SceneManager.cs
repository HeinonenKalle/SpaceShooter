using UnityEngine;
using SpaceShooter.Systems.States;

namespace SpaceShooter.Systems
{
    public abstract class SceneManager : MonoBehaviour
    {
        public abstract GameStateType StateType { get; }
        public virtual GameStateBase AssociatedState
        {
            get
            {
                if (_associatedState == null)
                {
                    _associatedState = Global.Instance.GameManager.GetStateByStateType(StateType);
                }

                return _associatedState;
            }
        }

        private GameStateBase _associatedState;
    }
}
