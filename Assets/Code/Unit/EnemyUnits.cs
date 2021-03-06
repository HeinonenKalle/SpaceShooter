﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyUnits : MonoBehaviour
    {
        public event Action<EnemyUnit> EnemyDestroyed;

        private List<EnemyUnit> _enemies = new List<EnemyUnit>();

        public void Init()
        {
            //EnemyUnit[] enemies = FindObjectsOfType<EnemyUnit>();

            //foreach(EnemyUnit enemy in enemies)
            //{
            //    _enemies.Add(enemy);
            //    enemy.Init(this, null);
            //}
        }

        public void EnemyDied(EnemyUnit enemyUnit)
        {
            if(EnemyDestroyed != null)
            {
                EnemyDestroyed(enemyUnit);
            }
        }
    }
}
