using UnityEngine;
using System.Collections;

public class Farmer : MonoBehaviour {

	public float AlertRange;
	public float MoveSpeed;
	public GameObject BloodPool;
	public GameObject BloodSpray;
	public AudioClip DeathSound;
		
	bool alerted;
	bool dead;
	Compass.Direction facing;

	// Use this for initialization
	void Start () {
		alerted = false;
		dead = false;
		facing = Compass.Direction.W;
	}

	public void Die() {
		transform.localScale = new Vector3 (1, -1, 1);
		GetComponent<Animator> ().enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		GameObject.Instantiate (BloodPool, transform.position, Quaternion.identity);

		// Show the blood spray based on which way the dude was facing
		GameObject spray = GameObject.Instantiate (BloodSpray, transform.position, Quaternion.identity) as GameObject;

		int xScale = 1;
		switch (facing) {
		case Compass.Direction.SE:
		case Compass.Direction.E:
		case Compass.Direction.NE:
			xScale = -1;
			break;

		case Compass.Direction.N:
		case Compass.Direction.S:
			xScale = Random.value >= 0.5 ? 1 : -1;
			break;
		}
		spray.transform.localScale = new Vector3 (xScale, 1, 1);

		GameObject.Find ("SoundPlayer").GetComponent<AudioSource> ().PlayOneShot (DeathSound);

		dead = true;
	}

	// Update is called once per frame
	void Update () {

		if (dead)
			return;
		
		// Move into alert if player comes close enough
		GameObject p = GameObject.Find("Player");
		if (!p)
			return;
		
		if ((p.transform.position - transform.position).magnitude <= AlertRange)
			alerted = true;

		if (alerted) {

			Transform pt = p.transform;
			Vector3 delta = (pt.position - transform.position);

			// Turn to face the player (in one of eight cardinal directions)
			facing = Compass.GetDirection(delta);

			switch (facing) {
			case Compass.Direction.SE:
			case Compass.Direction.E:
			case Compass.Direction.NE:
				transform.localScale = new Vector3 (-1, 1, 1);
				break;
			default:
				transform.localScale = new Vector3 (+1, 1, 1);
				break;
			}

//			Debug.Log (string.Format ("Player is in direction {0}", dir.ToString ()));
				
			// In melee range?
//			if (delta.magnitude <= MeleeRange) {
				// Attack!
//			} 
			// Outside of melee range, so try to move into range
//			else {
				transform.Translate (Time.deltaTime * MoveSpeed * delta.normalized);
//			}

//			Debug.Log (string.Format ("Player is at {0} and I'm at {1}", pt.position, transform.position));
		}
	}
}
