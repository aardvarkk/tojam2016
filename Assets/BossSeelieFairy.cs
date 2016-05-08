using UnityEngine;
using System.Collections;

public class BossSeelieFairy : MonoBehaviour {

	public GameObject SnakeShot;
	public float FireDelay;
	public float FireSpeed;
	public float WaitTime;
	public float TargettedFireTime;
	public float ShotYOffset;
	public float BlastTime;
	public int   BlastShots;
	public float BlastArcDegrees;

	float LastFire = 0;

	enum State {
		None,
		Waiting,
		TargettedFire,
		Blast
	};

	State state;
	float stateEnter;

	void Start() {
		state = State.None;
	}

	void ToState(State state) {
		this.state = state;
		stateEnter = Time.timeSinceLevelLoad;
		LastFire = 0;

		Debug.Log (state);
	}

	void ProcessWaiting() {
		if (Time.timeSinceLevelLoad >= stateEnter + WaitTime) {
			ToState (State.TargettedFire);
			return;
		}
	}

	void ProcessTargettedFire() {
		if (Time.timeSinceLevelLoad >= stateEnter + TargettedFireTime) {
			ToState (State.Blast);
			return;
		}
		
		// We fired too recently
		if (LastFire + FireDelay >= Time.timeSinceLevelLoad)
			return;

		// Get the location of the player so we can aim it
		GameObject p = GameObject.Find("Player");
		if (!p)
			return;

		// We're ready to fire, so do it!
		GameObject shot = GameObject.Instantiate(SnakeShot, transform.position, Quaternion.identity) as GameObject;
		shot.transform.parent = transform;
		shot.transform.position += new Vector3 (0, ShotYOffset, 0);

		// Direct the bullet toward the player
		Vector3 dir = (p.transform.position - transform.position).normalized;
		shot.GetComponent<Projectile> ().SetVelocity (new Vector3 (dir.x * FireSpeed, dir.y * FireSpeed, 0));

		LastFire = Time.timeSinceLevelLoad;
	}

	void ProcessBlast() {
		if (Time.timeSinceLevelLoad >= stateEnter + BlastTime) {
			ToState (State.TargettedFire);
			return;
		}

		if (Time.timeSinceLevelLoad <= LastFire + BlastTime) {
//			Debug.Log (string.Format("Already fired blast! {0} {1} {2}", Time.timeSinceLevelLoad, LastFire, BlastTime));
			return;
		}

//		Debug.Log ("Firing blast!");

		// Fire off the volley!
		for (int i = 0; i < BlastShots; ++i) {
			GameObject shot = GameObject.Instantiate(SnakeShot, transform.position, Quaternion.identity) as GameObject;
			shot.transform.parent = transform;
			shot.transform.position += new Vector3 (0, ShotYOffset, 0);

			// Direct the bullet
			float ang = -90 - BlastArcDegrees / 2 + BlastArcDegrees * i / BlastShots;
			ang *= Mathf.PI / 180;
			shot.GetComponent<Projectile> ().SetVelocity (new Vector3 (Mathf.Cos(ang) * FireSpeed, Mathf.Sin(ang) * FireSpeed, 0));
		}

		LastFire = Time.timeSinceLevelLoad;
	}
		
	void Update () {
		if (!GetComponentInParent<BossMover> ().Alerted)
			return;

		switch (state) {

		case State.None:
			ToState (State.Waiting);
			break;

		case State.Waiting:
			ProcessWaiting ();				
			break;

		case State.TargettedFire:
			ProcessTargettedFire ();
			break;

		case State.Blast:
			ProcessBlast ();
			break;
		}
	}
}
