using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private FadeScreen fader;
    [SerializeField] private Animator animator;
    void Start()
    {
        animator.gameObject.SetActive(false);
    }

    private void Update()
    {

    }
    public void AttackEnemy()
    {
        animator.gameObject.SetActive(true);
        animator.SetTrigger("Attack");
    }
}
