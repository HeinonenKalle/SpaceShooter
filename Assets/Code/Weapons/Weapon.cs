using UnityEngine;
using ProjectileType = SpaceShooter.Projectile.ProjectileType;
using SpaceShooter.Utility;
using SpaceShooter.Systems;

namespace SpaceShooter
{
    class Weapon : MonoBehaviour
    {
        public enum TrailColor
        {
            Yellow = 0,
            Green,
            Red,
            Black
        }

        [SerializeField]
        private ProjectileType _projectileType;

        public void Shoot(int projectileLayer, Color trailColor)
        {
            Projectile projectile = GetProjectile(trailColor);

            if (projectile != null)
            {
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(transform.forward);
            }
        }

        private Projectile GetProjectile(Color trailColor)
        {
            Projectile projectilePrefab = Global.Instance.Prefabs.GetProjectilePrefabByType(_projectileType);

            if (projectilePrefab != null)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.ChangeTrailMaterialColor(trailColor);

                return projectile;
            }

            return null;
        }
    }
}
