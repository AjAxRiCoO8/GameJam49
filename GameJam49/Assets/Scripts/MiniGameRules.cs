using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MiniGame))]
public abstract class MiniGameRules : MonoBehaviour {

    [HideInInspector]
    public MiniGame miniGame;

    protected bool miniGameHasStarted = false;

    public float score;

    public abstract void GenerateMiniGame(GameManager manager);

    public void StartMiniGame()
    {
        miniGameHasStarted = true;
    }

    public float EndMiniGame()
    {
        miniGameHasStarted = false;
        return score;
    }

}