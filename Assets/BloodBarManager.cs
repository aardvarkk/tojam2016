using UnityEngine;
using System.Collections;

public class BloodBarManager : MonoBehaviour {

	public GameObject BloodIcon; // prefab for making the blood icons

	static int ThrowBloodStacks = 5; // how many stacks required to throw blood
	int TotalStacks = 0; // how many stacks we currently have
	int CurDropFill = 0;

//	ArrayList<GameObject> BloodIcons; // our actual icons

	public bool CanThrowBlood() {
		return TotalStacks >= ThrowBloodStacks;
	}

	public void AddKill() {
		++TotalStacks;
//		Debug.Log ("Got Kill!");

		switch (CurDropFill) {
		case 0:
			
			break;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
