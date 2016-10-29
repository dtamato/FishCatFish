using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Fish : MonoBehaviour {

	[SerializeField] int points;


	public int GetPoints () {

		return points;
	}
}
