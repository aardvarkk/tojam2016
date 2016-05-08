using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodBarManager : MonoBehaviour {

	public Sprite[] FillSprites; // sprites used to fill
	public GameObject BloodIcon; // prefab for making the blood icons

	static int ThrowBloodStacks = 5; // how many stacks required to throw blood
	int TotalStacks = 0; // how many stacks we currently have
	int CurDropFill = 0;

	List<GameObject> BloodIcons; // our actual icons

	public bool CanThrowBlood() {
		return TotalStacks >= ThrowBloodStacks;
	}

	public void AddKill() {
		++TotalStacks;
//		Debug.Log ("Got Kill!");

		++CurDropFill;
		// We've filled a drop!
		if (CurDropFill > ThrowBloodStacks) {
			AddDrop ();
			CurDropFill = 1;
		} 
			
		GameObject lastIcon = BloodIcons [BloodIcons.Count - 1];

		lastIcon.GetComponent<SpriteRenderer> ().sprite = FillSprites [CurDropFill];
	}

	void AddDrop() {
		GameObject bi = GameObject.Instantiate (BloodIcon, transform.position, Quaternion.identity) as GameObject;
		bi.transform.parent = transform;
		bi.transform.Translate (new Vector3 (BloodIcons.Count * 20, 0, 0));
		BloodIcons.Add (bi);
	}

	// Use this for initialization
	void Start () {
		// Add our first blood icon
		BloodIcons = new List<GameObject>();
		AddDrop ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
