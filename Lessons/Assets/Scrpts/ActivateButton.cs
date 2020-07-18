using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public bool IsClose = false;
    public Animator[] Platf;
    public Animator Lever;
    public bool[] Down;
    public bool[] StartDown;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i< Platf.Length;i++)
        {
            StartDown = Down;
            if (Down[i])
            {
                Platf[i].Play("Down");
            }
            else
            {
                Platf[i].Play("Up");

            }
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
            for (int i = 0; i < Platf.Length; i++)
            {
                if (Down[i])
                {
                    Platf[i].Play("GetUp");
                    Lever.Play("GetUpLever");
                    Down[i] = false;
                }
                else
                {
                    Platf[i].Play("GetDown");
                    Lever.Play("GetDownLever");
                    Down[i] = true;
                }
            }
        }
    }
}
