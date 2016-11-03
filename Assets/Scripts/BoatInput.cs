using Rewired;
using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Boat))]
public class BoatInput : MonoBehaviour {

	Boat boat;
	Player player;


	void Awake () {

		boat = this.GetComponentInChildren<Boat>();
		player = ReInput.players.GetPlayer (boat.GetPlayerID ());
	}

	void Update () {

		Vector2 moveDirection = Vector2.zero;

		// Left-Right
		if(player.GetAxisRaw("Horizontal") > 0) {

			moveDirection += new Vector2(1, 0);
		}
		else if (player.GetAxisRaw("Horizontal") < 0) {

			moveDirection += new Vector2(-1, 0);
		}

		// Up-Down
		if(player.GetAxisRaw("Vertical") > 0) {

			moveDirection += new Vector2(0, 1);
		}
		else if(player.GetAxisRaw("Vertical") < 0) {

			moveDirection += new Vector2(0, -1);
		}

		// Move Boat
		if(moveDirection != Vector2.zero) {

			boat.MovePosition(moveDirection);
		}

		// Unboard
		if(player.GetButtonDown("BoardUnboard")) {

			boat.UnboardCat();
		}

		// Boost
		if (player.GetButtonDown ("Boost")) {

			boat.Boost ();
		}
	}
}
