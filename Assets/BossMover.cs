using UnityEngine;
using System.Collections;

public class BossMover : MonoBehaviour {

	public float TopBuffer;

	void Update () {

		float halfHeight = GetComponentInChildren<SpriteRenderer> ().bounds.extents.y;

		// Don't allow ourselves to get less than the camera (stick us to the top once we're found)
		transform.position = new Vector3(
			transform.position.x,
			Mathf.Max(transform.position.y, Camera.main.transform.position.y + Global.ScreenDimension / 2 - halfHeight - TopBuffer),
			transform.position.z
		);
	}
}
