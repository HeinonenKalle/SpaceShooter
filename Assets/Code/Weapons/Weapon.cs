using UnityEngine;
using SpaceShooter.Utility;
using SpaceShooter.Systems;
using System;

namespace SpaceShooter
{
    class Weapon : MonoBehaviour, IShooter
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
                projectile.gameObject.SetActive(true);
                projectile.transform.position = transform.position;
                projectile.transform.forward = transform.forward;
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(this, transform.forward);
            }
            else
            {
                Debug.LogError("Could not get Projectile");
            }
        }

        private Projectile GetProjectile(Color trailColor)
        {
            Projectile result = null;

            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if (pool != null)
            {
                result = pool.GetPooledObject();
                //result.ChangeTrailMaterialColor(trailColor);
            }

            return result;
        }

         public void ProjectileHit(Projectile projectile)
        {
            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if (pool != null)
            {
                pool.ReturnObjectToPool(projectile);
            }
            else
            {
                Destroy(projectile.gameObject);
            }
        }
    }
}
