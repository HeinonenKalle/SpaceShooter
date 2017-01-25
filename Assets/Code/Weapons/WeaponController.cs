using UnityEngine;
using TrailColor = SpaceShooter.Weapon.TrailColor;

namespace SpaceShooter
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private float _shootingSpeed;

        [SerializeField]
        private TrailColor _trailColor;

        [SerializeField]
        private Color MarkusHyvarinen;

        private float _fireRate;
        private float _previousShot; // Time elapsed since the last shot was fired
        private Weapon[] _weapons;

        #region Unity messages
        protected void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            _fireRate = 1 / _shootingSpeed;
            _previousShot = _fireRate; 
        }

        protected void Update()
        {
            _previousShot += Time.deltaTime;
        }
        #endregion

        public void Shoot(int projectileLayer)
        {

            if (_previousShot >= _fireRate)
            {
                _previousShot = 0;

                foreach (Weapon weapon in _weapons)
                {
                    weapon.Shoot(projectileLayer, MarkusHyvarinen);
                }

            }
        }
    }
}
