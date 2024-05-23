
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
       
        GameManager.gameManager.menuButton[1].onClick.AddListener(Quit);//How to play Button
       

    }
   
    private void Quit()
    {
        Application.Quit();
    }

    
}