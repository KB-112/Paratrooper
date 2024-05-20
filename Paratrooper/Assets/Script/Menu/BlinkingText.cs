using System.Collections;
using UnityEngine;

using TMPro;
public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textToBlink;
    public float blinkTime = 0.5f;

    private void Start()
    {
        StartCoroutine(BlinkTextRoutine());
    }

    IEnumerator BlinkTextRoutine()
    {
        while (true)
        {
            textToBlink.text = ""; 
            yield return new WaitForSeconds(blinkTime / 2); 

            textToBlink.text = "How\n\nTo\n\nPlay\n ?"; 
            yield return new WaitForSeconds(blinkTime / 2); 
        }
    }
}
