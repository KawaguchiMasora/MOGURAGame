using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOGURA : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("hit");
        UI.instance.plus += 1;
        Destroy(gameObject);
    }
   
}
