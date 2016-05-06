using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static float MoveSpeed = 1024f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		transform.Translate (new Vector3 (MoveSpeed * Time.deltaTime * x, MoveSpeed * Time.deltaTime * y, 0));
//		Debug.Log (transform.position.x);
	}
}
