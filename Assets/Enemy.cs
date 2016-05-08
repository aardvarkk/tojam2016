using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject Ghost;
	public float StartHealth;
	public float Health;

	// Use this for initialization
	void Start () {
		Health = StartHealth;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (string.Format("{0} {1}", Health, name));
	}

	// Called if our health gets too low
	// We use this callback to give the player more stacks on the bloodbar
	public void Kill() {
		GameObject.Find ("BloodBarManager").GetComponent<BloodBarManager>().AddKill();

		// Spawn a ghost, blood pool, blood spray and call farmer die to flip the sprite
		if (Ghost) {
			GetComponent<Farmer> ().Die();
			GameObject.Instantiate (Ghost, transform.position, Quaternion.identity);
		} 
		// Killed the boss! Go to victory screen!
		else {
			SceneManager.LoadScene (3);
		}
	}
}
