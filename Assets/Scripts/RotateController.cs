using UnityEngine;

public class RotateController : MonoBehaviour
{

    public float donusHizi = 100f;
    public Transform donecekTransform;
    private void Update()
    {
        donecekTransform.Rotate(Vector3.up * donusHizi * Time.deltaTime);
    }

}