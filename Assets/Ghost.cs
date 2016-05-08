using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

	public float UpVelocity;
	public float FadeTime;
	
	float SpawnTime;

	void Start() {
		SpawnTime = Time.timeSinceLevelLoad;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, Time.deltaTime * UpVelocity, 0));
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color(1, 1, 1, 1 - (Time.timeSinceLevelLoad - SpawnTime) / FadeTime);

		// Kill ourselves if we fade away completely
		if (sr.color.a <= 0)
			Destroy (gameObject);
	}
}
