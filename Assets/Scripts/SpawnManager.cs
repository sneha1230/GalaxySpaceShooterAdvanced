using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerups;
    private GameManager gameManager;
    //spawn enemy for every 5 secs using coroutine function
    private void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void StartCoroutineFunctions()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (gameManager.gameOver==false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
    IEnumerator PowerUpSpawn()
    {
        while (gameManager.gameOver==false)
        {
            int randomPowerUp = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8f, 8f), 6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
