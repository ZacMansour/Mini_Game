using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject pausePanel;
    public bool isPaused = false;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel != null)
        {
            //Equals to what pause is not (the opposite)
            //Toggles the bool and sets canvas appropriately
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
        }
    }

}
