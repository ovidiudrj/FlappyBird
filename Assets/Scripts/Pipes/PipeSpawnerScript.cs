using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float pipeSpacing = 8f;
    public float heightOffset = 2f;

    [Header("Setari Viteza")]
    public float startSpeed = 1f;
    public float maxSpeed = 12f;
    public float acceleration = 0.1f;

    public static float CurrentSpeed;
    private float distance = 0f;

    void Start()
    {
        CurrentSpeed = startSpeed;
        spawnPipe();
    }

    void Update()
    {
        // 1. Calculam viteza intr-un singur loc
        CurrentSpeed = Mathf.Min(startSpeed + acceleration * Time.timeSinceLevelLoad, maxSpeed);

        // 2. Masuram distanta parcursa de ultima teava spawnata
        distance += CurrentSpeed * Time.deltaTime;

        if (distance >= pipeSpacing)
        {
            spawnPipe();
            distance -= pipeSpacing;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}