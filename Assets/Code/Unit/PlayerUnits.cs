using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;
using SpaceShooter.Systems;

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
                    unit.transform.position = Vector3.zero;
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