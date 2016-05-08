using UnityEngine;
using System.Collections;

public class BossSeelieFairy : MonoBehaviour {

	public GameObject SnakeShot;
	public float FireDelay;
	public float FireSpeed;

	float LastFire = 0;
		
	void Update () {
		if (!GetComponentInParent<BossMover> ().Alerted)
			return;

		// We fired too recently
		if (LastFire + FireDelay >= Time.timeSinceLevelLoad)
			return;

//		Debug.Log ("Seelie Fairy ANGRY!");

		// Get the location of the player so we can aim it
		GameObject p = GameObject.Find("Player");
		if (!p)
			return;
		
		// We're ready to fire, so do it!
		GameObject shot = GameObject.Instantiate(SnakeShot, transform.position, Quaternion.identity) as GameObject;

		Vector3 dir = (p.transform.position - transform.position).normalized;

		shot.GetComponent<Projectile> ().SetVelocity (new Vector3 (dir.x * FireSpeed, dir.y * FireSpeed + Camera.main.GetComponent<CameraMover>().MoveSpeed, 0));

		LastFire = Time.timeSinceLevelLoad;
	}
}
