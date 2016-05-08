using UnityEngine;
using System.Collections;

public class Whip : MonoBehaviour {

	public float Damage;

	void OnTriggerEnter2D(Collider2D other) {

		// Only care about triggering on "enemies" (things we can logically hit)
		// If we don't check this, our whip can collide with our own body, etc.
		if (other.tag != "Enemy")
			return;
		
//		Debug.Log (string.Format("Whip Collision with {0}!", other.name));

		// Only care if it's an enemy
		Enemy e = other.gameObject.GetComponentInParent<Enemy> ();
		if (!e)
			return;

		// Do our damage!
		e.Health -= Damage;

//		Debug.Log (string.Format ("Reduced health to {0}", e.Health));

		// If we can reduce the health bar, do it!
		Transform t = other.transform.parent.Find("HealthBarOverlay").Find("HealthBarPivot");
		if (t)
			t.localScale = new Vector3(e.Health / e.StartHealth, 1, 1);

		// If we killed it, great!
		if (e.Health <= 0) 
			Destroy (other.transform.parent.gameObject);
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

//		Debug.Log ("Whip " + dir.ToString ());

	}
}
