using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareManager : MonoBehaviour
{
    [SerializeField] private EnemyAttack enemyJumpscare;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        enemyJumpscare.AttackEnemy();
    }
}
