using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private float spawnDelay = 1f;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    private void Spawn()
    {
        Vector2 randomPointInCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 offset = new Vector3(randomPointInCircle.x, 0f, randomPointInCircle.y);
        Instantiate(enemyPrefab, transform.position + offset, enemyPrefab.transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawSphere(transform.position, 0.5f);
        //Gizmos.DrawIcon(transform.position + Vector3.up, "enemy");
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    
}
