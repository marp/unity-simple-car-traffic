using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSpace : MonoBehaviour
{
    public bool isFree = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CarSystem>())
        {
            isFree = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CarSystem>())
        {
            isFree = true;
        }
    }
}
