using UnityEngine;
using System.Collections;

public class BloodAreaOfEffect : MonoBehaviour {

	public float Damage;

	void OnCollisionEnter2D(Collision2D other) {
//		Debug.Log (string.Format("Blood COLLISION {0}", other));

		Enemy e = other.collider.GetComponent<Enemy> ();
		if (e)
			e.TakeDamage (Damage);
	}
}
