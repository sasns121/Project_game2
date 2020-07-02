using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public bool IsClose=false;
    public Animator Platf;
    public Animator Lever;
    public bool Down;
    public bool StartDown;
    // Start is called before the first frame update
    void Start()
    {
        StartDown = Down;
        if (Down)
        {
            Platf.Play("Down");
        }
        else
        {
            Platf.Play("Up");
            
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsClose = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsClose = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(IsClose==true && Input.GetKeyDown(KeyCode.F)){
            if (Down)
            {
                Platf.Play("GetUp");
                Lever.Play("GetUpLever");
                Down = false;
            }
            else
            {
                Platf.Play("GetDown");
                Lever.Play("GetDownLever");
                Down = true;
            }
        }
    }
}
