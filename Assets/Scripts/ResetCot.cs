using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    float PlayerX;
    float minY = -7f;
    float maxY = -3.5f;
    GameObject gm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = Mathf.Abs(Player.transform.position.x)+4f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null && collision.gameObject.tag == "GioiHanQuayVe")
        {
            
            //transform.Translate(new Vector3(PlayerX, Random.Range(minY, maxY), transform.position.z));
           gm = Instantiate(gameObject, new Vector3(PlayerX, Random.Range(minY, maxY), transform.position.z), Quaternion.identity);
           
        }
        if (collision != null && collision.gameObject.tag == "GioiHanHuy")
        {
            Destroy(gameObject);
        }

    }
}
