using UnityEngine;
using System.Collections;

public class BossMover : MonoBehaviour {

	public float TopBuffer;
	public bool Alerted;

	void Update () {

		float halfHeight = GetComponentInChildren<SpriteRenderer> ().bounds.extents.y;
		float yLimit = Camera.main.transform.position.y + Global.ScreenDimension / 2 - halfHeight - TopBuffer;

		// Don't allow ourselves to get less than the camera (stick us to the top once we're found)
		transform.position = new Vector3(
			transform.position.x,
			Mathf.Max(transform.position.y, yLimit),
			transform.position.z
		);

		Alerted = transform.position.y <= yLimit;
	}
}
