using System;
using UnityEngine;
using SpaceShooter.Data;
using SpaceShooter.Configs;

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

        [SerializeField] private UnitType _type;

        public UnitType Type { get { return _type; } }
        public PlayerData Data { get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayerName); }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly
            gameObject.SetActive(false);

            base.Die();
        }

        protected void Update()
        {
			/*
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 input = new Vector3(horizontal, 0, vertical);

            Mover.MoveToDirection(input);

            bool shoot = Input.GetButton("Shoot");

            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
			*/
        }

        public void Init(PlayerData playerData)
        {
            InitRequiredComponents();

            Data = playerData;
        }
    }
}
