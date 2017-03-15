using UnityEngine;
using SpaceShooter.Configs;
using SpaceShooter.WaypointSystem;
using SpaceShooter.Utility;

namespace SpaceShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits EnemyUnits { get; private set; }

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
    }
}
