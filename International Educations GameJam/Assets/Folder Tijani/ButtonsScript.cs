using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    //private Image image;

    private GamePlayManager gamePlayManager;

    private void Start()
    {
        //image = FindObjectOfType<Image>();

        //image.material.color = Color.white;

        gamePlayManager = GetComponent<GamePlayManager>();
    }

    private void Update()
    {
        if (gamePlayManager.AllowedToMove)
        {
            //image.material.color = Color.red;
        }
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
        //Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }

}
