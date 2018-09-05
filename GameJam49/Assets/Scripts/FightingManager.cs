using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum FightingOption
{
    Attack,
    Defend
}

public class FightingManager : MonoBehaviour {

    public GameObject canvas;

    [SerializeField]
    List<GameObject> attackMiniGames = new List<GameObject>();

    [SerializeField]
    List<GameObject> defenseMiniGames = new List<GameObject>();

    [SerializeField]
    GameObject AttackButton;

    [SerializeField]
    GameObject DefendButton;

	public void StartAttackMiniGame()
    {
        if (attackMiniGames.Count == 0)
        {
            return;
        }

        int randomMiniGame = Random.Range(0, attackMiniGames.Count);

        GameObject miniGame = Instantiate(attackMiniGames[randomMiniGame]);

        miniGame.GetComponent<MiniGame>().ShowMiniGame(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>());

        HideUI();
    }

    public void StartDefendMiniGame()
    {
        if (defenseMiniGames.Count == 0)
        {
            return;
        }

        int randomMiniGame = Random.Range(0, attackMiniGames.Count);

        GameObject miniGame = Instantiate(attackMiniGames[randomMiniGame]);

        miniGame.GetComponent<MiniGame>().ShowMiniGame(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>());

        HideUI();
    }

    public void ProcessScore(float score)
    {
        Debug.Log("Score: " + score);
    }

    public void ShowUI()
    {
        AttackButton.SetActive(true);
        DefendButton.SetActive(true);
    }

    public void HideUI()
    {
        AttackButton.SetActive(false);
        DefendButton.SetActive(false);
    }
}
