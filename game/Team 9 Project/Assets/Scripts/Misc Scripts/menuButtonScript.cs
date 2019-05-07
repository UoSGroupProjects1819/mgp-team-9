using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtonScript : MonoBehaviour
{

    public CanvasGroup MainCanvas;
    public CanvasGroup OptionsCanvas;

    // is help screen showing
    private bool helpful = false;

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

    public void LoadHelp()
    {
        if (helpful)
        {
            helpful = false;

            MainCanvas.interactable = true;
            MainCanvas.blocksRaycasts = true;
            MainCanvas.alpha = 1;

            OptionsCanvas.interactable = false;
            OptionsCanvas.blocksRaycasts = false;
            OptionsCanvas.alpha = 0;
        }
        else
        {
            helpful = true;

            MainCanvas.interactable = false;
            MainCanvas.blocksRaycasts = false;
            MainCanvas.alpha = 0;

            OptionsCanvas.interactable = true;
            OptionsCanvas.blocksRaycasts = true;
            OptionsCanvas.alpha = 1;
        }
    }
}
