using UnityEngine;

namespace SpaceShooter.Systems
{
    public class ProjectilePool : GenericPool<Projectile>
    {
        [SerializeField] ProjectileType _projectileType;

        public ProjectileType ProjectileType
        {
            get { return _projectileType; }
        }

        protected override void Deactivate(Projectile item)
        {
            item.transform.position = Vector3.zero;
            item.transform.rotation = Quaternion.identity;
            item.Rigidbody.velocity = Vector3.zero;

            base.Deactivate(item);
        }
    }
}