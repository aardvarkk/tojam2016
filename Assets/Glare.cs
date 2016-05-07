using UnityEngine;
using System.Collections;

public class Glare : MonoBehaviour {

	public GameObject ActiveGlare;

	public float ChargeTime; // Amount of time it takes to charge the weapon up
	float LastAttack; // Last time we used this attack (we can only use it once in a while)

	// Use this for initialization
	void Start () {
		// Want to do the full charge time when we start (not be able to fire this right away)
		LastAttack = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
	
		// We are able to fire the glare!
		if (Input.GetButtonDown("Glare") && LastAttack + ChargeTime <= Time.timeSinceLevelLoad) {
			GameObject ag = GameObject.Instantiate (ActiveGlare, transform.position, Quaternion.identity) as GameObject;
			LastAttack = Time.timeSinceLevelLoad;
		}
	}
}
