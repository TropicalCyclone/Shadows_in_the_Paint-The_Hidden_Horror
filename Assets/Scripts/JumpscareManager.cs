using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareManager : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemy;
    [SerializeField] private EnemyAttack enemyJumpscare;

    private bool _isClose;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy._isAttacking)
        {
            enemyJumpscare.AttackEnemy();
        }
    }
}
