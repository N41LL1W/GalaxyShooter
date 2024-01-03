using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUps;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpsRoutine());
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpsRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }        
    }

    IEnumerator SpawnPowerUpsRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPpowerup = Random.Range(0, 3);
            Instantiate(powerUps[randomPpowerup], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }        
    }
}
