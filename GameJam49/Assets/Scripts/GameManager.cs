﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    // Player
    [SerializeField]
    Character player;

    [SerializeField]
    FightingManager fightingManager;


	// Use this for initialization
	void Start () {
        OnSceneChange("Fighting");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Character Player
    {
        get { return player; }
    }

    public FightingManager FightingManager
    {
        get { return fightingManager; }
    }

    public void OnSceneChange(string scene)
    {
        if (scene == "Fighting")
        {
            fightingManager.GetNextEnemy();
        }
    }
}
