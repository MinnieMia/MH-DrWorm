using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float timeUntilClose = 1f;
    private float timer = 0f;
    private bool isOpen = false;
    private bool isPlaying = false;
    Animator animator;
    public AudioClip doorClip;
    private AudioSource doorSound;

    public GameObject[] buttons;

    private GameObject[] btnObjects;

    public void Awake()
    {
        doorSound = GetComponent<AudioSource>();
        doorSound.clip = doorClip;
        doorSound.Stop();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        

        //Define length of btnObjects array based on length of buttons array
        btnObjects = new GameObject[buttons.Length];

        //Find the child named "green" in each index of buttons and assign that to an index in btnObjects aaray
        for (int btn = 0; btn < buttons.Length; btn++)
        {
            btnObjects[btn] = buttons[btn].transform.Find("green").gameObject;
        }
    }

    //Open door, set timer
    public void Open()
    {
        isOpen = true;
        timer = timeUntilClose;
        
        //Door open transition in Animator
        animator.SetBool("DoorActivate", true);
        
    }

    //Close door
    public void Close()
    {
        isOpen = false;

        //Door close transition in animator
        animator.SetBool("DoorActivate", false);

        doorSound.PlayOneShot(doorClip);

        isPlaying = false;
    }

    //Check if all switches are "green" (enabled).
    public void SwitchCheck()
    {
        //When we start the function, switchesEnabled is true. 
        bool switchesEnabled = true;

        //Check all indexes in the btnObjects array
        for (int switches = 0; switches < buttons.Length; switches++)
        {
            //Get the SpriteRenderer component of the btnObjects index. 
            var thisSwitch = btnObjects[switches].GetComponent<SpriteRenderer>();

            //if it is enabled, then green is showing. If not, red is showing
            if (!thisSwitch.enabled)
            {
                //if any of the switches aren't green, then switchesEnabled is false and we don't need to check anymore
                switchesEnabled = false;
                break;
            }
        }

        //If switchesEnabled is still true, then we can open the door.
        if (switchesEnabled)
        {
            Open();
        }

    }

    void Update()
    {
        //If door is open, count down until 0 and close the door
        if (isOpen)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                Close();
            }
        }

        if (!isPlaying && isOpen)
        {
            doorSound.PlayOneShot(doorClip);
            isPlaying = true;
        }

    }
}
