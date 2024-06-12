using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOM : MonoBehaviour
{
    public GameObject Effect;
    public MeshRenderer meshCollider;
    void Start()
    {
        StartCoroutine(ExampleCoroutineMethod());
    }

    IEnumerator ExampleCoroutineMethod()
    {
        // 3•b‘Ò‹@
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
   
    void OnMouseDown()
    {
        Debug.Log("BOMhit");
        UI.instance.plus -= 1;
        meshCollider.enabled = false;
        Effect.SetActive(true);
        ExampleCoroutineMethod();
    }
}
