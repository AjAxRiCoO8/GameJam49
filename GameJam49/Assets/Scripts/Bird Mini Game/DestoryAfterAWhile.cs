using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach as component to an object to make it destory after a certain time
/// </summary>
public class DestoryAfterAWhile : MonoBehaviour
{
    #region private variables
    [SerializeField]
    private float DestroyInXSeconds=5;
    #endregion private variables

    private void OnEnable()
    {
        Invoke("DestroyEvents", DestroyInXSeconds);
    }

    /// <summary>
    /// Everything that should happen OnDestroy
    /// </summary>
    private void DestroyEvents()
    {
            Destroy(this.gameObject);
    }
}
