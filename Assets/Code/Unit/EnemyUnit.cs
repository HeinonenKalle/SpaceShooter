using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits EnemyUnits { get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer("EnemyProjectile"); }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            EnemyUnits.EnemyDie(this);
        }

        public void Init(EnemyUnits enemyUnits)
        {
            enemyUnits = EnemyUnits;
        }
    }
}
