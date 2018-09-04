using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text hpText,staText,strText;
    Character characterController;

    //Fader
    Image blackFade;
    public  bool fadeOutAction, fadeInAction;
    [SerializeField]
    bool setAlpha;
    [SerializeField]
    float currentAlpha;
    float fadeRate = 0.03f;

    //List<int> statNumberList = new List<int>();
    // Use this for initialization
    void Start ()
	{
	    characterController = GameObject.Find("Player").GetComponent<Character>();
	    blackFade = GameObject.Find("BlackFade").GetComponent<Image>();
	    blackFade.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    UpdateText();

        if (fadeInAction)
        { 
	        Fade(true);
        }
        else if (fadeOutAction)
        {
            Fade(false);
        }
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

    public void Fade(bool fadeIn)
    {
        if (!setAlpha && fadeIn)
        {
            currentAlpha = 1;
            setAlpha = true;
            blackFade.enabled = true;
        }
        else if (!setAlpha && !fadeIn)
        {
            currentAlpha = 0;
            setAlpha = true;
            blackFade.enabled = true;
        }


        currentAlpha = blackFade.color.a;

        if (fadeIn)
        {
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b,
                currentAlpha - fadeRate);
        }
        else
        {
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b,
                currentAlpha + fadeRate);
        }

        currentAlpha = Mathf.Clamp(currentAlpha, 0, 1);

        if (currentAlpha <= 0)
        {
            setAlpha = false;
            fadeInAction = false;
        }
        else if (currentAlpha >= 1) 
        {
            setAlpha = false;
            fadeOutAction = false;
        }
    }
}
