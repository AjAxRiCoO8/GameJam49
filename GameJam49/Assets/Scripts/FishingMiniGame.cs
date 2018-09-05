using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishingMiniGame : MonoBehaviour {
    Character playChar;
    Inventory inv;
    GameObject pole, fish;
    GameObject catchit, caughtit;
    bool onLine, caught, touching;
    Random rnd = new Random();
    Stopwatch stp = new Stopwatch();
    float startPos;
    UIController uiController;
    string switchSceneName;

    // Use this for initialization
    void Start () {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        playChar = GameObject.Find("Player").GetComponent<Character>();
        inv = GameObject.Find("Player").GetComponent<Inventory>();
        pole = GameObject.FindGameObjectWithTag("FishingPole");
        fish = GameObject.FindGameObjectWithTag("Fish");
        catchit = GameObject.FindGameObjectWithTag("CatchItText");
        catchit.SetActive(false);
        caughtit = GameObject.FindGameObjectWithTag("CaughtText");
        caughtit.SetActive(false);
        fish.SetActive(false);
        startPos = pole.transform.position.y;
        onLine = false;
        caught = false;
        touching = false;
    }

    void FixedUpdate()
    {
        // Checks if fader animation has completed and player clicked on a button
        if (!uiController.fadeInAction && switchSceneName != null)
        {
            SceneManager.LoadScene(switchSceneName);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Random.Range(0,350) == 1 && !onLine && !caught)
        {
            catchit.SetActive(true);
            onLine = true;
            fish.SetActive(true);
            stp.Start();
        }

        if (onLine && !caught)
        {
            pole.transform.Translate(new Vector3(0, -0.02f, 0));

            if ((Input.touchCount >= 1 && !touching) || Input.GetKey(KeyCode.Space))
            {
                touching = true;
                pole.transform.Translate(new Vector3(0, 0.25f, 0));
            }

            if (Input.touchCount == 0)
            {
                touching = false;
            }

            if (pole.transform.position.y >= 10)//1.8f)
            {
                inv.fish++;
                Random.Range(10,25);
                onLine = false;
                caught = true;
                catchit.SetActive(false);
                caughtit.SetActive(true);
                uiController.fadeOutAction = true;
                switchSceneName = "HubWorld";
            }

            if (pole.transform.position.y <= -100)
            {
                Random.Range(10, 25);
                onLine = false;
                caught = true;
                catchit.SetActive(false);
                //caughtit.SetActive(true);
                uiController.fadeOutAction = true;
                switchSceneName = "HubWorld";
            }


        }
	}
}
