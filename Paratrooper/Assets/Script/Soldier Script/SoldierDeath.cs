using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeath : MonoBehaviour
{
  public  List<Vector2> soldierPosDeath = new List<Vector2>(); 
    public GameObject deathMark;
    private GameObject currentDeathMark; 

    private void Start()
    {
        
       
        StartCoroutine(RandPos());
    }



    IEnumerator RandPos()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
              
               

              
                if (currentDeathMark != null)
                {
                    Destroy(currentDeathMark);
                }

               
                currentDeathMark = Instantiate(deathMark, soldierPosDeath[0], Quaternion.identity);

                
                yield return new WaitForSeconds(1f);

               
                Destroy(currentDeathMark);
                currentDeathMark = null;
            }

         
            yield return null;
        }
    }
}
