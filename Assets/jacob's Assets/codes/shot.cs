using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{ 
 //public  gun;
 // Put name for the wapon that will use this code

 public int shootButton;
 public KeyCode reloadKey;

     void Update()
     {
     if (Input.GetMouseButtonDown(0))
     {
      gun.Shoot();
     }

     if (Input.GetKeyDown(KeyCode.R))
     {
      gun.Reload();
     }
     }
}
