using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChains : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void PlayNextPlatform()
    {
        animator.enabled=true;
    }
    
}
