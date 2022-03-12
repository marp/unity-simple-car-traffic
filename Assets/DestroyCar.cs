using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<CarSystem>())
        {
            Debug.Log("Destroyed car: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
