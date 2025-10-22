using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    private StarterAssetsInputs _inputs;

    private void Awake() 
    {
        _inputs = GetComponent<StarterAssetsInputs>();
    }
    
    private void Update()
    {
        if (_inputs == null) return;
        
        if (_inputs.reload)  // true when 1 key pressed
        {
            ReloadScene();
        }

        if (_inputs.quit)  // true when 2 key pressed
        {
            QuitGame();
        }
    }

    private void ReloadScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
