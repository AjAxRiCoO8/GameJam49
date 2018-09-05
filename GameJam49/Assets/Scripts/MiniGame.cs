using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MiniGame : MonoBehaviour {

    public GameObject canvas;

    [SerializeField]
    MiniGameRules rules;

    private void Awake()
    {
        rules.miniGame = this;

        canvas = GameObject.FindGameObjectWithTag("MiniGameCanvas");
    }

    // Called when the minigame starts
    // Is responsible for showing the minigame window.
    public void ShowMiniGame(GameManager manager)
    {
    
        rules.GenerateMiniGame(manager);

        rules.StartMiniGame();


    }

    // Called when the minigame is over.
    // Is responsible for hiding the minigame window.
    public void HideMiniGame(GameManager manager)
    {
        float score = rules.EndMiniGame();

        manager.FightingManager.ProcessScore(score);

        for(int i = 0; i < rules.miniGameComponents.Count; i++)
        {
            Destroy(rules.miniGameComponents[i]);
        }

        manager.FightingManager.ShowUI();
    }
}
