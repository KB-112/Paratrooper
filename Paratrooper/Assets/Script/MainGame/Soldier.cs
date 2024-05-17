using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float speed;
    public GameObject soldParachute;

    Vector3 landingPos;
   

    private void Start()
    {
      
        landingPos = new Vector3(0, -3.37f, 0);
    }

    private void Update()
    {
        SoldierMovement();
    }

    void SoldierMovement()
    {
        float distance = Vector3.Distance(transform.position, landingPos);

        if (distance <= 0.01f)
        {
            speed = 0;
            soldParachute.SetActive(false);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
