using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : MonoBehaviour
    {
        public enum ProjectileType
        {
            None = 0,
            Laser = 1,
            Explosive = 2,
            Missile = 3
        }

        #region Unity fields
        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;

        #endregion

        private Rigidbody _rigidBody;

        #region Unity messages
        protected virtual void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        protected void OnCollisionEnter(Collision coll)
        {
            IHealth damageReceiver = coll.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);

                Destroy(gameObject);
            }
        }
        #endregion

        public void Shoot(Vector3 direction)
        {
            _rigidBody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}