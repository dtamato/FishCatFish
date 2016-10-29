using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Boat : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float movementSpeed;

	[Header("References")]
	[SerializeField] GameObject catPrefab;

	Rigidbody2D rb2d;
	bool isOnWater;

	// Cat Stuff
	bool catOnboard;

	void Awake () {
	
		rb2d = this.GetComponentInChildren<Rigidbody2D>();
		isOnWater = true;
		catOnboard = true;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Water")) {

			isOnWater = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {

		//Debug.Log("other: " + other.gameObject.name);

		if(other.CompareTag("Water")) {

			isOnWater = false;
		}
	}
		
	public void MovePosition (Vector2 direction) {

		if(isOnWater) {

			rb2d.MovePosition((Vector2)this.transform.position + movementSpeed * direction);
		}
	}

	public void UnboardCat () {

		if(catOnboard) {
			
			GameObject cat = Instantiate(catPrefab, this.transform.position, Quaternion.identity) as GameObject;
			cat.GetComponent<Cat>().SetBoat(this.gameObject);
			catOnboard = false;
			FadeBoat();
		}
	}

	// Called from Cat.cs
	public void BoardCat () {

		catOnboard = true;
		UnfadeBoat();
	}

	void FadeBoat () {

		SpriteRenderer[] sprites = this.GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer sprite in sprites) {

			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
		}
	}

	void UnfadeBoat () {

		SpriteRenderer[] sprites = this.GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer sprite in sprites) {

			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1.0f);
		}
	}
}
