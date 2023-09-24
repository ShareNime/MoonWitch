using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float Timer = 0;
    public float SpawnTime;
    public float SpawnTimeDecrease;
    public float MinSpawnTime;
    public GameObject Enemy;
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("GameplayTheme");
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= SpawnTime)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity, transform);
            SpawnTime -= SpawnTimeDecrease;
            SpawnTime = Mathf.Max(SpawnTime, MinSpawnTime);
            Timer = 0;
        }
    }
}
