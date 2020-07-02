using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCount : MonoBehaviour
{
    public static int coins = 0;
    public static int OnStartCions = 0;
    public static int hp = 2;
    public Text CoinCount;
    public Text HPCount;
    public Animator animator;

    private void Start()
    {
        OnStartCions = coins;
        animator.SetBool("IsDying", false);
        HPCount = GameObject.FindGameObjectWithTag("Hptext").GetComponent<Text>();
        CoinCount = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
    }


    void Update()
    {
        CoinCount.text=coins.ToString("0");
        HPCount.text=hp.ToString("0");
        if (hp <= 0)
        {
            PlayerMovement.CanMove = false;
            animator.SetBool("IsDying", true);
            animator.Play("Player_Die");
        }
    }
}
