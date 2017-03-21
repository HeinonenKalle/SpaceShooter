using System;
using UnityEngine;
using SpaceShooter.Data;
using SpaceShooter.Configs;
using PlayerDataPlayerId = SpaceShooter.Data.PlayerData.PlayerId;
using SpaceShooter.Systems;

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

		public bool IsInvulnerable { get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayerName); }
        }

		private float _invulnerableTimer;

        protected override void Die()
        {
            // TODO: Handle dying properly
            gameObject.SetActive(false);

			if (Data.Lives >= 1)
			{
				Data.Lives--;

				switch (Data.Id)
				{
				case PlayerDataPlayerId.Player1:
					{
						gameObject.transform.position = Global.Instance.PlayerOneSpawnPoint;
						break;
					}
				case PlayerDataPlayerId.Player2:
					{
						gameObject.transform.position = Global.Instance.PlayerOneSpawnPoint;
						break;
					}
				case PlayerDataPlayerId.Player3:
					{
						gameObject.transform.position = Global.Instance.PlayerOneSpawnPoint;
						break;
					}
				case PlayerDataPlayerId.Player4:
					{
						gameObject.transform.position = Global.Instance.PlayerOneSpawnPoint;
						break;
					}
				}

			}
			else
			{
				base.Die();
				Destroy (gameObject);
			}
        }

        protected void Update()
        {
			if (_invulnerableTimer > 0f)
			{
				_invulnerableTimer -= Time.deltaTime;
			}
			else if (_invulnerableTimer < 0f)
			{
				IsInvulnerable = false;
			}
        }

        public void Init(PlayerData playerData)
        {
            InitRequiredComponents();

            Data = playerData;
        }
    }
}
