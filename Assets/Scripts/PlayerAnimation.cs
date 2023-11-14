using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerGrab grab;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private AudioManager audioManager;

    private bool only_once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetWalkingStatus())
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (player.GetCrouchStatus())
        {
            animator.SetBool("IsSneaking", true);
        }
        else
        {
            animator.SetBool("IsSneaking", false);
        }

        if (grab.isObjectGrabbed())
        {
            if (!only_once)
            {
                animator.SetTrigger("PickUp");
                only_once = true;
            }
        }
        else
        {
            only_once=false;
        }
    }

    public void grabItem()
    {
        audioManager.grabSoundPlay();
    }
}
