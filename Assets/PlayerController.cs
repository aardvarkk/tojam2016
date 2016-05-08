using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MaxPercX;
	public float MaxPercY;
	public float MoveSpeed;
	public float VelocityX, VelocityY; // accessible outside of us

	public int KillStacks = 0; // how many kills we've stacked -- once we get to a certain number we can throw blood

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Debug.Log (string.Format("Collision with {0}", other.name));
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		VelocityX = MoveSpeed * x;
		VelocityY = Camera.main.GetComponent<CameraMover>().MoveSpeed + MoveSpeed * y;
			
		transform.Translate (new Vector3 (
			Time.deltaTime * VelocityX, 
			Time.deltaTime * VelocityY, 
			0));

		// Lock player to edges of camera
		Vector3 lockedPos = transform.position;

		// Limiting player in X coords
		lockedPos.x = Mathf.Min (lockedPos.x,  Global.ScreenDimension / 2 * MaxPercX);
		lockedPos.x = Mathf.Max (lockedPos.x, -Global.ScreenDimension / 2 * MaxPercX);

		// Limiting player in Y coords
		lockedPos.y = Mathf.Max (lockedPos.y, Camera.main.transform.position.y - (Global.ScreenDimension / 2 * MaxPercY));
		lockedPos.y = Mathf.Min (lockedPos.y, Camera.main.transform.position.y + (Global.ScreenDimension / 2 * MaxPercY));

		transform.position = lockedPos;
			
//		Debug.Log (string.Format("Player at {0}", transform.position));
	}
}
