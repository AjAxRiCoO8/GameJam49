using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MiniGame))]
public abstract class MiniGameRules : MonoBehaviour {

    [HideInInspector]
    public MiniGame miniGame;

    [HideInInspector]
    public List<GameObject> miniGameComponents = new List<GameObject>();

    protected bool miniGameHasStarted = false;

    float score = 0;

    [ContextMenu("Generate MiniGame")]
    public abstract void GenerateMiniGame(GameManager manager);

    public void StartMiniGame()
    {
        miniGameHasStarted = true;
    }

    public float EndMiniGame()
    {
        miniGameHasStarted = false;
        return GetScore();
    }

    public abstract float GetScore();

}