﻿using System;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
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

        protected void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 input = new Vector3(horizontal, 0, vertical);

            Mover.MoveToDirection(input);

            bool shoot = Input.GetButton("Shoot");

            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
        }
    }
}
