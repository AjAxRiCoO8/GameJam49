using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRules : MiniGameRules
{

    [SerializeField]
    [Range(0, 10)]
    float baseValue = 5;

    private void Update()
    {
        if (miniGameHasStarted)
        {
            // TODO: Check for button press

            // if correct
            // do stuff

            // if not correct or all buttons are pressed.
            miniGame.HideMiniGame();


        }
    }

    // Generates the minigame
    // Specifically, it generates a number of buttons with specific numbers in them.
    // The amount of buttons depends on the agility of the player.
    public override void GenerateMiniGame(GameManager manager)
    {
        for (int i = 0; i < (baseValue + manager.Player.strength); i++)
        {
            // TODO: Generate a number on a random location, not overlapping any other buttons.
        }
    }


}
