using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyUnits : MonoBehaviour
    {
        public event Action<EnemyUnit> EnemyDestroyed;

        public void EnemyDie(EnemyUnit enemyUnit)
        {
            if(EnemyDestroyed != null)
            {
                EnemyDestroyed(enemyUnit);
            }
        }
    }
}
