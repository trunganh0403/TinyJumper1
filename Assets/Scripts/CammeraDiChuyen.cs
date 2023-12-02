using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraDiChuyen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    float playerX;
    float playerY;
    float cammX;
    float cammY;
   
    void Update()
    {
        diChuyen();
        
    }
    void diChuyen()
    {
        cammX = transform.position.x;
        // cammY = transform.position.y;
        if (player != null)
        {
            cammX = player.transform.position.x +1;
            // cammY = player.transform.position.y;
        }
        transform.position = new Vector3(cammX, transform.position.y, transform.position.z);
    }





   
}



