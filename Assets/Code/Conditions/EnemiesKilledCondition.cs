using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemiesKilledCondition : ConditionBase
    {
        [SerializeField]
        private int _enemyCount;

        private int _enemiesKilled = 0;

        protected override void Initialize()
        {
            LevelManager.EnemyUnits.EnemyDestroyed += HandleEnemyDestroyed;
        }

        private void HandleEnemyDestroyed(EnemyUnit enemy)
        {
            _enemiesKilled++;

            if (_enemiesKilled >= _enemyCount)
            {
                IsConditionMet = true;
                LevelManager.ConditionMet(this);
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
