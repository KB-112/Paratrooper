using System.Collections;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    float[] speedPolarity = new float[4];
    float[] lanePolarity = new float[4];


    public float speed = 0;
    public float constraintBoundsValue;
    int reverseDirection = 1;
    private Transform cachedTransform;
    int random = 0;
    int randLane = 0;
    public ParticleSystem[] destroyParticle;

    public GameObject soldierEnemy;

    public AudioSource dead;
    private void Start()
    {
        cachedTransform = transform; 
        Initialization();
        destroyParticle[0].Stop();
        destroyParticle[1].Stop();
        StartCoroutine(Deployment());
    }

    void Initialization()
    {
        speedPolarity[0] = 1 * speed;
        speedPolarity[1] = -1 * speed;
        speedPolarity[2] = -1 * speed;
        speedPolarity[3] = 1 * speed;
        random = Random.Range(0, speedPolarity.Length);
        

        if (cachedTransform.position.x > -constraintBoundsValue  && speedPolarity[random] == -speed || cachedTransform.position.x < constraintBoundsValue && random == speed)
        {
            speedPolarity[random] =   speedPolarity[random] *-1;
           

        }
       
    }
    void InitLane()
    {

       lanePolarity[0] = 3;
        lanePolarity[1] = 3;
        lanePolarity[2] = 4;
        lanePolarity[3] = 3;
        randLane = Random.Range(0, lanePolarity.Length);
        cachedTransform.transform.position = new Vector3(transform.position.x, lanePolarity[randLane], transform.position.z);
    }

    private void Update()
    {
        Movement();
        ConstraintBounds();
      
    }

    void Movement()
    {
      
        cachedTransform.Translate(speedPolarity[random] * Time.deltaTime * reverseDirection, 0, 0);

        if(CountPlayer.instance.countLeftSide  ==4||  CountPlayer.instance.countRightSide ==4)
         {
            Destroy(gameObject);
         }
    }

    void ConstraintBounds()
    {
        if (cachedTransform.position.x < -constraintBoundsValue || cachedTransform.position.x > constraintBoundsValue)
        {
            reverseDirection *= -1;
            cachedTransform.localScale = new Vector3(-cachedTransform.localScale.x, cachedTransform.localScale.y, cachedTransform.localScale.z);
            InitLane();
            BoxCollider2D rb = GetComponent<BoxCollider2D>();

            rb.isTrigger = true;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, 1f);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Bullets"))
        {
            Debug.Log("Collision detected with: " + otherObject.name);
            BoxCollider2D rb= GetComponent<BoxCollider2D>();

            rb.isTrigger = false;
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, 0f);
            Destroy(otherObject);
            destroyParticle[0].Play();
            destroyParticle[1].Play();
            GameManager.gameManager.score++;
            dead.Play();

        }
    }

    IEnumerator Deployment()
    {
        while (true)
        {
            if (transform.position.x < 4 && transform.position.x > 1.2f)
            {
               
                float randomValue = Random.Range(0f, 1f);

               
                if (randomValue <= 0.35f)
                {
                    
                    float randomX = Random.Range(1.5f, 4f);
                    if (Random.Range(0, 2) == 0) 
                    {
                        randomX = -randomX;
                    }
                    transform.position = new Vector3(randomX+0.5f, transform.position.y, transform.position.z);

                    Instantiate(soldierEnemy, transform.position, Quaternion.identity);
                }

           
                float range = Random.Range(0.5f, 0.8f);
                yield return new WaitForSeconds(range);
            }
            else
            {
                yield return null; 
            }
        }
    }


}
