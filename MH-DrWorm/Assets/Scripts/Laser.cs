using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    private Collider playerCollider;
    private GameOver game;
    LineRenderer lineRenderer;
    public float range = 50f;
    Vector3 endPoint;
    public UnityEvent OnHitPlayer;

    public static bool playerDeath = false;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerDeath = false;
    }
    private void Start()
    {
        GameObject codey = GameObject.Find("Codey");
        if (codey)
        {
            playerCollider = codey.GetComponent<Collider>();
        } else
        {
            Debug.LogError("Cannot find 'Codey' in the scene!");
        }
        game = FindObjectOfType<GameOver>();
        if (!game)
        {
            Debug.LogError("Cannot find 'GameOver' script in the scene!");
        }
    }
    void Update()
    {
       
        //create a Raycast variable called "hit"
        RaycastHit hit;
        //Use the range variable (defined above) to create a maximum length of the line
        endPoint = transform.forward * range;
        //If the laser line hits a collider, set that as the new range for the line
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            //recalculate the new endpoint
            endPoint = transform.InverseTransformPoint(hit.point);
            //if the object the laser collides with is the player, set up the player death and reset.
            if (hit.collider == playerCollider && !playerDeath)
            {
                playerDeath = true;
                OnHitPlayer.Invoke();
                //game.PlayerHit();
            }
        }

        //Render the line
        lineRenderer.SetPosition(1, endPoint);
    }
}
