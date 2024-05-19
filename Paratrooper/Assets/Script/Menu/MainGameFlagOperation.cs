using UnityEngine;

public class MainGameFlagOperation : MonoBehaviour
{
    public int alphaTextState = 0;

    private void Start()
    {
        alphaTextState = 0;
        HideText();
        HideGameObjectSprite();
    }

    public void HideText()
    {
        for (int i = 0; i < GameManager.gameManager.mainGameText.Count; i++)
        {
            GameManager.gameManager.mainGameText[i].alpha = alphaTextState;
        }
    }

    public void HideGameObjectSprite()
    {
        for (int i = 0; i < GameManager.gameManager.mainGameSprite.Count; i++)
        {
            Color color = GameManager.gameManager.mainGameSprite[i].color;
            color.a = alphaTextState;
            GameManager.gameManager.mainGameSprite[i].color = color;
        }
    }

   
    public void SetAlphaTextState(int newAlphaState)
    {
        alphaTextState = newAlphaState;
        HideText();
        HideGameObjectSprite();
    }
}
