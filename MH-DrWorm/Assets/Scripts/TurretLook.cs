using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLook : MonoBehaviour
{
    public Transform player;
    private LaserSwitch laserSwitch;
    private GameObject laser;

    private void Start()
    {
        laserSwitch = GameObject.Find("LaserSwitch").GetComponent<LaserSwitch>();
        laser = transform.Find("Laser").gameObject;
    }

    void Update() 
    {
        if (laserSwitch.lasersAreOff)
        {
            laser.SetActive(false);
            return;
        }
        transform.LookAt(player);
    }
}
