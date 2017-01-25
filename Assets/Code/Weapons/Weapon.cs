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
                //projectile.ChangeTrailMaterial(Global.Instance.TrailMaterials[(int) trailColor]);
                projectile.ChangeTrailMaterialColor(trailColor);

                /*if (trailColor != TrailColor.Yellow)
                {
                    if (trailColor == TrailColor.Green)
                    {
                        projectile.ChangeTrailMaterial(Global.Instance.TrailMaterials[1]);
                    }
                    else if (trailColor == TrailColor.Red)
                    {
                        projectile.ChangeTrailMaterial(Global.Instance.TrailMaterials[2]);
                    }
                    else if (trailColor == TrailColor.Black)
                    {
                        projectile.ChangeTrailMaterial(Global.Instance.TrailMaterials[3]);
                    }
                }*/

            return projectile;
            }

            return null;
        }
    }
}
