using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdMiniGame : MonoBehaviour
{
    #region variables
    /// <summary>
    /// How many Bullets are left
    /// </summary>
    public int BulletCount = 10;
    /// <summary>
    /// How many birds have passed by
    /// </summary>
    private int BirdPassedCount;
    public int MaxBirds = 15;
    private int HitBirds;

    private bool GameFinshed;

    public int Delay = 1, FinishTime = 1, ReturnTime = 2;
    public Canvas canvas;
    public GameObject BirdPrefab;

    public Text BulletCountDisplay, BirdDisplay, FinishText;
    #endregion variables

    #region monodevelop
    private void Awake()
    {
        CallBird();
    }

    private void Update()
    {
        if (!GameFinshed)
            ManageUI();

        if (Input.GetMouseButtonUp(0) && !GameFinshed)
            Shoot();
    }
    #endregion monodevelop

    #region public methods
    public void CallBird()
    {
        if (GameFinshed)
            return;

        if (BirdPassedCount < MaxBirds)
        {
            GameObject TimerObject = new GameObject("TimerObject", typeof(TimerEvent));
            TimerEvent Timer = TimerObject.GetComponent<TimerEvent>();
            Timer.InvokableEvent += CreateBird;
            Timer.StartTimer(Delay);
            TimerObject.AddComponent<DestoryAfterAWhile>(); //make sure this object doesnt remain
        }
        else
        {
            GameObject TimerObject = new GameObject("TimerObject", typeof(TimerEvent));
            TimerEvent Timer = TimerObject.GetComponent<TimerEvent>();
            Timer.InvokableEvent += EndMiniGame;
            Timer.StartTimer(FinishTime);
            TimerObject.AddComponent<DestoryAfterAWhile>(); //make sure this object doesnt remain
        }
            

    }

    public void CreateBird()
    {
        var decider = Random.Range(0, 2);

        Vector3 randomPostion = decider == 0 ? new Vector3(0, Random.Range(Screen.height/3,Screen.height-100), 0)
            : new Vector3(Screen.width, Random.Range(Screen.height / 3, Screen.height - 100), 0);
        GameObject bird = Instantiate(BirdPrefab, randomPostion, new Quaternion(0, 0, 0, 0), canvas.transform);
        bird.AddComponent<DestoryAfterAWhile>(); //make sure this object doesnt remain
        var birdScript = bird.GetComponent<Bird>();
        birdScript.BirdMiniGame = this.gameObject.GetComponent<BirdMiniGame>();
        
        birdScript.Direction = decider == 0 ? Bird.FlightDirections.Right : Bird.FlightDirections.Left;
        bird.transform.localScale = decider == 0 ? new Vector3(2, 2, 2): new Vector3(-2, 2, 2);
        BirdPassedCount++;
        CallBird();
    }

    public void Shoot()
    {
        if (BulletCount >= 1)
            BulletCount--;
        else
            EndMiniGame();
    }

    public void CatchBird(GameObject caughtBird)
    {
        if (!GameFinshed)
        {
            HitBirds++;
            Destroy(caughtBird);
        }
    }

    /// <summary>
    /// Set some bool for checking
    /// </summary>
    public void EndMiniGame()
    {
        FinishText.gameObject.SetActive(true);
        GameFinshed = true;
        GetComponent<BirdRules>().score = HitBirds;
        GetComponent<BirdRules>().EndMiniGame();

        //return to main scene
        GameObject TimerObject = new GameObject("TimerObject", typeof(TimerEvent));
        TimerEvent Timer = TimerObject.GetComponent<TimerEvent>();
        Timer.InvokableEvent += ReturnToMain;
        Timer.StartTimer(ReturnTime);
        TimerObject.AddComponent<DestoryAfterAWhile>(); //make sure this object doesnt remain
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("HubWorld");
    }

    public void ManageUI()
    {
        BulletCountDisplay.text = string.Format("Bullets: {0}", BulletCount);
        BirdDisplay.text = string.Format("Birds Caught: {0}", HitBirds);
    }
    #endregion public methods
}
