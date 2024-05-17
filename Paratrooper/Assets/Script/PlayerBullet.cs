
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
    public GameObject playerBullet;
    public Realtimeangle realtimeangle;
    public float newAngle;
    void Start()
    {
        realtimeangle = GetComponent<Realtimeangle>();
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(0, -1);
            playerBullet.transform.position = pos;
            Instantiate(playerBullet, playerBullet.transform.position, Quaternion.identity);

            Debug.Log("Current angle on click" + realtimeangle.realtimeangle().ToString());
            newAngle = realtimeangle.realtimeangle();
        }
        if (playerBullet != null)
        {
            playerBullet.transform.Translate(10, 10, 0);
        }
    }

   
}
