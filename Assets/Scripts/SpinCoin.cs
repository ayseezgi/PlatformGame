using UnityEngine;

public class SpinCoin : MonoBehaviour
{
    public float rotationSpeed = 300f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
