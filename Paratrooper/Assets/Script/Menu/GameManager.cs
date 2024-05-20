using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager; 

    // Menu and Main Game [Flag based operation]

    //[Main Menu]
    public TextMeshProUGUI[] menuText;
    public Button[] menuButton ;

    //[Next scene - Main Gameplay]
    public List<TextMeshProUGUI> mainGameText;
    public List<SpriteRenderer> mainGameSprite;
    public Image[] mainGameplayBg = new Image[3];
    public Sprite[] gameplaySprite = new Sprite[2];

    //[Next scene -  Instruction of The Game]
    public TextMeshProUGUI instruction;
    public GameObject backButton;
    public Button backBtn;
    //***********************************************


   
    public int soldierland;

    public int score;
    public int highScore;
  

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }




    
}
