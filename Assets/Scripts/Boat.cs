using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
	bool catOnboard;
	bool isBoosting;
	int fish1Count;
	int fish2Count;
	int fish3Count;


	void Awake () {

		rb2d = this.GetComponentInChildren<Rigidbody2D>();
		isOnWater = true;
		catOnboard = true;
		isBoosting = false;
		fish1Count = 0;
		fish2Count = 0;
		fish3Count = 0;
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Water") && catOnboard) {

			isOnWater = true;
		}
		else if (other.CompareTag ("Boat") && isBoosting) {

			Camera.main.GetComponentInChildren<CameraEffects> ().ShakeCamera ();
			other.GetComponentInChildren<Boat> ().KnockFishOut ();
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

	#region Boosting
	public void Boost () {

		if (isOnWater && !isBoosting) {

			isBoosting = true;
			rb2d.MovePosition(this.transform.position + 2 * this.transform.right);
			StartCoroutine (BoostCooldown ());
		}
	}

	IEnumerator BoostCooldown () {

		yield return new WaitForSeconds (0.5f);
		isBoosting = false;
	}

	public void KnockFishOut () {

		int fish1Out = Random.Range (2, 4);
		int fish2Out = Random.Range (0, 3);
		int fish3Out = Random.Range (0, 2);

		if (fish1Count >= fish1Out) {

			fish1Count -= fish1Out;
		}

		if (fish2Count >= fish2Out ) {

			fish2Count -= fish2Out;
		}

		if (fish3Count > fish3Out) {

			fish3Count -= fish3Out;
		}
	}
	#endregion

	public void UnboardCat () {

		if(!isOnWater && catOnboard) {
			
			GameObject cat = Instantiate(catPrefab, this.transform.position - Vector3.up, Quaternion.identity) as GameObject;
			cat.GetComponent<Cat>().SetBoat(this.gameObject);
			cat.GetComponent<Cat> ().SetPlayerID (playerID);
			catOnboard = false;
			FadeBoat();
		}
	}

	#region Fishing
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
	#endregion

	public int GetPlayerID () {

		return playerID;
	}
}
