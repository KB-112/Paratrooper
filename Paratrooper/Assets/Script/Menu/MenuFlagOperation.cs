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
        alphaTextState = 0;
        gameObjectSpriteState= false;
    }

    public void HideText()
    {
       
        for (int i = 0; i < GameManager.gameManager.menuText.Length; i++)
        {
            GameManager.gameManager.menuText[i].alpha = alphaTextState;
        }
    }

  public  void MenuButtonInteraction()
    {
     
        for (int i = 0; i < GameManager.gameManager.menuButton.Length; i++)
        {
            GameManager.gameManager.menuButton[i].interactable = gameObjectSpriteState;
          

        }
    }

    public void SetAlphaTextState(int newAlphaState , bool state)
    {
        alphaTextState = newAlphaState;
        gameObjectSpriteState = state;
       HideText();
        MenuButtonInteraction();
       
    }
}
