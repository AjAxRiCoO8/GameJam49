using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingController : MonoBehaviour
{
    public UIController uiController;
    public Text hitWhatTarget;
    public Text timer;

    float trainingTime = 20f;
    public GameObject trainingButton;
    bool startTimer, spawn;
    float spawnDelayTime = 0.5f;

    public int pressThisButton = 1;

    public int currentNumber = 1;
    int nextTargetNumber = 1;
    public int maxSpawn;

    int currentSpawn;
    public int currentSuccesses; // used to calculate stats increase 

    Coroutine currentCoroutine;
	// Use this for initialization
	void Start () {
	    hitWhatTarget = GameObject.Find("NumberToTap").GetComponent<Text>();
	    hitWhatTarget.text = "Hit number: " + pressThisButton;

        // Used for delaying spawning
        Invoke("StartSpawning", 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        Debug.Log("Current " + currentNumber);

	    if (spawn)
	    {
	        SpawnButton();
	    }

	    if (trainingTime > 0)
	    {
	        trainingTime -= Time.deltaTime;
	        timer.text = "Time: " + Mathf.Floor(trainingTime);
	    }
	    else
	    {
            uiController.fadeOutAction = true;
	        if (!uiController.fading)
            {
	            SceneManager.LoadScene("HubWorld");
	        }
	    }

	}


    void StartSpawning()
    {
        spawn = true;
    }

    void SpawnButton()
    {
        spawn = false;
        currentSpawn++;
        GameObject spawnGameObject = (GameObject)Instantiate(trainingButton, transform);
        spawnGameObject.SetActive(true);
        spawnGameObject.transform.position = new Vector2(Random.Range(0, 440), Random.Range(0, 230));
        spawnGameObject.GetComponentInChildren<Text>().text = "" + nextTargetNumber;

        switch (currentNumber)
        {
            case 1:
                nextTargetNumber = 2;
                break;
            case 2:
                nextTargetNumber = 1;
                break;
        }

        currentNumber = nextTargetNumber;
        startTimer = true;
        currentCoroutine = StartCoroutine(SpawnDelay(spawnDelayTime));
    }

    IEnumerator SpawnDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        spawn = true;
    }
}
