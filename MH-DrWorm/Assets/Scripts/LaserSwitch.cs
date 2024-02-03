using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    private GameObject switchIcon;
    private AudioSource playBeep;



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
        playBeep.Play();
    }

    public void OnTriggerStay(Collider other)
    {
        StopAllCoroutines();
        switchIcon = this.transform.Find("green").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = true;
        switchIcon = this.transform.Find("red").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void OnTriggerExit(Collider other)
    {
        switchIcon = this.transform.Find("red").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = true;
        switchIcon = this.transform.Find("green").gameObject;
        switchIcon.GetComponent<SpriteRenderer>().enabled = false;
    }
}
