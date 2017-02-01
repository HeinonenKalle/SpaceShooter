using UnityEngine;

namespace SpaceShooter
{
    public interface IShooter
    {
        void Shoot(int projectileLayer, Color trailColor);
        void ProjectileHit(Projectile projectile);
    }
}
