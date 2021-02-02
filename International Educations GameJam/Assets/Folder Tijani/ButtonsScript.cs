using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private bool allowedToMove = false;

    private Image image;

    private void Start()
    {
        image = FindObjectOfType<Image>();

        image.material.color = Color.white;
    }

    private void Update()
    {
        if (allowedToMove == true)
        {
            image.material.color = Color.red;
        }
    }

    public void StartButton()
    {
        allowedToMove = true;
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
