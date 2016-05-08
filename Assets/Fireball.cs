using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public AudioClip FireballSound;

	// Use this for initialization
	void Start () {
		GameObject.Find ("SoundPlayer").GetComponent<AudioSource> ().PlayOneShot (FireballSound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
