using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Cat : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float movementSpeed;

	Rigidbody2D rb2d;
	GameObject boat;
	float initialMovementSpeed;
	int pointsCollected;
	int fish1Count;
	int fish2Count;
	int fish3Count;

	void Awake () {

		rb2d = this.GetComponentInChildren<Rigidbody2D>();
		initialMovementSpeed = movementSpeed;
		ResetFishAndPoints ();
	}

	void ResetFishAndPoints () {

		pointsCollected = 0;
		fish1Count = 0;
		fish2Count = 0;
		fish3Count = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Fish")) {

			int points = other.GetComponentInChildren<Fish>().GetPoints();
			pointsCollected += points;
			switch (other.GetComponentInChildren<Fish> ().GetFishType ()) {
			case 1:
				fish1Count++;
				initialMovementSpeed *= 0.95f;
				break;
			case 2:
				fish2Count++;
				initialMovementSpeed *= 0.85f;
				break;
			case 3:
				fish3Count++;
				initialMovementSpeed *= 0.75f;
				break;
			}
			Destroy(other.gameObject);
		}
	}

	public void SetBoat (GameObject newBoat) {

		boat = newBoat;
	}

	public void MovePosition (Vector2 direction) {

		rb2d.MovePosition((Vector2)this.transform.position + movementSpeed * direction);
	}

	public void Board () {

		Collider2D boatCollider = boat.GetComponentInChildren<Collider2D>();
		if(this.GetComponentInChildren<Collider2D>().IsTouching(boatCollider)) {

			// TODO: Add points to score
			boat.GetComponentInChildren<Boat>().AddFish(fish1Count, fish2Count, fish3Count);
			ResetFishAndPoints ();
			boat.GetComponentInChildren<Boat>().BoardCat();
			Destroy(this.gameObject);
		}
	}
}
