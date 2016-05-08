using UnityEngine;
using System.Collections;

public class DestroyWhenInvisible : MonoBehaviour {
	void OnBecameInvisible() {
		Destroy (gameObject);	
	}
}
