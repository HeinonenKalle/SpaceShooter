using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Configs;

namespace SpaceShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits EnemyUnits { get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.EnemyProjectileLayerName); }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            //EnemyUnits.EnemyDied(this);

            base.Die();
        }

        public void Init(EnemyUnits enemyUnits)
        {
            enemyUnits = EnemyUnits;
        }
    }
}
