using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoremanager : MonoBehaviour {

	public static int score;

	Text countText;

	// Use this for initialization
	void Start () {

		countText = GetComponent <Text> ();
		//score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		countText.text = "Score: " + score;


	
	}
}
