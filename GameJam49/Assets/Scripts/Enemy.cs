using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : Character
{
    [Header("Min and max value for enemy score")]
    public Vector2 possibleScore = new Vector2(0, 10);
}
