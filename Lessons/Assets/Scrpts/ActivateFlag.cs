using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateFlag : MonoBehaviour
{
    public Animator Flag;
    public Animator Char;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerMovement.CanMove = false;
            Flag.enabled=true;
            Char.Play("Player_finish");
        }
    }  
}
