using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public float FadeTime;

	float SpawnTime;

	// Use this for initialization
	void Start () {
		SpawnTime = Time.timeSinceLevelLoad;	
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color(1, 1, 1, 1 - (Time.timeSinceLevelLoad - SpawnTime) / FadeTime);

		// Kill ourselves if we fade away completely
		if (sr.color.a <= 0)
			Destroy (gameObject);	
	}
}
