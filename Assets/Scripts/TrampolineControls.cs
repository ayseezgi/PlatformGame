using UnityEngine;
using System.Collections;

public class TrampolineControls : MonoBehaviour
{
    public float baseBounce = 10f;
    public float extraBounce = 0.5f;
    public Transform yay;

    Vector3 startScale;

    void Start()
    {
        startScale = yay.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerControls player = other.GetComponentInParent<PlayerControls>();

        if (player != null)
        {
            float fallSpeed = player.GetFallSpeed();
            float bounce = baseBounce + (fallSpeed * extraBounce);

            player.Bounce(bounce);

            StartCoroutine(SpringAnim());
        }
    }

    IEnumerator SpringAnim()
    {
        yay.localScale = new Vector3(startScale.x, startScale.y * 0.4f, startScale.z);
        yield return new WaitForSeconds(0.12f);
        yay.localScale = startScale;
    }
}