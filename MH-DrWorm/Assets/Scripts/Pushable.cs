using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    float pushPower = 1.0f;

    //public AudioClip scrape;

    public Animator anim;

    public AudioClip scrape;

    private AudioSource playerAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //We are constanly checking if the player is touching anything. The stop pushing function is used if he's not in contact.
        Invoke("StopPushing", 0.1f);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Leave the function if no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us. If so, leave the function
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
        
        //If the player is moving a pushable object, ignore the update call for the StopPushing function.
        CancelInvoke("StopPushing");
        if(playerAudio.clip != scrape)
        {
            playerAudio.clip = scrape;
        }

        if (!playerAudio.isPlaying)
        {
            playerAudio.Play();
        }

        anim.SetBool("isPushing", true);
    }

    void StopPushing()
    {
        //Only do something if the player is still using the pushing animation
        if (anim.GetBool("isPushing"))
        {
            anim.SetBool("isPushing", false);
            playerAudio.Stop();
        }
    }



}
