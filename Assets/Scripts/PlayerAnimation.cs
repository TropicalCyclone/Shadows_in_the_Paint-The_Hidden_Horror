using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement player;
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
            animator.SetBool("IsWalking",false);
        }

        if (player.GetCrouchStatus())
        {
            animator.SetBool("IsSneaking", true );
        }
        else
        {
            animator.SetBool("IsSneaking",false );
        }
    }
}
