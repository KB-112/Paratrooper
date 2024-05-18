using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float speed;
    private float bulletAngle; 

    void Start()
    {
        bulletAngle = PlayerBullet.instance.newAngle; 
    }

    void Update()
    {
        MoveBullet();
        if (transform.position.y > 5.04f)
        {
            Destroy(this.gameObject);
        }
    }

    void MoveBullet()
    {
        transform.Translate(Quaternion.Euler(0, 0, bulletAngle) * Vector2.up * Time.deltaTime * speed);
    }
}
