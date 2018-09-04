using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    [Range(0, 100)]
    public float health;
    
    [SerializeField]
    [Range(0, 100)]
    public float stamina;

    [SerializeField]
    [Range(0, 100)]
    public float strength;

    [SerializeField]
    [Range(0, 100)]
    public float agility;

    public string gp { get; internal set; }

    // Inventory ?

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        health = 70 + (strength*10);
        stamina = 20 + (agility * 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
