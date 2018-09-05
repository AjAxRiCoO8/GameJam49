using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdRules : MiniGameRules
{
    [HideInInspector]
    public MiniGame miniGame;

    protected bool miniGameHasStarted = false;

    public float score;

    public void StartMiniGame()
    {
        miniGameHasStarted = true;
    }

    public float EndMiniGame()
    {
        miniGameHasStarted = false;
        return score;
    }

    public override void GenerateMiniGame(GameManager manager)
    {
    }

    public override float GetScore()
    {
        return score;
    }
}
