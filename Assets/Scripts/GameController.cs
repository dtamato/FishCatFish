using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float gameLengthInSeconds;

	[Header("References")]
	[SerializeField] Text countdownText;
	[SerializeField] Text timerText;
	[SerializeField] GameObject[] boatArray;

	float countdownTimer;

	void Start () {

		countdownTimer = 3;
		RemoveNonPlayers ();
		timerText.gameObject.SetActive (false);
		DisableAllInput ();
	}

	void Update () {

		if (countdownTimer > 0) {

			countdownTimer -= Time.deltaTime;
			countdownText.text = (countdownTimer).ToString ("0");

			float currentSize = countdownText.GetComponentInChildren<RectTransform> ().localScale.x;
			float newSize = currentSize - 0.95f * Time.deltaTime;

			if (newSize <= 0) {

				countdownText.GetComponentInChildren<RectTransform> ().localScale = Vector3.one;
			}
			else {

				countdownText.GetComponent<RectTransform> ().localScale = newSize * Vector3.one;
			}

			if (countdownTimer <= 0) {

				countdownText.gameObject.SetActive (false);
				timerText.gameObject.SetActive (true);
				EnableAllInput ();
			}
		}
		else if(gameLengthInSeconds > 0) {
			
			gameLengthInSeconds -= Time.deltaTime;
			int minutes = (int) gameLengthInSeconds / 60;
			int seconds = (int) gameLengthInSeconds % 60;
			timerText.text = minutes.ToString("0") + ": " + seconds.ToString("00");
		}
		else if(gameLengthInSeconds < 0) {

			gameLengthInSeconds = 0;
			// TODO: Stop boats, show menu, calculate scores, determine winner
		}
	}

	void RemoveNonPlayers () {

		// First deactivate all boats
		foreach (GameObject boat in boatArray) {

			boat.SetActive (false);
		}

		// Then activate only the necessary ones
		int playerCount = PlayerPrefs.GetInt ("PlayerCount");
		if(playerCount == 0) { playerCount = 1; }

		for (int i = 0; i < playerCount; i++) {

			boatArray [i].SetActive (true);
		}
	}

	void DisableAllInput () {

		foreach (GameObject boat in boatArray) {

			boat.GetComponentInChildren<BoatInput> ().enabled = false;
		}
	}

	void EnableAllInput () {

		foreach (GameObject boat in boatArray) {

			boat.GetComponentInChildren<BoatInput> ().enabled = true;
		}
	}
}
