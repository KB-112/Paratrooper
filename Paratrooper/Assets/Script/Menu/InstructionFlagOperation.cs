using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionFlagOperation : MonoBehaviour
{
    int alphaValue = 0;
    bool activeState = false;
    private void Start()
    {
        alphaValue = 0;
        activeState = false;
        HideText();
        GameObjectState();

    }

    public void HideText()
    {
       
        for (int i = 0; i < 1; i++)
        {
            GameManager.gameManager.instruction.alpha = alphaValue;
        }
    }

   public void GameObjectState()
    {
      
        GameManager.gameManager.backButton.SetActive(activeState);
    }

    public void SetAlphaTextState(int newAlphaState , bool state)
    {
        alphaValue = newAlphaState;
        activeState = state;
        HideText();
        GameObjectState();
       
    }
}
