using Unity.VisualScripting;
using UnityEngine;

public class MainGameFlagOperation : MonoBehaviour
{
    public int alphaTextState = 0;

    private void Start()
    {

        SetAlphaTextState(0);
        GameManager.gameManager.OnGameStart+= delegate { SetAlphaTextState(1); };
    }


    public void SetAlphaTextState(int newAlphaState)
    {
        alphaTextState = newAlphaState;
        GameManager.gameManager.mainGameText.ForEach(text => text.alpha = alphaTextState);
        GameManager.gameManager.mainGameSprite.ForEach(sprite => sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alphaTextState));
        UpdateBackground();
    }

    private void UpdateBackground()
    {
        var inverseAlpha = 1 - alphaTextState;
        for (int i = 1; i <= 2; i++)
            GameManager.gameManager.mainGameplayBg[i].color = new Color(GameManager.gameManager.mainGameplayBg[i].color.r, GameManager.gameManager.mainGameplayBg[i].color.g, GameManager.gameManager.mainGameplayBg[i].color.b, inverseAlpha);

        GameManager.gameManager.mainGameplayBg[0].sprite = GameManager.gameManager.gameplaySprite[alphaTextState == 1 ? 0 : 1];
        GameManager.gameManager.mainGameplayBg[0].rectTransform.sizeDelta = new Vector2(alphaTextState == 1 ? 800f : 500f, 500f);
    }

    private void OnDisable()
    {
        GameManager.gameManager.OnGameStart -= delegate { SetAlphaTextState(1); };
    }
}