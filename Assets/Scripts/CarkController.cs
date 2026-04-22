using UnityEngine;

public class CarkController : MonoBehaviour
{
    public Transform carkObjesi;
    public float donusHizi = 100f;
    public float hareketHizi = 2f;
    public float maxPosition = 1.3f;
    public float minPosition = -1.3f;

    private void Update()
    {
        carkObjesi.Rotate(Vector3.right * donusHizi * Time.deltaTime);
        float hareketYonu = Mathf.PingPong(Time.time * hareketHizi, maxPosition - minPosition) + minPosition;
        carkObjesi.transform.localPosition = new Vector3(carkObjesi.localPosition.x, carkObjesi.localPosition.y, hareketYonu);
    }

}
