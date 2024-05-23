using System.Collections;
using UnityEngine;

using TMPro;
public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textToBlink;
    public float blinkTime = 0.5f;
    [HideInInspector]public bool state = true;

    private void Start()
    {
        StartCoroutine(BlinkTextRoutine());
        GameManager.gameManager.OnGameStart += delegate{ TurnOffBlinking(false); };
    
    }

    IEnumerator BlinkTextRoutine()
    {
        while (state)
        {
            textToBlink.text = ""; 
            yield return new WaitForSeconds(blinkTime / 2); 

            textToBlink.text = "How\n\nTo\n\nPlay\n ?"; 
            yield return new WaitForSeconds(blinkTime / 2); 
        }
    }

    public void TurnOffBlinking(bool turnoff)
    {
        state = turnoff;
        StartCoroutine(BlinkTextRoutine());
    }
}
