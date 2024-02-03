using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    //This script is primarily designed for the visual behavior of the switch object and have it change from red to green.
    
    //Tells this script where to find the DoorTrigger script.
    public DoorTrigger door;
    //Variable used for keeping track of the red and green icons
    private GameObject switchIcon;
    private AudioSource playBeep;

    //When the game starts, the switch icon is Red and the Green part is hidden.
    private void Start()
    {
        switchIcon = this.transform.Find("red").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = true;
        switchIcon = this.transform.Find("green").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = false;

        playBeep = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        playBeep.Play(0);
    }

    //When any object enters the switch and stays, the switch icon is Green and the Red part is hidden.
    public void OnTriggerStay(Collider other)
    {
        StopAllCoroutines();  //Designer's note: I do not recall why this is here or even if it is necessary.
        switchIcon = this.transform.Find("green").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = true;
        switchIcon = this.transform.Find("red").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = false;

        //Have the door check if all of the switches are green
        door.SwitchCheck();
    }

    //When all objects have left the switch, the switch icon is Red and the Green part is hidden.
    public void OnTriggerExit(Collider other)
    {
        switchIcon = this.transform.Find("red").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = true;
        switchIcon = this.transform.Find("green").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = false;

        playBeep.Play(0);
    }
}
