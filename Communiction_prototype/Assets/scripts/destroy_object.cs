using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_object : MonoBehaviour
{
    public GameObject floor;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(floor);
        } 
    }
}
