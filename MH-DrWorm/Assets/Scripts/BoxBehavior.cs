using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    public Animator anim;

    //public void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player" )
    //    {
    //        anim = other.gameObject.GetComponent<Animator>();
    //        Debug.Log("Entered");
    //        anim.SetBool("isPushing", true);
    //    }
    //}

    public void OnCollisionExit(Collision other)
    {
        //if (other.gameObject.tag != "Player")
        //{
            anim = other.gameObject.GetComponent<Animator>();
            Debug.Log("Exited");
            anim.SetBool("isPushing", true);
        //}
    }
}
