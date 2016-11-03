using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class DontDestroyOnLoad : MonoBehaviour {

	void Awake () {

		DontDestroyOnLoad (this);
	}
}
