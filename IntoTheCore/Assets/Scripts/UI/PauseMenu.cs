using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoCache
{
    private bool IsPaused = false;
    [SerializeField] private GameObject canvas;
    public void Pause()
    {
        UpdateManager.PauseGame();
    }
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            IsPaused = !IsPaused;
            if (IsPaused)
            {
                UpdateManager.PauseGame();
                canvas.SetActive(true);
            }
            else
            {
                UpdateManager.ResumeGame();
                canvas.SetActive(false);
            }

        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
