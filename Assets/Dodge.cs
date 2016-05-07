using UnityEngine;
using System.Collections;

public class Dodge : MonoBehaviour {

	public float DodgeRefreshTime; // how long between dodges

	float LastDodge;

	// Use this for initialization
	void Start () {
		LastDodge = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		// Triggered a dodge!
		if (Input.GetButtonDown ("Dodge") && LastDodge + DodgeRefreshTime <= Time.timeSinceLevelLoad) {
			Debug.Log ("Dodged!");
			LastDodge = Time.timeSinceLevelLoad;
		}
	}
}
