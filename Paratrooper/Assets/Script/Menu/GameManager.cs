using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    // Menu and Main Game [Flag based operation]
    public TextMeshProUGUI[] menuText;
    public Button[] menuButton;
    public List<TextMeshProUGUI> mainGameText;
    public List<SpriteRenderer> mainGameSprite;
    public Image[] mainGameplayBg = new Image[3];
    public Sprite[] gameplaySprite = new Sprite[2];
    public TextMeshProUGUI instruction;
    public GameObject backButton;
    public Button backBtn;

    public int soldierland;
    public int score;
    public int highScore;

    public  event Action OnHowToPlay;
    public  event Action OnMenuScreen;
    public  event Action OnGameStart;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if ( menuButton != null && menuButton.Length > 0)
        {
           menuButton[0].onClick.AddListener(StartGameplay);
           menuButton[2].onClick.AddListener(HowToPlayBtn);
           backBtn.onClick.AddListener(MainMenu);
        }
        
    }

    public  void HowToPlayBtn()
    {
        OnHowToPlay?.Invoke();
    }

    public  void MainMenu()
    {
        OnMenuScreen?.Invoke();
    }

    public  void StartGameplay()
    {
        OnGameStart?.Invoke();
    }
}
