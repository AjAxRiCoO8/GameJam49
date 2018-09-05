using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    #region public variables
    public enum FlightDirections { Left, Right}
    public FlightDirections Direction = FlightDirections.Right;
    public float Speed = 5;
    public BirdMiniGame BirdMiniGame;
    #endregion public variables

    #region monodevelop
    private void Awake()
    {
        SetUpButton();
    }

    private void Update()
    {
        MoveBird();
    }
    #endregion monodevelop

    #region private methods
    /// <summary>
    /// Sets up the button on this Bird GameObject to destroy the bird
    /// </summary>
    private void SetUpButton()
    {
        var btn = this.gameObject.AddComponent<Button>();
        btn.onClick.AddListener(delegate { BirdMiniGame.CatchBird(this.gameObject); });
    }

    /// <summary>
    /// Move the bird in a straight line horizontally
    /// </summary>
    private void MoveBird()
    {
        Vector3 translation = Direction == FlightDirections.Right ? new Vector3(Speed, 0, 0) : new Vector3(-Speed, 0, 0);
        transform.Translate(translation);
    }
    #endregion private methods
}
