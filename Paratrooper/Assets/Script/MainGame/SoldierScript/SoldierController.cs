using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    [SerializeField] private float speed;
    private readonly List<int> stopPosition = new List<int> { -4, -3, -2 };
    private int count;
    [SerializeField] private float positionTolerance = 0.1f; // Tolerance for checking position
    [SerializeField] private float currentXPosition;

    public SoldierLandingController soldierLandingController;
    public TextMeshProUGUI orderText;
    public SoldierAttack soldierAttack;

    private void Start()
    {
        if (soldierLandingController.info.Any(store => store.storePosition.Contains(transform.position.x)))
        {
            count = soldierLandingController.info.Find(store => store.storePosition.Contains(transform.position.x)).dupCount;
            Debug.Log("Updated dupCount: " + count);
            orderText.text = count.ToString();
        }

        // Start the coroutine
        StartCoroutine(SoldierRoutine());
    }

    private IEnumerator SoldierRoutine()
    {
        while (true)
        {
            MoveDown();
            yield return CheckPosition();

            // If the soldier has reached the destination, break the loop
            if (speed == 0)
            {
                StartAttackingProcess();
                yield break;
            }

            yield return null;
        }
    }

    private void MoveDown()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private IEnumerator CheckPosition()
    {
        if (Mathf.Abs(transform.position.y - stopPosition[count - 1]) <= positionTolerance)
        {
            speed = 0;
            Vector2 roundedPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
            soldierLandingController.currentPosition.Add(roundedPosition);
        }

        if (speed == 0)
        {
            //StartAttackingProcess();
        }

        yield return null;
    }

    private void StartAttackingProcess()
    {if (!soldierLandingController.stopInstantiate)
        {
            Vector2 roundedPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
       
            //if (soldierLandingController.currentPosition.Count == soldierLandingController.info.Count)
            {


                if (transform.position.x < 0)
                {
                    soldierAttack.getMaxEnemy.left.Add(roundedPosition);
                }
                else if (transform.position.x > 0)
                {
                    soldierAttack.getMaxEnemy.right.Add(roundedPosition);
                }
            }
        }
    }



    public Vector2 GetTargetPosition(Transform current)
    {
        if (current.position.x < 0)
        {
            return new Vector2(current.position.x + 1, current.position.y - 2);
        }
        else if (current.position.x > 0)
        {
            return new Vector2(current.position.x - 1, current.position.y - 2);
        }

        return current.position;
    }
}
