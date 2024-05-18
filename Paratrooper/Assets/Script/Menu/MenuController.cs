
using UnityEngine;


public class MenuController : MonoBehaviour
{
    /// <summary>
    ///Menu Button
    /// Button 0 : Start
    /// Button 1 : Quit
    /// Button 2 : How To Play
    /// Button 3 : Back
    /// </summary>

    /// <summary>
    ///Menu Text
    /// Text 0 : Paratrooper
    /// Text 1 : Paratrooper Text
    ///Text 2 : Start
    /// Text 3 : Quit
    /// Text 4 : How To Play
    /// Text 5 : Instruction
    /// Text 6 : Back Text
    /// Text 7 : Current Score
    /// Text 8 : High score
    /// </summary>

    void Start()
    {
        GameManager.gameManager.menuButton[0].onClick.AddListener(StartGame);//How to play Button
        GameManager.gameManager.menuButton[1].onClick.AddListener(Quit);//How to play Button
        GameManager.gameManager.menuButton[2].onClick.AddListener(HowToPlay);//How to play Button
        GameManager.gameManager.menuButton[3].onClick.AddListener(MenuScreen); //Back
    }

    void SetVal(float val)
    {
        for (int i = 0; i < 5; i++)
        {
            GameManager.gameManager.menuText[i].alpha = 0-val;


            if (GameManager.gameManager.menuText[i].alpha == 0-val)
            {
                GameManager.gameManager.menuText[i + 1].alpha = 1+val;
                GameManager.gameManager.menuText[i + 2].alpha = 1+ val;

            }
        }
    }

    void HowToPlay()
    {
        SetVal(0);
    }
    void MenuScreen()
    {
        SetVal(-1);
        for (int i = 0; i < GameManager.gameManager.menuButton.Length - 1; i++)
        {
            GameManager.gameManager.menuButton[i].interactable = true;

        }
        for (int i = 0; i < GameManager.gameManager.mainGameObject.Count; i++)
        {
            GameManager.gameManager.mainGameObject[i].SetActive(false);
        }
    }
    private void Quit()
    {
        Application.Quit();
    }
    private void StartGame()
    {
        // Disable menu buttons
        for (int i = 0; i < GameManager.gameManager.menuButton.Length - 1; i++)
        {
            GameManager.gameManager.menuButton[i].interactable = false;
        }

        // Set menu text alpha
        for (int i = 0; i < 6; i++)
        {
            GameManager.gameManager.menuText[i].alpha = 0;

            if (GameManager.gameManager.menuText[i].alpha == 0)
            {
                GameManager.gameManager.menuText[i + 1].alpha = 1;
            }
        }

        // Disable back button
        GameManager.gameManager.menuButton[3].interactable = false;

        // Activate main game objects
        for (int i = 0; i < GameManager.gameManager.mainGameObject.Count; i++)
        {
            GameManager.gameManager.mainGameObject[i].SetActive(true);
        }
    }

}
