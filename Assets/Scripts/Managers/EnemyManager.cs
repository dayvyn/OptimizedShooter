using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        GameObject enemyZOM = ObjectPool.SharedInstance.GetPooledObject();
        if (enemyZOM != null)
        {
            enemyZOM.SetActive(true);
        }
    }
}
