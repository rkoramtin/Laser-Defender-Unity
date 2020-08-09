using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = Scorekepper.score.ToString();
        Scorekepper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
