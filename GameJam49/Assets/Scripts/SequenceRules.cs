using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceRules : MiniGameRules
{
    [SerializeField]
    GameObject sequenceButton;

    List<GameObject> buttons = new List<GameObject>();

    Vector2 horizontalBoundaries;
    Vector2 verticalBoundaries;

    [SerializeField]
    [Range(10, 100)]
    float buttonSpread = 20;

    [SerializeField]
    [Range(0, 10)]
    int baseValue = 5;

    [SerializeField]
    int buttonSize = 100;

    int currentNumberShouldBePressed = 1;

    float timer = 0;

    GameManager manager;

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
        this.manager = manager;

        RectTransform objectRectTransform = miniGame.canvas.transform.parent.GetComponent<RectTransform>();
        horizontalBoundaries = new Vector2(objectRectTransform.rect.width / 2, objectRectTransform.rect.width);
        verticalBoundaries = new Vector2(0, objectRectTransform.rect.height);

        List<Vector2> usedPositions = new List<Vector2>();

        for (int i = 0; i < (baseValue + manager.Player.strength); i++)
        {
            float horizontalPos = Random.Range(horizontalBoundaries.x, horizontalBoundaries.y - buttonSize - buttonSpread) - horizontalBoundaries.y / 2;
            float verticalPos = Random.Range(verticalBoundaries.x, verticalBoundaries.y - buttonSize - buttonSpread) - (verticalBoundaries.y - buttonSize - buttonSpread) / 2;

            bool used = false;

            foreach (var pos in usedPositions)
            {
                if ((horizontalPos + buttonSpread >= pos.x && horizontalPos - buttonSpread <= pos.x + buttonSize)
                    || (verticalPos + buttonSpread >= pos.y && verticalPos - buttonSpread <= pos.y + buttonSize))
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
            miniGameComponents.Add(button);
             
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
            miniGameHasStarted = false;
            miniGame.HideMiniGame(manager);
            return;
        }

        if (currentNumberShouldBePressed == buttons.Count + 1)
        {
            // Did all buttons
            miniGameHasStarted = false;
            miniGame.HideMiniGame(manager);
            return;
        }
    }

    public override float GetScore()
    {
        return currentNumberShouldBePressed - 1 / timer + manager.Player.strength;
    }


}
