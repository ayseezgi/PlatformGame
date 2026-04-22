using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(4);
    }
}
