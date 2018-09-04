using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text hpText,staText,strText;
    Character characterController;

    //List<int> statNumberList = new List<int>();
    // Use this for initialization
    void Start ()
	{
	    characterController = GameObject.Find("Player").GetComponent<Character>();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    UpdateText();
	}

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateText()
    {
        hpText.text = "HP: " + Mathf.FloorToInt(characterController.health);
        staText.text = "Sta: " + Mathf.FloorToInt(characterController.stamina);
        strText.text = "Str: " + Mathf.FloorToInt(characterController.strength);
    }

    void GetStats()
    {

    }
}
