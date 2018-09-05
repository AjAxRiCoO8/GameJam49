using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum FightingOption
{
    Attack,
    Defend
}

public class FightingManager : MonoBehaviour
{

    public GameObject canvas;

    [SerializeField]
    List<GameObject> attackMiniGames = new List<GameObject>();

    [SerializeField]
    List<GameObject> defenseMiniGames = new List<GameObject>();

    [SerializeField]
    GameObject AttackButton;

    [SerializeField]
    GameObject DefendButton;

    [SerializeField]
    Text PlayerHealth;

    [SerializeField]
    Text EnemyHealth;

    [SerializeField]
    List<GameObject> enemies;

    public int PlayerAttackPower = 10;
    public int PlayerDefensePower = 5;

    Enemy currentEnemy;

    public void StartAttackMiniGame()
    {
        //currentEnemy.health = 20;//TODO: HARD CODED because cant find bug location atm
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

        float randomScoreForEnemy = Random.Range(currentEnemy.possibleScore.x, currentEnemy.possibleScore.y);

        if (score >= randomScoreForEnemy)
        {
            currentEnemy.health -= PlayerAttackPower;// -=power/currentEnemy.Def
        }
        else
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Player.health -= 10 / PlayerDefensePower;//currentEnemy.strength/PlayerDefensePower;
        }

        UpdateUI();

        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Player.health <= 0)
        {
            // Player is dead
            SceneManager.LoadScene("GameOverScene");
            return;
        }

        if (currentEnemy.health <= 0)
        {
            // Enemy is Dead
            SceneManager.LoadScene("HubWorld");
            return;
        }
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

    public void UpdateUI()
    {
        PlayerHealth.text = "Player Health: " + GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Player.health;
        EnemyHealth.text = "Enemy Health: " + currentEnemy.health;
    }

    public void GetNextEnemy()
    {
        if (enemies.Count > 0)
        {
            GameObject enemy = Instantiate(enemies[0]);
            currentEnemy = enemy.GetComponent<Enemy>();
            enemies.RemoveAt(0);

            UpdateUI();
        }
    }
}
