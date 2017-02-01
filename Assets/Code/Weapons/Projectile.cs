using UnityEngine;

namespace SpaceShooter
{
    public enum ProjectileType
    {
        None = 0,
        Laser = 1,
        Explosive = 2,
        Missile = 3
    }

    public class Projectile : MonoBehaviour
    {
        #region Unity fields
        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ProjectileType _projectileType;
        #endregion

        private IShooter _shooter;

        public Rigidbody Rigidbody { get; private set; }
        private Material _trailMaterial;
        private TrailRenderer _trailRenderer;

        public ProjectileType Type { get { return _projectileType; } }

        #region Unity messages
        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        protected void OnCollisionEnter(Collision coll)
        {
            IHealth damageReceiver = coll.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);

                _shooter.ProjectileHit(this);
            }
        }

        protected void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                _shooter.ProjectileHit(this);
            }

        }
        #endregion

        public void Shoot(IShooter shooter, Vector3 direction)
        {
            _shooter = shooter;
            Rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);

        }

        public void ChangeTrailMaterial(Material mat)
        {
            _trailRenderer.material = mat;
        }

        public void ChangeTrailMaterialColor(Color samba)
        {
            _trailRenderer.material.color = samba;
        }
    }
}