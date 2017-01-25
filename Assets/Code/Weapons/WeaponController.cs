using UnityEngine;

namespace SpaceShooter
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _shootingSpeed;

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
            _previousShot = +Time.deltaTime;
        }
        #endregion
    }
}
