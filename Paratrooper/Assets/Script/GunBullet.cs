using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float speed;
    private GunMovement gunMovement;
   

    void Start()
    {
      
        gunMovement = GetComponent<GunMovement>();
        if (gunMovement == null)
        {
            Debug.LogError("PlayerBullet component not found!");
        }
    }

    void Update()
    {
       

        MoveBullet();
    }

   

    void MoveBullet()
    {
        if (gunMovement != null)
        {
          //  transform.Translate(gunMovement.gun.transform.eulerAngles.z * speed * Time.deltaTime, gunMovement.gun.transform.eulerAngles.z * speed * Time.deltaTime, 0);
        }
    }
}
