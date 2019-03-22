using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtonScript : MonoBehaviour
{

    public CanvasRenderer MainCanvas;
    public CanvasRenderer OptionsCanvas;

    public void loadStartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // stops the game if using editor
        UnityEditor.EditorApplication.isPlaying = false;

        // quits the game when in a standalone application
        Application.Quit();
    }
}
