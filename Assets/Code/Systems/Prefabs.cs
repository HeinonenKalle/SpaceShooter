using UnityEngine;
using System.Collections.Generic;

namespace SpaceShooter.Systems
{
    public class Prefabs : MonoBehaviour
    {
        [SerializeField]
        private List<Projectile> _projectilePrefabs = new List<Projectile>();

        [SerializeField]
        private PlayerUnit[] _playerUnitPrefabs;

        public Projectile GetProjectilePrefabByType(ProjectileType projectileType)
        {
            foreach (Projectile projectile in _projectilePrefabs)
            {
                if (projectile.Type == projectileType)
                {
                    return projectile;
                }
            }

            return null;
        }

        public PlayerUnit GetPlayerUnitPrefab(PlayerUnit.UnitType unitType)
        {
            foreach (PlayerUnit playerUnit in _playerUnitPrefabs)
            {
                if (playerUnit.Type == unitType)
                {
                    return playerUnit;
                }
            }

            return null;
        }
    }
}
