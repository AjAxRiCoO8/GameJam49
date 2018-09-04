using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    Character playChar;
    GameObject gpParent;
    Text gpText;

    // Use this for initialization
    void Start () {
        playChar = GameObject.Find("Player").GetComponent<Character>();
        gpParent = GameObject.FindGameObjectWithTag("CurrentGold");
        gpText = gpParent.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        gpText.text = "Current Gold: " + playChar.gp;
	}
}
