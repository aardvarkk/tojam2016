using UnityEngine;
using System.Collections;

public class BossSeelieFairy : MonoBehaviour {

	public GameObject SnakeShot;
	public float FireDelay;
	float LastFire = 0;
		
	void Update () {
		if (!GetComponentInParent<BossMover> ().Alerted)
			return;

		// We fired too recently
		if (LastFire + FireDelay >= Time.timeSinceLevelLoad)
			return;

		Debug.Log ("Seelie Fairy ANGRY!");

		// We're ready to fire, so do it!
		GameObject shot = GameObject.Instantiate(SnakeShot, transform.position, Quaternion.identity) as GameObject;
		shot.GetComponent<Projectile> ().SetVelocity (new Vector3 (0, -32, 0));

		LastFire = Time.timeSinceLevelLoad;
	}
}
