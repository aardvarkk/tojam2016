﻿using UnityEngine;
using System.Collections;

public class Farmer : MonoBehaviour {

	public float AlertRange;
	public float MoveSpeed;
		
	bool alerted;
	bool dead;

	// Use this for initialization
	void Start () {
		alerted = false;
		dead = false;
	}

	public void Die() {
		transform.localScale = new Vector3 (1, -1, 1);
		GetComponent<Animator> ().enabled = false;
		GetComponent<Collider2D> ().enabled = false;
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
			Compass.Direction dir = Compass.GetDirection(delta);

			switch (dir) {
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
