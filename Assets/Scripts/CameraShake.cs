using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private const float Magnitude = 0.1f;
    private float shakeTime = 0;

    public void Shake()
    {
        shakeTime = 0.25f;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.position = new Vector3(Random.Range(-Magnitude, Magnitude), Random.Range(-Magnitude, Magnitude), -1);
            shakeTime -= Time.unscaledDeltaTime;
        }
        else
        {
            transform.position = new Vector3(0, 0, -1);
        }
    }
}