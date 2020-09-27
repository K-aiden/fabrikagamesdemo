using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployWoods : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab,woodPrefab;
    [SerializeField] private float respawnTime = 1.0f;

    private Vector2 screenBoundries;
    void Start()
    {
        screenBoundries =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(LogWave());
    }

    private void SpawnObstacles()
    {
        GameObject a = Instantiate(logPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBoundries.x, screenBoundries.x), screenBoundries.y * +2);
        
    }

    IEnumerator LogWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnObstacles();
        }
        
    }
}
