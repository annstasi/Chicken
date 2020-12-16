using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
  public void repeatGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
  public void quitGame()
    {
        Application.Quit();
    }
}