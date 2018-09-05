using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Also some extra stuff
/// </summary>
public class IncreaseScale : MonoBehaviour
{
    float lgt = 1;

    void Awake()
    {
        gameObject.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        gameObject.AddComponent<DestoryAfterAWhile>();
    }

	void Update ()
    {
        lgt += Time.deltaTime*1.5f;
        gameObject.transform.localScale = new Vector3(lgt, lgt, lgt);	
	}
}
