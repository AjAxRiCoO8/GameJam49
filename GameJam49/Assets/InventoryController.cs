using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    Character playChar;
    Inventory inv;
    GameObject gpParent;//, logsParent, birdParent, fishParent, swordParent, shieldParent, rSwordParent, rShieldParent;
    Text gpText, logsText, birdText, fishText, swordText, shieldText, rSwordText, rShieldText;

    // Use this for initialization
    void Start()
    {
        playChar = GameObject.Find("Player").GetComponent<Character>();
        inv = GameObject.Find("Player").GetComponent<Inventory>();

        gpParent = GameObject.FindGameObjectWithTag("CurrentGold");
        gpText = gpParent.GetComponent<Text>();
        gpText.text = "Current GP: " + inv.gp;

        logsText = GameObject.Find("LogsInv").GetComponent<Text>();
        logsText.text = "LOGS: " + inv.logs;
        birdText = GameObject.Find("BirdsInv").GetComponent<Text>();
        birdText.text = "BIRDS: " + inv.birds;
        fishText = GameObject.Find("FishesInv").GetComponent<Text>();
        fishText.text = "FISH: " + inv.fish;
        swordText = GameObject.Find("SwordsInv").GetComponent<Text>();
        swordText.text = "SWORDS: " + inv.swords;
        shieldText = GameObject.Find("ShieldsInv").GetComponent<Text>();
        shieldText.text = "SHIELDS: " + inv.shields;
        rSwordText = GameObject.Find("RSwordsInv").GetComponent<Text>();
        rSwordText.text = "RUSTY SWORDS: " + inv.Rswords;
        rShieldText = GameObject.Find("RShieldsInv").GetComponent<Text>();
        rShieldText.text = "RUSTY SHIELDS: " + inv.Rshields;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EatBird()
    {
        if (inv.birds >= 1)
        {
            playChar.stamina += Random.Range(5, 16);
            inv.birds--;
            birdText.text = "BIRDS: " + inv.birds;
        }
    }

    public void EatFish()
    {
        if (inv.fish >= 1)
        {
            playChar.stamina += Random.Range(10, 26);
            inv.fish--;
            birdText.text = "FISH: " + inv.fish;
        }
    }

    public void EquipSword()
    {
        if (!playChar.swordEquiped)
        {
            playChar.swordEquiped = true;
            inv.swords -= 1;
            // Change text
        }
        else
        {
            playChar.swordEquiped = false;
            inv.swords += 1;
            // Change text
        }
    }

    public void EquipShield()
    {
        if (!playChar.shieldEquiped)
        {
            playChar.shieldEquiped = true;
            inv.shields -= 1;
            // Change text
        }
        else
        {
            playChar.shieldEquiped = false;
            inv.shields += 1;
            // Change text
        }
    }
}