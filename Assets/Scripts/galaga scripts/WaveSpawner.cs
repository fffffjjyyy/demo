
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] EnemyWaves;
    public GameObject[] PowerUps;

    public float waveTimer = 0, waveWait = 3;

    public float PowerUpTimer = 0, PowerUpWait = 20;
    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;
        PowerUpTimer += Time.deltaTime;
        if(waveTimer > waveWait)
        {
            waveTimer = 0;
            Instantiate(EnemyWaves[Random.Range(0, EnemyWaves.Length)], transform.position, Quaternion.identity);
        }
        if (PowerUpTimer > PowerUpWait)
        {
            PowerUpTimer = 0;
            Instantiate(PowerUps[Random.Range(0, PowerUps.Length)], transform.position, Quaternion.identity);
        }
    }
}
