using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
      //  player = GameObject.Find("Player");
      //  checkpoint = player.transform.position;
    }

    // Update is called once per frame
  

    void OnTriggerEnter(Collider death)
    {
          if (death.gameObject.tag == "Player")
             {
            //    death.transform.position = checkpoint;
            //    Debug.Log("Long Chick");
            Destroy(death.gameObject);
        Instantiate(player, checkpoint.transform.position, checkpoint.transform.rotation);
          }

    }
}
