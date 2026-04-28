using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
