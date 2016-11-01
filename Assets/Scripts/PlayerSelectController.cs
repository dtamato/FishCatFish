using Rewired;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerSelectController : MonoBehaviour {

	[SerializeField] int playerID;
	[SerializeField] GameObject playerEnterObject;
	[SerializeField] GameObject characterSelect;
	[SerializeField] GameObject boatSelect;
	[SerializeField] GameObject readyGameObject;

	Player player;
	bool characterSelected;
	bool boatSelected;

	void Awake() {

		player = ReInput.players.GetPlayer (playerID);
		characterSelect.SetActive (false);
		boatSelect.SetActive(false);
		readyGameObject.SetActive(false);
		characterSelected = false;
		boatSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.GetButtonDown ("UISubmit")) {

			if(playerEnterObject.activeSelf) {

				playerEnterObject.SetActive (false);
				characterSelect.SetActive (true);
			}
			else if(!characterSelected) {

				characterSelect.SetActive(false);
				characterSelected = true;
				boatSelect.SetActive(true);
			}
			else if(!boatSelected) {

				boatSelect.SetActive(false);
				boatSelected = true;
				readyGameObject.SetActive(true);
			}
		}
	}
}
