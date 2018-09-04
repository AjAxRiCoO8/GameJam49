using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceRules : MiniGameRules
{
    [SerializeField]
    GameObject sequenceButton;

    List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    Vector2Int verticalBoundaries;

    [SerializeField]
    Vector2Int horizontalBoundaries;

    [SerializeField]
    [Range(10, 100)]
    float buttonSpread = 20;

    [SerializeField]
    [Range(0, 10)]
    float baseValue = 5;

    int currentNumberShouldBePressed = 1;

    float timer = 0;

    private void Update()
    {
        if (miniGameHasStarted)
        {
            timer += Time.deltaTime;
        }
    }

    // Generates the minigame
    // Specifically, it generates a number of buttons with specific numbers in them.
    // The amount of buttons depends on the agility of the player.
    public override void GenerateMiniGame(GameManager manager)
    {
        List<Vector2> usedPositions = new List<Vector2>();

        for (int i = 0; i < (baseValue + manager.Player.strength); i++)
        {
            // TODO: Generate a number on a random location, not overlapping any other buttons.
            int horizontalPos = Random.Range(horizontalBoundaries.x, horizontalBoundaries.y - 50 - (int)buttonSpread) - horizontalBoundaries.y / 2;
            int verticalPos = Random.Range(verticalBoundaries.x, verticalBoundaries.y - 50 - (int)buttonSpread) - verticalBoundaries.y /2;

            bool used = false;

            foreach (var pos in usedPositions)
            {
                if ((horizontalPos + buttonSpread >= pos.x && horizontalPos - buttonSpread <= pos.x + 50)
                    || (verticalPos + buttonSpread >= pos.y && verticalPos - buttonSpread <= pos.y + 50))
                {
                    i--;
                    used = true;
                    break;
                }
            }

            if (used)
            {
                continue;
            }

            usedPositions.Add(new Vector2(horizontalPos, verticalPos));

            GameObject button = Instantiate(sequenceButton, miniGame.canvas.transform);
            button.transform.localPosition = new Vector2(horizontalPos, verticalPos);
            button.GetComponentInChildren<Text>().text = i + 1 + "";
            button.GetComponent<Button>().onClick.AddListener(delegate { OnButtonPress(button, button.GetComponentInChildren<Text>().text); } );

            buttons.Add(button);
             
        }
    }

    public void OnButtonPress(GameObject button, string number)
    {
        int num = int.Parse(number);

        if (num == currentNumberShouldBePressed)
        {
            // Correct Button
            button.SetActive(false);
            currentNumberShouldBePressed++;
        }
        else
        {
            // Wrong Button
            Debug.Log("Wrong Button");
            miniGame.HideMiniGame();
            miniGameHasStarted = false;
        }

        if (currentNumberShouldBePressed == buttons.Count + 1)
        {
            // Did all buttons
            miniGame.HideMiniGame();
            miniGameHasStarted = false;
        }
    }


}
