using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    private Text score;

    private GameObject gm;

    // Use this for initialization
    void Start () {
        score = this.gameObject.GetComponent<Text>();
        gm = GameObject.Find("GameMaster");
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + gm.GetComponent<GameMaster>().score.ToString();
	}
}
