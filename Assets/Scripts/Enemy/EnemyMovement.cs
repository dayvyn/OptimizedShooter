using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    PlayerHealth player;
    EnemyHealth enemyREF;
    NavMeshAgent navAgent;
    Transform playerTransform;
    private void OnEnable()
    {
        player = FindObjectOfType<PlayerHealth>();
        enemyREF = GetComponent<EnemyHealth>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTransform = player.transform;
    }
    void Update ()
    {
        if (enemyREF.currentHealth > 0 && player.currentHealth > 0)
        {
            navAgent.SetDestination(playerTransform.position);
        }
        else
        {
            navAgent.enabled = false;
        }
    }
}
