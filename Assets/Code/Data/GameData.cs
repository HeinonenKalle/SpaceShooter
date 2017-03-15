using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceShooter.Data
{
    [Serializable]
    public class GameData
    {
        public List<PlayerData> PlayerDataList = new List<PlayerData>();
        public int Level;
    }
}
