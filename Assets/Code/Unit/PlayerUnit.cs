using System;
using UnityEngine;

namespace SpaceShooter
{
    class PlayerUnit : UnitBase
    {
        public enum UnityType
        {
            None = 0,
            Fast = 1,
            Balanced = 2,
            Heavy = 3
        }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer("PlayerProjectile"); }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly
            gameObject.SetActive(false);
        }
    }
}
