using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static float BaseMoveSpeed = CameraMover.MoveSpeed;
	static float MoveSpeed = 512f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		transform.Translate (new Vector3 (
			Time.deltaTime * MoveSpeed * x, 
			Time.deltaTime * (BaseMoveSpeed + MoveSpeed * y), 
			0));
//		Debug.Log (transform.position.x);
	}
}
