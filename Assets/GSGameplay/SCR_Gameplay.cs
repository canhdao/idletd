using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Gameplay : MonoBehaviour {
	public static float SCREEN_WIDTH = 0;
	public static float SCREEN_HEIGHT = 0;

	// Use this for initialization
	void Start () {
		SCREEN_HEIGHT = GetComponent<Camera>().orthographicSize * 2;
		SCREEN_WIDTH = (float)Screen.width / Screen.height * SCREEN_HEIGHT;

		GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");

		foreach (GameObject p in paths) {
			p.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
