using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField] private float speed;
    private readonly List<int> stopPosition = new List<int> { -4, -3, -2 };
    private int count;
    [SerializeField] private float positionTolerance = 0.1f; // Tolerance for checking position
    [SerializeField] private float currentXPosition;

    public SoldierLandingController soldierLandingController;
    private void Start()
    {

        if (soldierLandingController.info.Any(store => store.storePosition.Contains(transform.position.x)))
        {
            count = soldierLandingController.info.Find(store => store.storePosition.Contains(transform.position.x)).dupCount;
            Debug.Log("Updated dupCount: " + count);
        }





    }
    private void Update()
    {
       
            MoveDown();
           CheckPosition();
        
    }

    private void MoveDown()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void CheckPosition()
    {
        if (Mathf.Abs(transform.position.y - stopPosition[count-1]) <= positionTolerance)
        {
           // Debug.Log("Destination Reached");
            speed = 0;
                       

        }
    }

   
}
