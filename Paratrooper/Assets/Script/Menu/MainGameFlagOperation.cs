using Unity.VisualScripting;
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

        if (alphaTextState == 1)
        {

            Color color2 = GameManager.gameManager.mainGameplayBg[1].color;
            Color color1 = GameManager.gameManager.mainGameplayBg[2].color;
            color2.a = 1 - alphaTextState;
            color1.a = 1 - alphaTextState;
            GameManager.gameManager.mainGameplayBg[1].color = color2;
            GameManager.gameManager.mainGameplayBg[2].color = color1;

            GameManager.gameManager.mainGameplayBg[0].sprite = GameManager.gameManager.gameplaySprite[0];

            GameManager.gameManager.mainGameplayBg[0].rectTransform.sizeDelta = new Vector2(800f,500f);

        }
    }


    public void SetAlphaTextState(int newAlphaState)
    {
        alphaTextState = newAlphaState;
        HideText();
        HideGameObjectSprite();
    }
}
