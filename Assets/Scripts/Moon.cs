using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Moon : MonoBehaviour {

	[SerializeField] int minMoonSize;
	[SerializeField] int maxMoonSize;

	[SerializeField] float minIdleSeconds;
	[SerializeField] float maxIdleSeconds;

	[SerializeField] float sizeChangeSpeed;

	[SerializeField] Water water;

	bool changingSize = false;
	float currentSize;
	float newSize;

	// Use this for initialization
	void Start () {
	
		currentSize = this.transform.localScale.x;
		StartCoroutine (SetNewSize ());
	}

	void Update () {

		if (changingSize) {

			// Check if moon size should stop changing
			if (Mathf.Abs(currentSize - newSize) <= 0.01f) {

				if(newSize == 1) { currentSize = 1; }
				else if(newSize == 3) { currentSize = 3; }
				this.transform.localScale = new Vector3 (currentSize, currentSize, 1);

				changingSize = false;
				StartCoroutine (SetNewSize ());
			}
			else if (currentSize != newSize) {

				currentSize = Mathf.Lerp (currentSize, newSize, sizeChangeSpeed * Time.deltaTime);
				this.transform.localScale = new Vector3 (currentSize, currentSize, 1);
			}
		}
	}

	public IEnumerator SetNewSize () {

		yield return new WaitForSeconds (Random.Range (minIdleSeconds, maxIdleSeconds));

		newSize = (currentSize == 1) ? 3 : 1;
		changingSize = true;
		water.ChangeTide();
	}
}
