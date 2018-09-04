using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubWorldController : MonoBehaviour
{

    //public Activities tapActivity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        // All inputs needs to be frame based 
	    TouchInput();

	}

    void TouchInput()
    {
        // Could be used for gesture navigation
        //Touch touch = Input.GetTouch(0);
    }

    // Scene switcher when player touch a button
    public void SceneSwitcher(Activities tapActivity)
    {
        switch (tapActivity)
        {
            case Activities.Fighting:
                //Add scene on top of this scene
                SceneManager.LoadScene(1);
                break;
            case Activities.Training:
                //Add scene on top of this scene
                break;
        }
        // Reset for the next tap
        tapActivity = Activities.None;
    }
}
