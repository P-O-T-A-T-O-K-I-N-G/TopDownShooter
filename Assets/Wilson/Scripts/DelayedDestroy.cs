using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    //This Script will make an object get destroyed after a few seconds

    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThisObject", delayTime); 
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
