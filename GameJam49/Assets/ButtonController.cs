using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    HubWorldController hubWorldController;
    public Activities activity;
    // Use this for initialization
    void Start ()
    {
        hubWorldController = GameObject.Find("HubWorldManager").GetComponent<HubWorldController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PressedButton()
    {
        hubWorldController.SceneSwitcher(activity);
    }
}
