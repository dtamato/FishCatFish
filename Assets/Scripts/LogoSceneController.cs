using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LogoSceneController : MonoBehaviour {

	[Header("Parameters")]
	[SerializeField] float logoFadeInSpeed;
	[SerializeField] float overlayFadeInSpeed;
	[SerializeField] string sceneToLoad;

	[Header("References")]
	[SerializeField] SpriteRenderer logo;
	[SerializeField] SpriteRenderer overlay;

	bool fadingInlogo;
	bool fadingInOverlay;

	// Use this for initialization
	void Start () {
	
		logo.color = new Color (1, 1, 1, 0);
		fadingInlogo = true;
		fadingInOverlay = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (fadingInlogo) {

			float logoAlpha = logo.color.a;
			logoAlpha += logoFadeInSpeed * Time.deltaTime;
			logo.color = new Color (1, 1, 1, logoAlpha);

			if (logoAlpha >= 1) {

				fadingInlogo = false;
				fadingInOverlay = true;
			}
		}
		else if (fadingInOverlay) {

			float overlayAlpha = overlay.color.a;
			overlayAlpha += overlayFadeInSpeed * Time.deltaTime;
			overlay.color = new Color (0, 0, 0, overlayAlpha);

			if (overlayAlpha >= 1) {

				fadingInOverlay = false;
				SceneManager.LoadScene (sceneToLoad);
			}
		}
	}
}
