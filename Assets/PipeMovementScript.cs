using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed;
    public float deathZone = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deathZone)
        {
            Destroy(gameObject);
        }

        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

        if (moveSpeed < 15)
        {
            moveSpeed += 0.1;
        }

    }
}
