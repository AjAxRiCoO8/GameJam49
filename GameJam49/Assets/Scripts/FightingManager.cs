using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FightingOption
{
    Attack,
    Defend
}

public class FightingManager : MonoBehaviour {

    public GameObject canvas;

    [SerializeField]
    List<GameObject> attackMiniGames;

    List<GameObject> defenseMiniGames;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
