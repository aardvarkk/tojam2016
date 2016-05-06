using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public static float MoveSpeed = 128f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, Time.deltaTime * MoveSpeed, 0));
	}
}
