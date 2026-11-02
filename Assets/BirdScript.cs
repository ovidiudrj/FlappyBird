using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public LogicManagerScript Logic;
    public bool alive = true;
    public AudioSource jumpSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alive && !Logic.isPaused)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrenght;
            jumpSound.Play();
        }

        float viteza = myRigidbody.linearVelocity.y; // aici stocam cat de repede se misca obiectul
        transform.rotation = Quaternion.Euler(0, 0, viteza * 2f); // aici modificam rotatia pe axa z, Quaternion.Euler(x,y,z) cu asta modifici rotatia pe fiecare axa;

        /*viteza +8 →  8×5=+40°  → botul în sus
          viteza  0 →     0°     → dreaptă
          viteza -8 →  -8×5=-40° → botul în jos */

        if (alive && (transform.position.y > 5f || transform.position.y < -5f))
        {
            alive = false;
            Logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (alive)
        {
            Logic.gameOver();
            alive = false;
        }
    }
}
