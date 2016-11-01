using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float gameLengthInSeconds;

	[Header("References")]
	[SerializeField] Text timerText;
	[SerializeField] GameObject[] boatArray;

	void Update () {

		if(gameLengthInSeconds > 0) {
			
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
}
