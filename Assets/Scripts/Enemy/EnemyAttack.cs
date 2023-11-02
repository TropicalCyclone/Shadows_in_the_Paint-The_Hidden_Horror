using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    void Attack()
    {
        SceneManager.LoadScene("EnemyAttack",LoadSceneMode.Additive);
    }
}
