using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MiniGame : MonoBehaviour {

    [SerializeField]
    MiniGameRules rules;

    private void Start()
    {
        rules.miniGame = this;
    }

    // Called when the minigame starts
    // Is responsible for showing the minigame window.
    public void ShowMiniGame(GameManager manager)
    {
        // Make window visible
    
        rules.GenerateMiniGame(manager);


    }

    // Called when the minigame is over.
    // Is responsible for hiding the minigame window.
    public void HideMiniGame()
    {
        float score = rules.EndMiniGame();

        // Hide Window
    }
}
