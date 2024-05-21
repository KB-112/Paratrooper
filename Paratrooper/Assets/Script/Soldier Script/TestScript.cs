using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject fall;
    private void Start()
    {
        StartCoroutine(A());
    }
    IEnumerator A()
    {
       for(int i = 0; i < 3; i++)
        {
            int posX = Random.Range(-4, 4);
            int posY = Random.Range(-4, 4);
           fall.transform.position = new Vector2(posX, posY);
            Instantiate(fall);
          
            yield return new WaitForSeconds(0.5f);
        }
       
    }
}
