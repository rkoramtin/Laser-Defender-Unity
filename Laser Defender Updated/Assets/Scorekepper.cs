using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scorekepper : MonoBehaviour {
    public static int score=0;
    private Text mytext;
   public void Score(int points)
    {
        score += points;
        mytext.text = score.ToString();

    }
 public static void Reset()
    {
        score = 0;
        
    }
    // Use this for initialization
    void Start () {
       mytext= GetComponent<Text>();
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
