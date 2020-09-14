using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadedestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
            Destroy(gameObject);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
