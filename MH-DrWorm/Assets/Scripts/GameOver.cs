using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool playerTouchedLaser;
    public GameObject player;
    private Animator animator;
    public AudioClip teleportHum;
    public AudioClip laserHit;

    private AudioSource[] allAudioSources;
    private AudioSource teleporterAudio;

    private void Awake()
    {
        teleporterAudio = GetComponent<AudioSource>();
        teleporterAudio.clip = teleportHum;
        teleporterAudio.volume = 0.4f;
        teleporterAudio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        playerTouchedLaser = !Laser.playerDeath;
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        if (!teleporterAudio.isPlaying)
        {
            teleporterAudio.Play();
        }
    }

    public void PlayerHit()
    {
        //Audio for hitting the player
        teleporterAudio.PlayOneShot(laserHit, 1.0f);
        StopAllAudio();

        if (playerTouchedLaser)
        {
            animator.SetTrigger("PlayerHit");
            Invoke("RestartLevel", 5);
        }
    }

    public void StopAllAudio()
    {
        for(var audioS = 0; audioS < allAudioSources.Length; audioS++)
        {
            //stop the footsteps from dead player
            if (allAudioSources[audioS] != teleporterAudio)
            {
                allAudioSources[audioS].Stop();
            }
        }      

    }
    public void RestartLevel()
    {
        Debug.Log("Oh no!");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
