using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Cat : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float movementSpeed;

	Rigidbody2D rb2d;
	GameObject boat;
	int pointsCollected;

	void Awake () {

		rb2d = this.GetComponentInChildren<Rigidbody2D>();
		pointsCollected = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Fish")) {

			int points = other.GetComponentInChildren<Fish>().GetPoints();
			pointsCollected += points;
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
			pointsCollected = 0;
			boat.GetComponentInChildren<Boat>().BoardCat();
			Destroy(this.gameObject);
		}
	}
}
