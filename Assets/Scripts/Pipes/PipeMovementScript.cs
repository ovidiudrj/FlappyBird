using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float deathZone = -10f;

    void Update()
    {
        if (transform.position.x < deathZone)
        {
            Destroy(gameObject);
            return;
        }

        // Foloseste direct viteza calculata de Spawner
        transform.position += Vector3.left * PipeSpawnerScript.CurrentSpeed * Time.deltaTime;
    }
}