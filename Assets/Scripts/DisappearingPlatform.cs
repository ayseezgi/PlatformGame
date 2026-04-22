using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private Collider col;
    private MeshRenderer mesh;
    private bool isWorking = false;

    Vector3 originalPos;

    void Start()
    {
        col = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
        originalPos = transform.position;
    }

    void Update()
    {
        if (!isWorking)
        {
            CheckPlayerOnPlatform();
        }
    }

    void CheckPlayerOnPlatform()
    {
        Collider[] hits = Physics.OverlapBox(
            transform.position + new Vector3(0, 0.6f, 0),
            new Vector3(0.4f, 0.2f, 0.4f)
        );

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                isWorking = true;
                StartCoroutine(PlatformRoutine());
                break;
            }
        }
    }

    IEnumerator PlatformRoutine()
    {
        float timer = 0f;

        yield return new WaitForSeconds(1f);

        while (timer < 0.5f)
        {
            float shakeAmount = 0.05f;

            transform.position = originalPos + new Vector3(
                Random.Range(-shakeAmount, shakeAmount),
                0,
                Random.Range(-shakeAmount, shakeAmount)
            );

            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;

        col.enabled = false;
        mesh.enabled = false;

        yield return new WaitForSeconds(1.5f);

        col.enabled = true;
        mesh.enabled = true;

        isWorking = false;
    }
}