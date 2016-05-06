﻿using UnityEngine;
using System.Collections;

public class Farmer : MonoBehaviour {

	static float MoveSpeed = 256f;
	static float MeleeRange = 180f;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool alerted = true;

		if (alerted) {

			Transform pt = GameObject.Find ("Player").transform;
			Vector3 delta = (pt.position - transform.position);

			// Turn to face the player (in one of eight cardinal directions)
			Compass.Direction dir = Compass.GetDirection(delta);
//			Debug.Log (string.Format ("Player is in direction {0}", dir.ToString ()));
				
			// In melee range?
			if (delta.magnitude <= MeleeRange) {
				// Attack!
			} 
			// Outside of melee range, so try to move into range
			else {
				transform.Translate (Time.deltaTime * MoveSpeed * delta.normalized);
			}

//			Debug.Log (string.Format ("Player is at {0} and I'm at {1}", pt.position, transform.position));
		}
	}
}