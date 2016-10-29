using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Cat))]
public class CatKeyboardActions : MonoBehaviour {

	Cat cat;


	void Awake () {

		cat = this.GetComponentInChildren<Cat>();
	}

	void Update () {

		Vector2 moveDirection = Vector2.zero;

		// Left-Right
		if(Input.GetKey(KeyCode.A)) {

			moveDirection += new Vector2(-1, 0);
		}
		else if (Input.GetKey(KeyCode.D)) {

			moveDirection += new Vector2(1, 0);
		}

		// Up-Down
		if(Input.GetKey(KeyCode.W)) {

			moveDirection += new Vector2(0, 1);
		}
		else if(Input.GetKey(KeyCode.S)) {

			moveDirection += new Vector2(0, -1);
		}

		// Move Boat
		if(moveDirection != Vector2.zero) {

			cat.MovePosition(moveDirection);
		}

		// Board
		if(Input.GetKeyDown(KeyCode.Space)) {

			cat.Board();
		}
	}
}
