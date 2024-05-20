
using UnityEngine;

[RequireComponent(typeof(InstructionFlagOperation))]
[RequireComponent(typeof(MenuFlagOperation))]
[RequireComponent(typeof(MainGameFlagOperation))]
[RequireComponent(typeof(BlinkingText))]
public class MenuController : MonoBehaviour
{
    InstructionFlagOperation instructionFlagOperation;
    MenuFlagOperation menuFlagOperation;
    MainGameFlagOperation mainGameFlagOperation;
    BlinkingText blinkingText;

    private void Awake()
    {
        instructionFlagOperation = GetComponent<InstructionFlagOperation>();
        menuFlagOperation = GetComponent<MenuFlagOperation>();
        mainGameFlagOperation = GetComponent<MainGameFlagOperation>();
        blinkingText = GetComponent<BlinkingText>();
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

        menuFlagOperation.SetAlphaTextState(0, false);
        blinkingText.TurnOffBlinking(false);
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