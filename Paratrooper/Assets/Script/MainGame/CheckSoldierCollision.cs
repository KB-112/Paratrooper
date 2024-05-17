using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSoldierCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier"))
        {
            GameManager.gameManager.soldierland++;
            Debug.Log(GameManager.gameManager.soldierland);
        }
    }
}
