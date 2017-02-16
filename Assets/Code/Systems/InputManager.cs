using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller = SpaceShooter.Data.PlayerData.ControlType;

namespace SpaceShooter.Systems
{
	public class InputManager : MonoBehaviour 
	{
		private List<PlayerUnit> _players = new List<PlayerUnit>();

		public void AddPlayerToList(PlayerUnit newPlayer)
		{
			_players.Add (newPlayer);
		}

		// Update is called once per frame
		void Update () 
		{
			foreach (PlayerUnit player in _players)
			{
				Controller controlMethod = player.Data.Controller;

				switch (controlMethod)
				{
				case(Controller.WASD):
					{
						float horizontal = Input.GetAxis("WASD_Hori");
						float vertical = Input.GetAxis("WASD_Verti");

						Vector3 input = new Vector3(horizontal, 0, vertical);

						player.Mover.MoveToDirection(input);

						bool shoot = Input.GetButton("WASD_Shoot");

						if (shoot)
						{
							player.Weapons.Shoot(player.ProjectileLayer);
						}

						break;
					}
				case(Controller.Arrows):
					{
						float horizontal = Input.GetAxis("Arrows_Hori");
						float vertical = Input.GetAxis("Arrows_Verti");

						Vector3 input = new Vector3(horizontal, 0, vertical);

						player.Mover.MoveToDirection(input);

						bool shoot = Input.GetButton("Arrows_Shoot");

						if (shoot)
						{
							player.Weapons.Shoot(player.ProjectileLayer);
						}

						break;
					}
				case(Controller.Gamepad1):
					{
						float horizontal = Input.GetAxis("Gamepad1_Hori");
						float vertical = Input.GetAxis("Gamepad1_Verti");

						Vector3 input = new Vector3(horizontal, 0, vertical);

						player.Mover.MoveToDirection(input);

						bool shoot = Input.GetButton("Gamepad1_Shoot");

						if (shoot)
						{
							player.Weapons.Shoot(player.ProjectileLayer);
						}

						break;
					}
				case(Controller.Gamepad2):
					{
						float horizontal = Input.GetAxis("Gamepad2_Hori");
						float vertical = Input.GetAxis("Gamepad2_Verti");

						Vector3 input = new Vector3(horizontal, 0, vertical);

						player.Mover.MoveToDirection(input);

						bool shoot = Input.GetButton("Gamepad2_Shoot");

						if (shoot)
						{
							player.Weapons.Shoot(player.ProjectileLayer);
						}

						break;
					}
				}
			}
		}
	}
}

