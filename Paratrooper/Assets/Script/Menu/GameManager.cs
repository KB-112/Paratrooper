using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; 
    public TextMeshProUGUI[] menuText;

    public Button[] menuButton ;
    public GameObject[] menuObj;
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

}
