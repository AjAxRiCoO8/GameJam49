using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubWorldController : MonoBehaviour
{
    UIController uiController;
    GameObject shop, inventory;

    string switchSceneName;
    //public Activities tapActivity;
    // Use this for initialization
    void Start ()
	{
	    uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        shop = GameObject.Find("Shop");
        inventory = GameObject.Find("Inventory");
        shop.SetActive(false);
        inventory.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
	{
        // All inputs needs to be frame based 
	    TouchInput();

	}

    void FixedUpdate()
    {
        // Checks if fader animation has completed and player clicked on a button
        if (!uiController.fading && switchSceneName != null)
        {
            SceneManager.LoadScene(switchSceneName);
        }
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
                uiController.fadeOutAction = true;
                switchSceneName = "Fighting";
                break;
            case Activities.Training:
                //Add scene on top of this scene
                break;
            case Activities.Exploring:
                //Add scene on top of this scene
                break;
            case Activities.Fishing:
                //Add scene on top of this scene
                uiController.fadeOutAction = true;
                switchSceneName = "Fishing";
                break;
            case Activities.Inventory:
                //Add scene on top of this scene
                if (inventory.activeInHierarchy == false)
                {
                    inventory.SetActive(true);
                }
                else
                {
                    inventory.SetActive(false);
                }
                break;
            case Activities.Shopping:
                //Add scene on top of this scene
                if (shop.activeInHierarchy == false)
                {
                    shop.SetActive(true);
                }
                else
                {
                    shop.SetActive(false);
                }

                break;
        }
        // Reset for the next tap
        tapActivity = Activities.None;
    }
}
