using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    Character playChar;
    Inventory inv;
    GameObject gpParent;
    Text gpText;

    // Use this for initialization
    void Start () {

        playChar = GameObject.Find("Player").GetComponent<Character>();
        inv = GameObject.Find("Player").GetComponent<Inventory>();
        gpParent = GameObject.FindGameObjectWithTag("CurrentGold");
        gpText = gpParent.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        gpText.text = "Current Gold: " + inv.gp;
    }

    public void BuyLog()
    {
        if (inv.gp >= 100)
        {
            inv.logs++;
            inv.gp -= 100;
        }
    }

    public void SellLog()
    {
        if (inv.logs >= 1)
        {
            inv.logs--;
            inv.gp += 30;
        }
    }

    public void BuyBird()
    {
        if (inv.gp >= 150)
        {
            inv.birds++;
            inv.gp -= 150;
        }
    }

    public void SellBird()
    {
        if (inv.birds >= 1)
        {
            inv.birds--;
            inv.gp += 50;
        }
    }

    public void BuyFish()
    {
        if (inv.gp >= 250)
        {
            inv.fish++;
            inv.gp -= 250;
        }
    }

    public void SellFish()
    {
        if (inv.fish >= 1)
        {
            inv.fish--;
            inv.gp += 100;
        }
    }

    public void BuySword()
    {
        if (inv.gp >= 300)
        {
            inv.swords++;
            inv.gp -= 300;
        }
    }

    public void SellSword()
    {
        if (inv.swords >= 1)
        {
            inv.swords--;
            inv.gp += 120;
        }
    }

    public void BuyShield()
    {
        if (inv.gp >= 250)
        {
            inv.shields++;
            inv.gp -= 250;
        }
    }

    public void SellShield()
    {
        if (inv.shields >= 1)
        {
            inv.shields--;
            inv.gp += 100;
        }
    }

    public void SellRustyShield()
    {
        if (inv.shields >= 1)
        {
            inv.shields--;
            inv.gp += 30;
        }
    }

    public void SellRustySword()
    {
        if (inv.Rswords >= 1)
        {
            inv.Rswords--;
            inv.gp += 30;
        }
    }


}
