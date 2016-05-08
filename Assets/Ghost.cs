using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

	public float UpVelocity;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, Time.deltaTime * UpVelocity, 0));
	}
}
