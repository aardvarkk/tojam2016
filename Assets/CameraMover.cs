using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public float MoveSpeed;

	void Update () {
		transform.Translate (new Vector3 (0, Time.deltaTime * MoveSpeed, 0));

//		Debug.Log (string.Format("Camera {0}", transform.position));
	}
}
