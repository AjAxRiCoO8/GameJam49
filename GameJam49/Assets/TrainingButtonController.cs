using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingButtonController : MonoBehaviour
{
    [SerializeField]
    Text text;

    TrainingController trainingController;
	// Use this for initialization
	void Start ()
	{
	    text = GetComponentInChildren<Text>();
	    trainingController = GetComponentInParent<TrainingController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed()
    {
        Debug.Log(trainingController.currentNumber.ToString());
        if (trainingController.pressThisButton.ToString() == text.text)
        {
            trainingController.currentSuccesses++;

            if (text.text == "1")
            {
                trainingController.pressThisButton = 2;
            }
            else if (text.text == "2")
            {
                trainingController.pressThisButton = 1;
            }
            trainingController.hitWhatTarget.text = "Hit number: " + trainingController.pressThisButton;
            Destroy(gameObject);
        }
    }
}
