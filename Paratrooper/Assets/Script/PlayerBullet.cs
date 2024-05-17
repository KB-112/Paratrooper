using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject playerBullet;
    public Realtimeangle realtimeangle;
  [HideInInspector]  public float newAngle;

    public static PlayerBullet instance;
    private int clickCount;
    public float intervalBetweenBullets;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        realtimeangle = GetComponent<Realtimeangle>();
        StartCoroutine(ClickCounter());
    }

    IEnumerator ClickCounter()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                newAngle = realtimeangle.realtimeangle();
                Vector3 distantPosition = playerBullet.transform.position + Quaternion.Euler(0, 0, newAngle) * Vector2.up;

                clickCount++;

                if (clickCount <= 3)
                {
                    Instantiate(playerBullet, distantPosition, Quaternion.identity);
                }
                else 
                {
                    clickCount = 0;
                    yield return new WaitForSeconds(intervalBetweenBullets);
                }

              //  Debug.Log("Current angle on click: " + newAngle.ToString());
            }
            yield return null; 
        }
    }
}
