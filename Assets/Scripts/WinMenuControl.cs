using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuControl : MonoBehaviour
{
    public void GoToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1); 
    }
    public void QuitGame()
    {
        Debug.Log("Çıkış butonuna basıldı");
        Application.Quit();
    }
}
