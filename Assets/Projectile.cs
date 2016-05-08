using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 Velocity;

	public void SetVelocity(Vector3 vel) {
		Velocity = vel;
	}

	// Update is called once per frame
	void Update () {
		//		Debug.Log (string.Format ("Projectile Pos: {0}", transform.position));

		// Adjust position based on velocity
		transform.Translate(Time.deltaTime * Velocity);

		// Adjust velocity based on gravity and time (if we've been given a Z velocity)
		if (Velocity.z != 0) {
			Velocity.z += -Gravity.Z * Time.deltaTime;

			// If we've hit the ground, destroy ourselves (we've hit the ground)
			if (transform.position.z <= 0)
				Destroy (gameObject);
		}
	}

}
