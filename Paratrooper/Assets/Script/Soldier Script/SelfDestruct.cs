using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    SoldierDeath soldierDeath;
    private void Start()
    {
      soldierDeath = GetComponent<SoldierDeath>();
    
    }
    void Update()
    {
        if (transform.position.y < -5)
        {
            soldierDeath.soldierPosDeath.Add(transform.position);
            int posX = Random.Range(-4, 4);
            int posY = Random.Range(-4, 4);
           
            this.transform.position = new Vector2(posX, posY);

        }

    }
}
