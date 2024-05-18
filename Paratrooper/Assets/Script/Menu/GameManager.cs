using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; 
    public TextMeshProUGUI[] menuText;

    public Button[] menuButton ;
    public GameObject[] menuObj;
    public int soldierland;

    public int score;
    public int highScore;
    public List<GameObject> mainGameObject;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }




    
}
