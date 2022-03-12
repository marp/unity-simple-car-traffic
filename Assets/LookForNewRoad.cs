using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LookForNewRoad : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypointGroups;

    [SerializeField] private FreeSpace freeSpace;

    private float _tryAgainAfter;
    private void OnTriggerEnter2D(Collider2D col)
    {

            if (waypointGroups.Count > 0 && col.gameObject.GetComponent<CarSystem>())
            {
                if ((freeSpace != null && freeSpace.isFree) || freeSpace == null)
                {
                        //Debug.Log("Looking for new track. Available tracks: " + waypointGroups.Count);
                        SetNewTrack(col.GetComponent<CarSystem>());
                }
                else
                {
                    StartCoroutine(TryUntilFreeSpace(col.GetComponent<CarSystem>()));
                }
            }
            else
            {
                Debug.Log("No more available tracks.");
            }
    }

    private void SetNewTrack(CarSystem car)
    {
        car.waypoints = waypointGroups[Random.Range(0, waypointGroups.Count)]
            .GetComponent<WaypointGizmos>();
        car.StartTrack();
    }

    private IEnumerator TryUntilFreeSpace(CarSystem car)
    {
        while (!freeSpace.isFree)
        {
            yield return new WaitForSeconds(3f);
        }
        SetNewTrack(car);
    }
}
