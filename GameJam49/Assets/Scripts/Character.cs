using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    [Range(0, 100)]
    float health;
    
    [SerializeField]
    [Range(0, 100)]
    public float stamina;

    [SerializeField]
    [Range(0, 100)]
    public float strength;

    // Inventory ?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
