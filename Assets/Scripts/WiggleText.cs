using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class WiggleText : MonoBehaviour {

	[SerializeField] int rotationDirection = 1;
	[SerializeField] float rotationSpeed = 20;

	float timer;

	void Awake () {

		timer = 0;
	}

	void Update () {

		timer += Time.deltaTime;

		if (timer >= 1) {

			rotationDirection *= -1;
			timer = 0;
		}

		this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 0, rotationDirection * 10), rotationSpeed * Time.deltaTime);
	}
}
