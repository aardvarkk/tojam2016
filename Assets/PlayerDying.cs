using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerDying : MonoBehaviour {

	public float DeathWait;
	float deathTriggered;

	// Use this for initialization
	void Start () {
		deathTriggered = Time.timeSinceLevelLoad;	
	}
	
	// Update is called once per frame
	void Update () {
		// Game over!
		if (deathTriggered != 0 && Time.timeSinceLevelLoad >= deathTriggered + DeathWait)
			SceneManager.LoadScene (2);
	}
}
