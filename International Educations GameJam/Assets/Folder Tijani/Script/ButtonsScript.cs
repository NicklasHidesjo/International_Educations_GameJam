using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    private GamePlayManager gamePlayManager;

    private void Start()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
    }

    public void StartButton()
    {
        gamePlayManager.StartGame();
    }

    public void ReplayGameButton()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
