using Rewired;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class PlayerSelectController : MonoBehaviour {

	[SerializeField] int playerID;
	[SerializeField] GameObject playerEnterObject;
	[SerializeField] GameObject characterSelect;

	Player player;

	void Awake() {

		player = ReInput.players.GetPlayer (playerID);
		characterSelect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.GetButtonDown ("UISubmit")) {

			playerEnterObject.SetActive (false);
			characterSelect.SetActive (true);
		}
	}
}
