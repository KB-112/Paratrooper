using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountPlayer : MonoBehaviour
{
public int countRightSide = 0;
public int countLeftSide = 0;
    public static CountPlayer instance;

    public AudioSource gameOver;

    public List<GameObject> particleSystemend;
    public GameObject gunBase;
    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        Gameover();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Soldier"))
        {
            if (collision.gameObject.transform.position.x > 1.2f && collision.gameObject.transform.position.x < 4f)
            {
                countRightSide++;
                Debug.Log("Collided on Right Side. Right Side Count: " + countRightSide);
            }
            else if (collision.gameObject.transform.position.x > -4f && collision.gameObject.transform.position.x < -1.2f)
            {
                countLeftSide++;
                Debug.Log("Collided on Left Side. Left Side Count: " + countLeftSide);
            }
        }
    }

    void Gameover()
    {
        if (countLeftSide == 4 || countRightSide == 4)
        {gunBase.SetActive(false);
            gameOver.Play();

            for (int i = 0; i < particleSystemend.Count; i++)
            {
                particleSystemend[i].SetActive(true);
            }

            StartCoroutine(ReloadSceneAfterDelay(8f));
        }
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
