using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	[SerializeField] int minFishToSpawn;
	[SerializeField] int maxFishToSpawn;
	[SerializeField] GameObject[] fishPrefabsArray;

	float initialHeight;
	bool isHighTide;
	bool loweringTide;
	bool raisingTide;

	float minXPosition;
	float maxXPosition;
	float minYPosition;
	float maxYPosition;

	void Awake () {

		initialHeight = this.transform.localScale.y;
		isHighTide = true;
		loweringTide = false;
		raisingTide = false;

		Bounds bounds = this.GetComponentInChildren<BoxCollider2D>().bounds;
		minXPosition = this.transform.position.x - bounds.extents.x;
		maxXPosition = this.transform.position.x + bounds.extents.x;
		minYPosition = bounds.center.y - bounds.extents.y;
		maxYPosition = bounds.center.y + bounds.extents.y - 2;
	}

	void Update () {

		if(loweringTide) {
			
			LowerTide();
		}
		else if(raisingTide) {

			RaiseTide();
		}
	}

	void LowerTide () {

		float newY = 0.995f * this.transform.localScale.y;
		this.transform.localScale = new Vector3(this.transform.localScale.x, newY, 1);

		if(this.transform.localScale.y <= 0.01f) {

			this.transform.localScale = new Vector3(this.transform.localScale.x, 0.01f, 0);
			loweringTide = false;
			isHighTide = false;
		}
	}

	void RaiseTide () {

		float newY = 1.01f * this.transform.localScale.y;
		this.transform.localScale = new Vector3(this.transform.localScale.x, newY, 1);

		if(this.transform.localScale.y > initialHeight) {

			this.transform.localScale = new Vector3(this.transform.localScale.x, initialHeight, 1);;
			raisingTide = false;
			isHighTide = true;
		}
	}

	public void ChangeTide () {

		if(isHighTide) {

			loweringTide = true;
			SpawnFish();
		}
		else {

			raisingTide = true;
		}
	}

	void SpawnFish () {

		int fishToSpawn = Random.Range(minFishToSpawn, maxFishToSpawn);

		for(int i = 0; i < fishToSpawn; i++) {

			GameObject fishType = fishPrefabsArray[Random.Range(0, fishPrefabsArray.Length)];

			Vector3 fishLocation = new Vector3(Random.Range(minXPosition, maxXPosition),
				Random.Range(minYPosition, maxYPosition), 0);

			Instantiate(fishType, fishLocation, Quaternion.identity);
		}
	}
}