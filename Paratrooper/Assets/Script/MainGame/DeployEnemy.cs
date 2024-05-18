using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public List<GameObject> enemy;
    public GameObject soldierEnemy;
    public GameObject helicopterEnemy;
    float[] helicopterDeployPosition = new float[4]; // Corrected size to 4
    int randPos = 0;
    Vector2 pos = new Vector2();

    private void Start()
    {
        StartCoroutine(DeployHelicopter());
    }

    private void Update()
    {
        Deployment();
      
    }

    void Deployment()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 pos = new Vector2(Random.Range(-5, 5), transform.position.y);
            GameObject obj = Instantiate(soldierEnemy, pos, Quaternion.identity);
            enemy.Add(obj);
        }
        if (enemy.Count == 4 && enemy.Any(enemyInstance => enemyInstance.transform.position.x < 0))
        {
            Debug.Log("Time to attack");
        }
    }

    IEnumerator DeployHelicopter()
    {

        for (int i = 0; i < 4; i++)
        {
            InitHelicopterDeploy();
            GameObject obj = Instantiate(helicopterEnemy, pos, Quaternion.identity);


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
