using System;

namespace SpaceShooter.Data
{
    [Serializable] public class PlayerData
    {
        public enum PlayerId
        {
            None = 0,
            Player1 = 1,
            Player2 = 2,
            Player3 = 3,
            Player4 = 4
        }

		public enum ControlType
		{
            None = -1,
			WASD,
			Arrows,
			Gamepad1,
			Gamepad2
		}

        public PlayerId Id;
		public ControlType Controller;
        public PlayerUnit.UnitType UnitType;
        public int Lives;
    }
}