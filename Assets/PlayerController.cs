using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static float MoveSpeed = 512f;
	public float VelocityX, VelocityY; // accessible outside of us

	public int KillStacks = 0; // how many kills we've stacked -- once we get to a certain number we can throw blood
	public static int ThrowBloodStacks = 0; // how many stacks required to throw blood

	static float BaseMoveSpeed = CameraMover.MoveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		VelocityX = MoveSpeed * x;
		VelocityY = (BaseMoveSpeed + MoveSpeed) * y;
			
		transform.Translate (new Vector3 (
			Time.deltaTime * VelocityX, 
			Time.deltaTime * (BaseMoveSpeed + MoveSpeed * y), 
			0));

		// Lock player to edges of camera
		Vector3 lockedPos = transform.position;
		lockedPos.x = Mathf.Min (transform.position.x, Global.ScreenDimension / 2);
		transform.position = lockedPos;
			
		Debug.Log (transform.position.x);
	}
}
