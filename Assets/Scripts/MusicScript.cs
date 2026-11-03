using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music = GetComponent<AudioSource>();
        if (GameSettings.MusicOn == false)
        {
            music.Stop();
        }
    }
}
