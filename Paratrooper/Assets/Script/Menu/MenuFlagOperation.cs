using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFlagOperation : MonoBehaviour
{
    public int alphaTextState = 1;
    public bool gameObjectSpriteState = true;

    private void Start()
    {
        HideText(1);
        MenuButtonInteraction(true);

        GameManager.gameManager.OnGameStart += delegate { OnBtnPress(0, false); };
        GameManager.gameManager.OnMenuScreen += delegate { OnBtnPress(1, true); }; ;
        GameManager.gameManager.OnHowToPlay += delegate { OnBtnPress(0, false); };
    }

    public void HideText(int val)
    {
        for (int i = 0; i < GameManager.gameManager.menuText.Length; i++)
        {
            GameManager.gameManager.menuText[i].alpha = val;
        }
    }

    public void MenuButtonInteraction(bool state)
    {

        for (int i = 0; i < GameManager.gameManager.menuButton.Length; i++)
        {
            GameManager.gameManager.menuButton[i].interactable = state;
        }
    }

    void OnBtnPress(int val, bool state)
    {
        alphaTextState = val;
        gameObjectSpriteState = state;
        HideText(val);
        MenuButtonInteraction(state);
    }

    private void OnDisable()
    {
        GameManager.gameManager.OnGameStart -= delegate { OnBtnPress(0, false); };
        GameManager.gameManager.OnMenuScreen -= delegate { OnBtnPress(1, true); }; ;
        GameManager.gameManager.OnHowToPlay -= delegate { OnBtnPress(0, false); };
    }
}
