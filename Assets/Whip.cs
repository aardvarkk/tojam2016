using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {

	public static float AttackDuration = 0.2f;

	float LastAttack = 0;

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("COLLISION!");

		Destroy (other.gameObject);
	}

	void Update() {
		// Are we currently attacking? If so, we want to pay attention to the whip collisions
		bool whipping = LastAttack + AttackDuration >= Time.timeSinceLevelLoad;
		GetComponentInChildren <BoxCollider2D> ().enabled = whipping;

		// If we're whipping, we don't care about the rest of this stuff
		if (whipping)
			return;

		// Not trying to whip, so we don't care!
		if (!Input.GetButtonDown ("Whip"))
			return;

		// Measure the attack direction - if it's invalid, attack forward
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		// Default attack north if no keys are being held
		Compass.Direction dir;
		if (x == 0 && y == 0) {
			dir = Compass.Direction.N;
		} else {
			dir = Compass.GetDirection (new Vector3 (x, y, 0));
		}

		// Don't allow attacks behind you
		switch (dir) {
		case Compass.Direction.SW:
			dir = Compass.Direction.W;
			break;

		// Horse kick?
		case Compass.Direction.S:
			break;

		case Compass.Direction.SE:
			dir = Compass.Direction.E;
			break;
		}

		// Set the direction of our strike based on the compass direction
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Compass.GetAngle(dir) - 90));
			
		// Mark our last attack time
		LastAttack = Time.timeSinceLevelLoad;

		Debug.Log ("Whip " + dir.ToString ());
	}
}
