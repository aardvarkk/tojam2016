using UnityEngine;
using System.Collections;

public class AttackWhip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Whip")) {
			// Measure the attack direction - if it's invalid, attack forward
			float x = Input.GetAxisRaw("Horizontal");
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
			case Compass.Direction.S:
			case Compass.Direction.SE:
				dir = Compass.Direction.N;
				break;
			}

			Debug.Log ("Whip " + dir.ToString());
		}
	}
}
