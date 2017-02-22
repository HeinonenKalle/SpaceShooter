using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Systems;

namespace SpaceShooter
{
    public abstract class ConditionBase : MonoBehaviour
    {
        public LevelManager LevelManager { get; private set; }
        public bool IsConditionMet { get; protected set; }

        // Use this for initialization
        public void Init(LevelManager levelManager)
        {
            LevelManager = levelManager;
            Initialize();
        }

        // Update is called once per frame
        protected abstract void Initialize();
    }
}
