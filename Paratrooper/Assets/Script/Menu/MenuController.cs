
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
    /// Button 0 : Paratrooper
    /// Button 1 : Paratrooper
    /// Button 2 : Start
    /// Button 3 : Quit
    /// Button 4 : How To Play
    /// Button 5 : Back
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
    }
    private void Quit()
    {
        Application.Quit();
    }
    private void StartGame()
    {
        for (int i = 0; i < GameManager.gameManager.menuButton.Length-1; i++)
        {
            GameManager.gameManager.menuButton[i].interactable = false;

        }

        for (int i = 0; i < 6; i++)
        {
            GameManager.gameManager.menuText[i].alpha = 0 ;


            if (GameManager.gameManager.menuText[i].alpha == 0 )
            {
               
                GameManager.gameManager.menuText[i + 1].alpha = 1 ;

            }
        }
    }
}
