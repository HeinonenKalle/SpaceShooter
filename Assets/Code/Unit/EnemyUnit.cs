using UnityEngine;
using SpaceShooter.Configs;
using SpaceShooter.WaypointSystem;
using SpaceShooter.Utility;

namespace SpaceShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits EnemyUnits { get; private set; }

        [SerializeField] private int _damage;

        private IPathUser _pathUser;

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.EnemyProjectileLayerName); }
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);

            base.Die();
        }

        public void Init(EnemyUnits enemyUnits, Path path)
        {
            InitRequiredComponents();

            EnemyUnits = enemyUnits;
            _pathUser = gameObject.GetOrAddComponent<PathUser>();

            _pathUser.Init(Mover, path);
        }

        public void OnCollisionEnter(Collision collision)
        {
            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                // If collision has damageReceiver, it is a player unit.
                // Check if the player unit is invulnerable or not.
                if (!collision.gameObject.GetComponentInChildren<PlayerUnit>().IsInvulnerable)
                {
                    damageReceiver.TakeDamage(_damage);
                }


                TakeDamage(10);
            }
        }
    }
}
