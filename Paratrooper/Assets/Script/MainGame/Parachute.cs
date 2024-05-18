using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour

{

    
    void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Bullets"))
        {
            Destroy(gameObject);
            Destroy(otherObject);
            Debug.Log("Destroy parachute");
        }
    }
}
