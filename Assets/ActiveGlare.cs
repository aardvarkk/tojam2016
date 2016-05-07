using UnityEngine;
using System.Collections;

public class ActiveGlare : MonoBehaviour {

	public float LiveTime; // how long the glare should live after being fired (to collide with things)

	float SpawnTime;
		
	// Use this for initialization
	void Start () {
		SpawnTime = Time.timeSinceLevelLoad;
	}

	void OnEnterCollision2D(Collider2D other) {
		Debug.Log ("Glare Collision!");
	}

	// Update is called once per frame
	void Update () {

		// Kill ourselves if our time is over
		if (SpawnTime + LiveTime < Time.timeSinceLevelLoad) {
			Debug.Log ("Destroyed Glare");
			Destroy (gameObject);
		}
	}
}
