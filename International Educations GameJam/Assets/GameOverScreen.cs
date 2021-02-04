using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "Points";
    }

    /*public void TryAgainButton();
    SceneManager.LoadScene("Game");

    public void ExitButton(); 
    SceneManager.LoadScene("Main Menu"); */
}
