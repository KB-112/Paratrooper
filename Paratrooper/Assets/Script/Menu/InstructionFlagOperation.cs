using System;
using System.Collections.Generic;
using UnityEngine;

public class InstructionFlagOperation : MonoBehaviour
{
    private void Start()
    {
        UpdateUI(0, false);
        GameManager.gameManager.OnHowToPlay += delegate { UpdateUI(1, true); };
        GameManager.gameManager.OnMenuScreen += delegate { UpdateUI(0, false); };
    }

    public void UpdateUI(int newAlphaState, bool state)
    {
        HideText(newAlphaState);
        GameObjectState(state);
    }

    public void HideText(int alphaValue)
    {
        GameManager.gameManager.instruction.alpha = alphaValue;
    }

    public void GameObjectState(bool activeState)
    {
      
        GameManager.gameManager.backButton.SetActive(activeState);
    }

    public void OnDisable()
    {
        GameManager.gameManager.OnHowToPlay -= delegate { UpdateUI(1, true); };
        GameManager.gameManager.OnMenuScreen -= delegate { UpdateUI(0, false); };
    }
}
