using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Data;

namespace SpaceShooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach(PlayerData playerData in players)
            {

            }
        }
    }
}