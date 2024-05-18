using System.Collections;
using UnityEngine;
public class Soldier : MonoBehaviour
{
    public float speed;
    public GameObject parachute;
    public GameObject parachuteTarget;

    public SpriteRenderer deadSpriteRenderer;
    public ParticleSystem[] particleSystems;

    private Vector3 landingPos = new Vector3(0, -3.37f, 0);
    private bool isDead = false;

    private void Start()
    {
        // Stop all particle systems at the start
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.Stop();
        }
    }

    private void Update()
    {
        if (!isDead)
        {
            MoveSoldier();
        }
    }

    private void MoveSoldier()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= landingPos.y)
        {
            speed = 0;
            if (parachuteTarget != null)
            {
                parachuteTarget.SetActive(false);
            }
        }
        else if (parachuteTarget == null)
        {
            GetComponent<SpriteRenderer>().sprite = deadSpriteRenderer.sprite;
            StartCoroutine(HandleDeath());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullets"))
        {
            foreach (var particleSystem in particleSystems)
            {
                particleSystem.Play();
            }

            Destroy(collision.gameObject);
            StartCoroutine(HandleDeath());
        }
        //GameObject otherObject = collision.gameObject;
        //if (otherObject.CompareTag("Soldier"))
        //{
        //    otherObject.transform.position = new Vector2(otherObject.transform.position.x, otherObject.transform.position.y + 1);
        //    Debug.Log("same Collision ");
        //}
    }
    private IEnumerator HandleDeath()
    {
        isDead = true;
        GetComponent<SpriteRenderer>().sprite = deadSpriteRenderer.sprite;
        transform.localScale = new Vector2(0.5f,0.5f);
        yield return new WaitForSeconds(1f); 
        Destroy(gameObject);
    }
}
