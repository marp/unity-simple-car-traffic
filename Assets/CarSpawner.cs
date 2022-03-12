using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private int carCount;

    [SerializeField] private GameObject carPrefab;

    [SerializeField] private Sprite[] carSprites;

    [SerializeField] private WaypointGizmos[] startingWaypointGroups;

    public bool toggleSpawner = true;
    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (toggleSpawner)
        {
            if (FindObjectsOfType<CarSystem>().Length < carCount)
            {
                var randomWaypointGroup = startingWaypointGroups[Random.Range(0, startingWaypointGroups.Length)];
                var car = Instantiate(carPrefab, randomWaypointGroup.GetNextWaypoint(null).transform.position,
                    quaternion.identity);
                car.GetComponent<SpriteRenderer>().sprite = carSprites[Random.Range(0, carSprites.Length)];
                car.GetComponent<CarSystem>().waypoints = randomWaypointGroup;
                Debug.Log("Spawned car: " + car.name);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
