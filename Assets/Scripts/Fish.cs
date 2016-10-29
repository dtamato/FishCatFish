using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Fish : MonoBehaviour {

	[SerializeField] int fishType;
	[SerializeField] int points;


	public int GetFishType () {

		return fishType;
	}

	public int GetPoints () {

		return points;
	}
}
