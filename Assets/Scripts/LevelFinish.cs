using Unity.VisualScripting;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject playerControl;
    [SerializeField] AudioSource levelJingle;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject winCanvas;
    private void OnTriggerEnter(Collider other)
    {
        playerControl.GetComponent<PlayerControls>().enabled = false;
        levelBGM.SetActive(false);
        levelJingle.Play();
        fadeOut.SetActive(true);

        winCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}
