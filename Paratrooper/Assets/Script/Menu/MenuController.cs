
using UnityEngine;

[RequireComponent(typeof(InstructionFlagOperation))]
[RequireComponent(typeof(MenuFlagOperation))]
[RequireComponent(typeof(MainGameFlagOperation))]
public class MenuController : MonoBehaviour
{
    InstructionFlagOperation instructionFlagOperation;
    MenuFlagOperation menuFlagOperation;
    MainGameFlagOperation mainGameFlagOperation;

    private void Awake()
    {
        instructionFlagOperation = GetComponent<InstructionFlagOperation>();
        menuFlagOperation = GetComponent<MenuFlagOperation>();
        mainGameFlagOperation = GetComponent<MainGameFlagOperation>();
    }
    void Start()
    {
        GameManager.gameManager.menuButton[0].onClick.AddListener(StartGame);//How to play Button
        GameManager.gameManager.menuButton[1].onClick.AddListener(Quit);//How to play Button
        GameManager.gameManager.menuButton[2].onClick.AddListener(HowToPlay);//How to play Button
        GameManager.gameManager.backBtn.onClick.AddListener(MenuScreen); //Back

    }
    void StartGame()
    {
        mainGameFlagOperation.SetAlphaTextState(1);
    }
    private void Quit()
    {
        Application.Quit();
    }

    void HowToPlay()
    {
        instructionFlagOperation.SetAlphaTextState(1,true);

        menuFlagOperation.SetAlphaTextState(0, false) ;


    }

    void MenuScreen()
    {
        instructionFlagOperation.SetAlphaTextState(0, false);

        menuFlagOperation.SetAlphaTextState(1, true);

    }
}
//void Start()
//{
//    GameManager.gameManager.menuButton[0].onClick.AddListener(StartGame);//How to play Button
//    GameManager.gameManager.menuButton[1].onClick.AddListener(Quit);//How to play Button
//    GameManager.gameManager.menuButton[2].onClick.AddListener(HowToPlay);//How to play Button
//    GameManager.gameManager.menuButton[3].onClick.AddListener(MenuScreen); //Back
//}

//void SetVal(float val)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        GameManager.gameManager.menuText[i].alpha = 0 - val;


//        if (GameManager.gameManager.menuText[i].alpha == 0 - val)
//        {
//            GameManager.gameManager.menuText[i + 1].alpha = 1 + val;
//            GameManager.gameManager.menuText[i + 2].alpha = 1 + val;

//        }
//    }
//}

//void HowToPlay()
//{
//    SetVal(0);
//}
//void MenuScreen()
//{
//    SetVal(-1);
//    for (int i = 0; i < GameManager.gameManager.menuButton.Length - 1; i++)
//    {
//        GameManager.gameManager.menuButton[i].interactable = true;

//    }
//    for (int i = 0; i < GameManager.gameManager.mainGameObject.Count; i++)
//    {
//        GameManager.gameManager.mainGameObject[i].SetActive(false);
//    }
//}
//private void Quit()
//{
//    Application.Quit();
//}
//private void StartGame()
//{
//    // Disable menu buttons
//    for (int i = 0; i < GameManager.gameManager.menuButton.Length - 1; i++)
//    {
//        GameManager.gameManager.menuButton[i].interactable = false;
//    }

//    // Set menu text alpha
//    for (int i = 0; i < 6; i++)
//    {
//        GameManager.gameManager.menuText[i].alpha = 0;

//        if (GameManager.gameManager.menuText[i].alpha == 0)
//        {
//            GameManager.gameManager.menuText[i + 1].alpha = 1;
//        }
//    }

//    // Disable back button
//    GameManager.gameManager.menuButton[3].interactable = false;

//    // Activate main game objects
//    for (int i = 0; i < GameManager.gameManager.mainGameObject.Count; i++)
//    {
//        GameManager.gameManager.mainGameObject[i].SetActive(true);
//    }
//}
