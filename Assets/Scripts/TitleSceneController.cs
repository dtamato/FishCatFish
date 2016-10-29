using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TitleSceneController : MonoBehaviour {

	[SerializeField] Text daveText1;
	[SerializeField] Text daveText2;
	[SerializeField] Text rebText1;
	[SerializeField] Text rebText2;
	[SerializeField] float nameTextBlinkSpeed;

	float timer;

	void Start () {
	
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
	}
}
