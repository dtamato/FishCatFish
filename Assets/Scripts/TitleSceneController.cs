using Rewired;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class TitleSceneController : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float nameTextBlinkSpeed;

	[Header("References")]
	[SerializeField] Text daveText1;
	[SerializeField] Text daveText2;
	[SerializeField] Text rebText1;
	[SerializeField] Text rebText2;

	float timer;

	void Start () {
	
		PlayerPrefs.SetInt ("PlayerCount", 0);
		timer = 0;
		daveText2.enabled = false;
		rebText2.enabled = false;
	}

	void Update () {
	
		timer += Time.deltaTime;
		if (timer >= nameTextBlinkSpeed) {

			daveText1.enabled = !daveText1.enabled;
			daveText2.enabled = !daveText2.enabled;
			rebText1.enabled = !rebText1.enabled;
			rebText2.enabled = !rebText2.enabled;
			timer = 0;
		}

		if (ReInput.players.GetPlayer (0).GetButtonDown ("UIStart")) {

			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}
