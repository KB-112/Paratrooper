using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public List<GameObject> enemy;
   
    public GameObject helicopterEnemy;
    float[] helicopterDeployPosition = new float[4]; // Corrected size to 4
    int randPos = 0;
    Vector2 pos = new Vector2();

    private void Start()
    {
       StopCoroutine(DeployHelicopter());
    }

  

   

    IEnumerator DeployHelicopter()
    {

        for (int i = 0; i < 4; i++)
        {
            InitHelicopterDeploy();
           Instantiate(helicopterEnemy, pos, Quaternion.identity);


            yield return new WaitForSeconds(1f);
        }
    }

    void InitHelicopterDeploy()
    {
        helicopterDeployPosition[0] = 12;
        helicopterDeployPosition[1] = -12;
        helicopterDeployPosition[2] = 12;
        helicopterDeployPosition[3] = -12;
        randPos = Random.Range(0, helicopterDeployPosition.Length);
        pos = new Vector2(helicopterDeployPosition[randPos], transform.position.y);
    }

   
}
