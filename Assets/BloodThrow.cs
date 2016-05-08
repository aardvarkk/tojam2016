using UnityEngine;
using System.Collections;

public class BloodThrow : MonoBehaviour {

	public GameObject ThrownBlood;

	public float MaxThrowVelocity; // fastest in-game velocity for blood throw
	public float MinThrowVelocity; // slowest (shortest) blood throw
	public float MaxThrowHoldTime; // if we're still holding after this time, we'll throw the blood the farthest
	public int ThrowBloodStacks = 0; // how many stacks required to throw blood

	float triggerTime = 0;

	// Update is called once per frame
	void Update () {

		PlayerController pc = GetComponent<PlayerController> ();

		// Trying to start throwing blood
		// We can only throw blood if we have enough stacks
		// And if we don't have active blood being thrown (triggerTime must be reset to 0)
		if (Input.GetButtonDown ("ThrowBlood") && pc.KillStacks >= ThrowBloodStacks && triggerTime == 0) {
			Debug.Log ("Throwing Blood!");
			triggerTime = Time.timeSinceLevelLoad;
			return;
		}

		// We're charging something up!
		if (triggerTime != 0) {

			// How long we've been charging up the toss
			float throwHoldTime = Time.timeSinceLevelLoad - triggerTime;
				
			// We either let go OR we charged up past the max!
			if (Input.GetButtonUp ("ThrowBlood") || throwHoldTime >= MaxThrowHoldTime) {

				// Set X and Y velocity based on direction of axes at time of release
				float x = Input.GetAxisRaw("Horizontal");
				float y = Input.GetAxisRaw("Vertical");
				float throwVelMag = (throwHoldTime / MaxThrowHoldTime) * (MaxThrowVelocity - MinThrowVelocity) + MinThrowVelocity;

				// Just throw forward if no direction given
				if (x == 0 && y == 0)
					y = 1;
				
				Vector3 throwVel = new Vector3 (x, y, 0).normalized;
				throwVel *= throwVelMag;

				// Our "up" speed is based solely on the chargeup time
				throwVel.z = throwVelMag;

				// We add to X and Y speed based on our player movement so we throw relative to our movement velocity
				throwVel.x += pc.VelocityX;
				throwVel.y += pc.VelocityY;

				// Instantiate some thrown blood and start it at our position
				GameObject b = GameObject.Instantiate(ThrownBlood, transform.position, Quaternion.identity) as GameObject;
				b.GetComponent<ParticleSystemRenderer> ().sortingOrder = 4;
				b.GetComponent<Projectile> ().SetVelocity (throwVel);

//				Debug.Log ("Threw Blood!");

				// Reset for next throw
				triggerTime = 0;
			}
		}
	}
}
