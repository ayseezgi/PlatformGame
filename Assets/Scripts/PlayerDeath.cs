using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Oyuncu öldü");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}