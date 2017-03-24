using System;
using UnityEngine;
using SpaceShooter.Data;
using SpaceShooter.Configs;
using PlayerDataPlayerId = SpaceShooter.Data.PlayerData.PlayerId;
using SpaceShooter.Systems;
using System.Collections;

namespace SpaceShooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 2,
            Heavy = 3
        }

        [SerializeField]
        private UnitType _type;

        public UnitType Type { get { return _type; } }
        public PlayerData Data { get; private set; }

        public bool IsInvulnerable { get; private set; }

        public float MaxInvulnerabilityTime = 1f;

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayerName); }
        }

        private float _invulnerableTimer;

        private MeshRenderer _meshRenderer;

        protected override void Die()
        {
            // TODO: Handle dying properly
            gameObject.SetActive(false);

            if (Data.Lives >= 1)
            {
                Data.Lives--;
                Debug.Log("LIVES LEFT: " + Data.Lives);

                switch (Data.Id)
                {
                    case PlayerDataPlayerId.Player1:
                        {
                            gameObject.transform.position = Global.Instance.PlayerOneSpawnPoint;
                            break;
                        }
                    case PlayerDataPlayerId.Player2:
                        {
                            gameObject.transform.position = Global.Instance.PlayerTwoSpawnPoint;
                            break;
                        }
                    case PlayerDataPlayerId.Player3:
                        {
                            gameObject.transform.position = Global.Instance.PlayerThreeSpawnPoint;
                            break;
                        }
                    case PlayerDataPlayerId.Player4:
                        {
                            gameObject.transform.position = Global.Instance.PlayerFourSpawnPoint;
                            break;
                        }
                }

                TakeDamage(-100);
                _invulnerableTimer = MaxInvulnerabilityTime;
                IsInvulnerable = true;
                gameObject.SetActive(true);
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                StartCoroutine(Flash(0.1f, 0.1f));

            }
            else
            {
                base.Die();
                Debug.Log(Data.Id.ToString() + " died!");
                //Destroy(gameObject);
            }
        }

        protected void Update()
        {
            if (IsInvulnerable)
            {
                if (_invulnerableTimer > 0f)
                {
                    _invulnerableTimer -= Time.deltaTime;
                }
                else if (_invulnerableTimer < 0f)
                {
                    IsInvulnerable = false;                }
            }
        }

        IEnumerator Flash(float time, float intervalTime)
        {
            float elapsedTime = 0f;
            int index = 0;
            while (elapsedTime < time)
            {
                _meshRenderer.enabled = !_meshRenderer.enabled;
                elapsedTime += Time.deltaTime;
                index++;
                yield return new WaitForSeconds(intervalTime);
            }

            if (!_meshRenderer.enabled)
            {
                _meshRenderer.enabled = true;
            }
        }

        public void Init(PlayerData playerData)
        {
            InitRequiredComponents();

            Data = playerData;

            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}
