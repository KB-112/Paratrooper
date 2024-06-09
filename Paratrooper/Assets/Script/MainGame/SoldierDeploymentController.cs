using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Events;

public class SoldierDeploymentController : MonoBehaviour
{
     List<int> deployPosition = new List<int> { -5, -4, -3, 3, 5, 4 };

    [SerializeField] private int deploySpeed;
    public bool state;
   

    public SoldierLandingController soldierLandingController;

    public GameObject prefab;

    public float posCount;
   
 
    private void Start()
    {
        soldierLandingController.info.Clear();
        for (int i = 0; i < 6; i++)
        {
            soldierLandingController.info.Add(new Info(new List<float>(), 0));
        }
        StartCoroutine(RandomizePosition());
    }
   
    IEnumerator RandomizePosition()
    {
        while (state)
        {
            int rand = UnityEngine.Random.Range(0, deployPosition.Count);
           // Debug.Log(" pos :" + rand + " "+ "Deploy position: " + " "+ deployPosition[rand]);

            Vector2 pos = new Vector2(deployPosition[rand], transform.position.y);
            Instantiate(prefab, pos, Quaternion.identity);
            

          
            soldierLandingController.info[rand].storePosition.Add(deployPosition[rand]);
            soldierLandingController.info[rand].dupCount++;
         



            if (soldierLandingController.info.Any(duplicate => duplicate.storePosition.Count == 3))
            {
                state = false;
                Debug.Log("Attack base");
            }
           
            yield return new WaitForSeconds(deploySpeed);
        }
    }

   


}
