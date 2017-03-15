using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Systems
{
    public class Pools : MonoBehaviour
    {
        [SerializeField] private List<ProjectilePool> _projectilePools = new List<ProjectilePool>();
        [SerializeField] private AsteroidPool _asteroidPool;

        public ProjectilePool GetPool(ProjectileType projectileType)
        {
            ProjectilePool result = null;

            foreach (ProjectilePool projectilePool in _projectilePools)
            {
                if (projectilePool.ProjectileType == projectileType)
                {
                    result = projectilePool;
                    break;
                }
            }

            return result;
        }

        public AsteroidPool AsteroidPool { get { return _asteroidPool; } }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}