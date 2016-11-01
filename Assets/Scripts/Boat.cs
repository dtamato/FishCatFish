using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Boat : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] int playerID;
	[SerializeField] float movementSpeed;

	[Header("References")]
	[SerializeField] GameObject catPrefab;
	[SerializeField] Text fish1CountText;
	[SerializeField] Text fish2CountText;
	[SerializeField] Text fish3CountText;

	Rigidbody2D rb2d;
	bool isOnWater;
	int fish1Count;
	int fish2Count;
	int fish3Count;
	bool catOnboard;


	void Awake () {

		rb2d = this.GetComponentInChildren<Rigidbody2D>();
		isOnWater = true;
		catOnboard = true;
		fish1Count = 0;
		fish2Count = 0;
		fish3Count = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Water") && catOnboard) {

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

		if(!isOnWater && catOnboard) {
			
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

	public void AddFish(int fish1, int fish2, int fish3) {

		fish1Count += fish1;
		fish2Count += fish2;
		fish3Count += fish3;

		fish1CountText.text = " " + fish1Count.ToString ("00");
		fish2CountText.text = " " + fish2Count.ToString ("00");
		fish3CountText.text = " " + fish3Count.ToString ("00");
	}

	public int GetPlayerID () {

		return playerID;
	}
}
