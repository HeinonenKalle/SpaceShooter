using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using SpaceShooter.Systems;
using PlayerDataPlayerId = SpaceShooter.Data.PlayerData.PlayerId;

namespace SpaceShooter
{
    public class PlayerUnits : MonoBehaviour
    {
		public InputManager ManagerOfInputs;
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach(PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitPrefab(playerData.UnitType);

                if (unitPrefab != null)
                {
                    PlayerUnit unit = Instantiate(unitPrefab, transform);

					switch (playerData.Id)
					{
					case PlayerDataPlayerId.Player1:
						{
							unit.transform.position = Global.Instance.PlayerOneSpawnPoint;
							break;
						}
					case PlayerDataPlayerId.Player2:
						{
							unit.transform.position = Global.Instance.PlayerTwoSpawnPoint;
							break;
						}
					case PlayerDataPlayerId.Player3:
						{
							unit.transform.position = Global.Instance.PlayerThreeSpawnPoint;
							break;
						}
					case PlayerDataPlayerId.Player4:
						{
							unit.transform.position = Global.Instance.PlayerFourSpawnPoint;
							break;
						}
					}

                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(playerData);

                    _players.Add(playerData.Id, unit);
					ManagerOfInputs.AddPlayerToList (unit);
                }
                else
                {
                    Debug.LogError("Unit prefab with type " + playerData.UnitType + "could not be found!");
                }
            }
        }
    }
}