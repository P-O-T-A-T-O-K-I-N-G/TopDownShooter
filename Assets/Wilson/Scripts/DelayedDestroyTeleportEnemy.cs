using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroyTeleportEnemy : MonoBehaviour
{
    public float delayTime;
    public GameObject MovingEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThisObject", delayTime);
    }

    public void DestroyThisObject()
    {
        Instantiate(MovingEnemy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
