using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBumper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.GetComponent<LookForNewRoad>() && !col.GetComponent<DestroyCar>() && !col.GetComponent<CarBumper>() && !col.GetComponent<FreeSpace>())
        {
            GetComponentInParent<CarSystem>().canMove = false;
            GetComponentInParent<SpriteRenderer>().color = Color.green;
        }
        //print("Bumper trigerred on!");
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        GetComponentInParent<CarSystem>().canMove = true;
        GetComponentInParent<SpriteRenderer>().color = Color.white;
        //print("Bumper trigerred off!");
    }
}
