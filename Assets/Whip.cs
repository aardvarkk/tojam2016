using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {

	public float Damage;

	void OnTriggerEnter2D(Collider2D other) {

		// Only care about triggering on "enemies" (things we can logically hit)
		// If we don't check this, our whip can collide with our own body, etc.
		if (other.tag != "Enemy")
			return;
		
		Debug.Log ("Whip Collision!");
		Destroy (other.gameObject);
	}

	void Update() {
		
		// If we're not idle, we can't trigger a whip
		if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("IDLE"))
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
		case Compass.Direction.N:
			GetComponent<Animator> ().SetTrigger ("WhipForward");
			break;

		case Compass.Direction.W:
			GetComponent<Animator> ().SetTrigger ("WhipLeft");
			break;

		case Compass.Direction.NW:
			GetComponent<Animator> ().SetTrigger ("WhipUpLeft");
			break;

		case Compass.Direction.E:
			GetComponent<Animator> ().SetTrigger ("WhipRight");
			break;

		case Compass.Direction.NE:
			GetComponent<Animator> ().SetTrigger ("WhipUpRight");
			break;

		// Horse kick?
//		case Compass.Direction.S:
//			break;
//
		}

		Debug.Log ("Whip " + dir.ToString ());

	}
}
