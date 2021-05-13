using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPosition;
    public float timeBtwWaves = 0f;
    private float countDown = 2f;
    public Text textTime;
    private int waveIndex = 1;
   
    void Update()
    {
        if(countDown <= 0f)
        {
            Debug.Log("Wave is comming!");

            StartCoroutine(SpawnWave());
            countDown = timeBtwWaves;
        }
        countDown -= Time.deltaTime;
        
        textTime.text =Mathf.Round(countDown).ToString();
    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;


    }
}
