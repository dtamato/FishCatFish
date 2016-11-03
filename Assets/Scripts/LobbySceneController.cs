using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LobbySceneController : MonoBehaviour {

	[SerializeField] GameObject lobbyReadyObject;

	int playersIn;

	void Awake () {

		playersIn = 0;
	}

	void Update () {

		if (lobbyReadyObject.activeSelf && ReInput.players.GetPlayer(0).GetButtonDown("UIStart")) {

			PlayerPrefs.SetInt ("PlayerCount", playersIn);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}

	public void PlayerAdded () {

		playersIn++;

		if (playersIn > 1) {
			
			lobbyReadyObject.SetActive (true);
		}
	}
}
