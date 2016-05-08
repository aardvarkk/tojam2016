using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RanOutOfLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// We ran out of level! You lose!
		if (transform.position.y + Global.ScreenDimension / 2 >= GameObject.Find ("FarthestPoint").transform.position.y) {
			SceneManager.LoadScene (2);
		}
	}
}
