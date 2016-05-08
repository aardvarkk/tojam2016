﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AnyKeySwitch : MonoBehaviour {

	public int SwitchTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			SceneManager.LoadScene (SwitchTo);
		}	
	}
}