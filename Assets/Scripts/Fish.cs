using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Fish : MonoBehaviour {

	[SerializeField] int fishType;
	[SerializeField] int points;

	SpriteRenderer spriteRenderer;
	float flopTime;
	float flopTimer;

	void Awake () {

		spriteRenderer = this.GetComponentInChildren<SpriteRenderer> ();
		flopTime = Random.Range (0.1f, 0.5f);
		flopTimer = 0;
	}

	void Update () {

		flopTimer += Time.deltaTime;
		if (flopTimer >= flopTime) {

			spriteRenderer.flipY = !spriteRenderer.flipY;
			flopTimer = 0;
		}
	}

	public int GetFishType () {

		return fishType;
	}

	public int GetPoints () {

		return points;
	}
}
