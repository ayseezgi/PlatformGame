using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObstacleControls : MonoBehaviour
{
    public GameObject objePrefab;
    public float spawnAraligi = 4f;
    public float yokEtmeSuresi = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObje();
            yield return new WaitForSeconds(spawnAraligi);
        }
    }
    void SpawnObje()
    {
        GameObject yeniEngel = Instantiate(objePrefab, transform.position, transform.rotation);
        Destroy(yeniEngel, yokEtmeSuresi);
    }

}