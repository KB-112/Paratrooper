using TMPro;
using UnityEngine;

public class GunMovement : MonoBehaviour,Realtimeangle
{
    public GameObject gun;

    public Vector2 angleConstraint;
    public float gunMoveRate;
    public float slerpRate;
    public TextMeshProUGUI currentAngleText;
  

    Vector3 newGunzDirection;
    float[] gunrate = new float[2];  
    void Start()
    {
        newGunzDirection = gun.transform.eulerAngles;
    }


    void Update()
    {
   
        
        ChangeDirection();
        CheckConstraintState();
    }

  
   
   void ChangeDirection( )
   {
       
          
            if (Input.GetKey(KeyCode.RightArrow) )
            {
          
                newGunzDirection.z = newGunzDirection.z - gunrate[0];

            }

            if (Input.GetKey(KeyCode.LeftArrow) )
            {
           
            newGunzDirection.z = newGunzDirection.z + gunrate[1];
            }

       
               
        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.Euler(newGunzDirection), slerpRate * Time.deltaTime);
     //   currentAngleText.text = newGunzDirection.z.ToString() + "°";
                //0176 for degree (alt + numeric pad )
            
      
    }

    void CheckConstraintState()
    {
        if (newGunzDirection.z == angleConstraint.x)
        {
            gunrate[1] = 0;
        }
       else if (newGunzDirection.z == angleConstraint.y)
        {
            gunrate[0] = 0;
        }
        else
        {
            gunrate[0] = gunMoveRate;
            gunrate[1] = gunMoveRate;

        }

    }
    public float realtimeangle()
    {
        return gun.transform.eulerAngles.z;

    }
}
