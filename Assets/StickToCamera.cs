using UnityEngine;
using System.Collections;

public class StickToCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector3 (0, Time.deltaTime * Camera.main.GetComponent<CameraMover> ().MoveSpeed, 0));
	}
}
