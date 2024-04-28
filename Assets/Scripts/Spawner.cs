using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]

    public GameObject grassPrefab, jumperPrefab, movedPrefab;
    private GameObject selectedPrefab;
    Vector3 spawnLocate;

    [Header("Values")]

    [SerializeField] private int platformCount;
    [SerializeField] private float XValueChange;
    [SerializeField] private float minimumY,maximumY;
    private int spawnIndex = -1,randomNumber;
    void Start()
    {
        selectedPrefab = grassPrefab;
    }

    void Update()
    {
        platformSpawner();
    }

    private void platformSpawner()
    {
        while (spawnIndex < Platforms.score / 10)
        {
            spawnIndex++;            
            Vector2 newScale = new Vector2();

            for (int i = 0; i < platformCount; i++)
            {

                randomNumber = Random.Range(0, 18);
                switch(randomNumber)
                {
                    case 1:
                    case 2:
                        selectedPrefab = jumperPrefab;
                        break;
                    case 3:
                        selectedPrefab = movedPrefab;
                        break;
                    default:
                        selectedPrefab = grassPrefab;
                        break;
                }               
                newScale.x = Random.Range(0.9f, 1.1f);
                transform.localScale = newScale;

                spawnLocate.x = Random.Range(-XValueChange, XValueChange);
                spawnLocate.y += Random.Range(minimumY, maximumY);

                Instantiate(selectedPrefab, spawnLocate, Quaternion.identity);
            }
        }
    }
}
